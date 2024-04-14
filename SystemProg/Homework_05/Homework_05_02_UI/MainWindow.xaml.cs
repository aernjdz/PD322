using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using Homework_05_02_DAL;
namespace Homework_05_02_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LIbraryModel context;
        public MainWindow()
        {
            InitializeComponent();
            context  = new LIbraryModel();
            LoadAuthors();
        }

    

    private async void LoadAuthors()
    {
        try
        {
            List<Author> authors = await context.Authors.ToListAsync();
            authorComboBox.ItemsSource = authors;
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while loading authors: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async void LoadBooksByAuthor(int authorId)
    {
        try
        {
            List<Book> books = await context.Books.Where(b => b.AuthorId == authorId).ToListAsync();
            bookDataGrid.ItemsSource = books;
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while loading books by author: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async void FilterBooksByTitle(string title)
    {
        if (title.Length < 3)
            return;
        try
        {
            List<Book> books = await context.Books.Where(c => c.AuthorId == (int)authorComboBox.SelectedValue ).Where(b => b.Title.Contains(title)).ToListAsync();
            bookDataGrid.ItemsSource = books;
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while filtering books by title: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void authorComboBox_SelectionChanged(object sender, RoutedEventArgs e)
    {
        if (authorComboBox.SelectedItem != null)
        {
            int authorId = (int)authorComboBox.SelectedValue;
            LoadBooksByAuthor(authorId);
        }
    }

    private void searchTextBox_TextChanged(object sender, RoutedEventArgs e)
    {
        string searchText = searchTextBox.Text;
        FilterBooksByTitle(searchText);
    }
}
}