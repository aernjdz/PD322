    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using Exam_DAL;
    namespace Exam_UI
    {

        public partial class MainWindow : Window
        {
            private LibraryModel context;
            private List<book> allBooks;

            public MainWindow()
            {
                InitializeComponent();
                context = new LibraryModel();
                PopulateComboBox();
            }

            private void PopulateComboBox()
            {
                allBooks = context.Books.ToList();
                allBooks.Insert(0, new book { title = "Books" });
                TableComboBox.ItemsSource = allBooks;
                TableComboBox.DisplayMemberPath = "title";
                TableComboBox.SelectedIndex = 0; 
            }

            private void FillButton_Click(object sender, RoutedEventArgs e)
            {
                book selectedBook = TableComboBox.SelectedItem as book;
                if (selectedBook != null && selectedBook.title == "Books")
                {
                    DataGrid.ItemsSource = allBooks; 
                }
                else if (selectedBook != null)
                {
                    DataGrid.ItemsSource = new List<book> { selectedBook }; 
                }
            }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var res = DataGrid.ItemsSource as List<book>;
                var entry = context.Books.Count();
                res = res.OrderBy(x => x.Book).ToList();
                for (int i = entry; i < res.Count; i++)
                {
                    context.Books.Add(res[i]);
                }
                context.SaveChanges();
                MessageBox.Show("Data Updated Successfully", "Successfully",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
            {
                string title = titleTextBox.Text;
                string author = authorTextBox.Text;
                string genre = genreTextBox.Text;

                List<book> searchResults = SearchBooks(title, author, genre);

                DataGrid.ItemsSource = searchResults;
            }

        public List<book> SearchBooks(string title = null, string author = null, string genre = null)
        {
            var query = context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(title))
                query = query.Where(b => b.title.Contains(title));

            if (!string.IsNullOrEmpty(author))
                query = query.Where(b => b.author_name.Contains(author));

            if (!string.IsNullOrEmpty(genre))
                query = query.Where(b => b.genre.Contains(genre));


            return query.ToList();
        }
        private void ShowSpecialOffersButton_Click(object sender, RoutedEventArgs e)
        {

            List<book> specialOffers = context.Books.Where(b => b.is_shared == "Y").ToList();

            DataGrid.ItemsSource = specialOffers;
        }

        private void ShowReservedBooksButton_Click(object sender, RoutedEventArgs e)
        {

            List<book> reservedBooks = context.Books.Where(b => b.is_reserved == "Y").ToList();

            DataGrid.ItemsSource = reservedBooks;
        }



    }
}
