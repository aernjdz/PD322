def print_books(books):
    for index, book in enumerate(books, start=1):
        print(f"{index}. {book['title']} by {book['author']} ({book['publisher']}) - {book['genre']}, Price: {book['price']}, Rating: {book['rating']}")

def add_book(books):
    try:
        title = input("Title: ")
        author = input("Author: ")
        publisher = input("Publisher: ")
        genre = input("Genre: ")
        price = float(input("Price: "))
        rating = float(input("Rating: "))
        
        new_book = {'title': title, 'author': author, 'publisher': publisher, 'genre': genre, 'price': price, 'rating': rating}
        books.append(new_book)
        print("Book added.")
    except ValueError:
        print("Invalid input format. Please enter correct data.")

def edit_book(books):
    try:
        index = int(input("Enter the book number you want to edit: ")) - 1
        if 0 <= index < len(books):
            book = books[index]
            print(f"Editing details for {book['title']}:")
            book['title'] = input("New title: ")
            book['author'] = input("New author: ")
            book['publisher'] = input("New publisher: ")
            book['genre'] = input("New genre: ")
            book['price'] = float(input("New price: "))
            book['rating'] = float(input("New rating: "))
        else:
            print("Invalid book number.")
    except (ValueError, IndexError):
        print("Invalid input format or book number.")

def delete_book(books):
    try:
        index = int(input("Enter the book number you want to delete: ")) - 1
        if 0 <= index < len(books):
            del books[index]
            print("Book deleted.")
        else:
            print("Invalid book number.")
    except (ValueError, IndexError):
        print("Invalid input format or book number.")

def search_by_author(books):
    author = input("Enter author: ")
    found_books = [book for book in books if author.lower() in book['author'].lower()]
    return found_books

def search_by_title(books):
    title = input("Enter book title: ")
    found_books = [book for book in books if title.lower() in book['title'].lower()]
    return found_books

def sort_by_title(books):
    books.sort(key=lambda book: book['title'].lower())

def sort_by_author(books):
    books.sort(key=lambda book: book['author'].lower())

def sort_by_publisher(books):
    books.sort(key=lambda book: book['publisher'].lower())

def sort_by_price(books):
    books.sort(key=lambda book: book['price'])

def sort_by_rating(books):
    books.sort(key=lambda book: book['rating'], reverse=True)

def main():
    books = [
        {'title': 'The Great Gatsby', 'author': 'F. Scott Fitzgerald', 'publisher': 'Scribner', 'genre': 'Classic', 'price': 12.99, 'rating': 4.2},
        {'title': 'To Kill a Mockingbird', 'author': 'Harper Lee', 'publisher': 'HarperCollins', 'genre': 'Fiction', 'price': 10.50, 'rating': 4.5},
        {'title': '1984', 'author': 'George Orwell', 'publisher': 'Penguin', 'genre': 'Dystopian', 'price': 9.99, 'rating': 4.0},
        {'title': 'Harry Potter and the Sorcerer\'s Stone', 'author': 'J.K. Rowling', 'publisher': 'Scholastic', 'genre': 'Fantasy', 'price': 14.95, 'rating': 4.7},
        {'title': 'The Lord of the Rings', 'author': 'J.R.R. Tolkien', 'publisher': 'Houghton Mifflin', 'genre': 'Fantasy', 'price': 18.99, 'rating': 4.8},
        {'title': 'Pride and Prejudice', 'author': 'Jane Austen', 'publisher': 'Penguin', 'genre': 'Romance', 'price': 8.75, 'rating': 4.4},
        {'title': 'Brave New World', 'author': 'Aldous Huxley', 'publisher': 'HarperCollins', 'genre': 'Sci-Fi', 'price': 11.25, 'rating': 4.1},
        {'title': 'The Catcher in the Rye', 'author': 'J.D. Salinger', 'publisher': 'Little, Brown', 'genre': 'Classic', 'price': 9.99, 'rating': 3.9},
        {'title': 'The Hobbit', 'author': 'J.R.R. Tolkien', 'publisher': 'Houghton Mifflin', 'genre': 'Fantasy', 'price': 12.50, 'rating': 4.6},
        {'title': 'Fahrenheit 451', 'author': 'Ray Bradbury', 'publisher': 'Simon & Schuster', 'genre': 'Dystopian', 'price': 10.99, 'rating': 4.3},
    ]

    while True:
        print("\nMenu:")
        print("1. Print all books")
        print("2. Add a book")
        print("3. Edit a book")
        print("4. Delete a book")
        print("5. Search books by author")
        print("6. Search books by title")
        print("7. Sort by title")
        print("8. Sort by author")
        print("9. Sort by publisher")
        print("10. Sort by price")
        print("11. Sort by rating")
        print("0. Exit")

        choice = input("Choose an option: ")

        if choice == "1":
            print_books(books)
        elif choice == "2":
            add_book(books)
        elif choice == "3":
            edit_book(books)
        elif choice == "4":
            delete_book(books)
        elif choice == "5":
            found_books = search_by_author(books)
            if found_books:
                print_books(found_books)
            else:
                print("No books by this author found.")
        elif choice == "6":
            found_books = search_by_title(books)
            if found_books:
                print_books(found_books)
            else:
                print("No book with this title found.")
        elif choice == "7":
            sort_by_title(books)
            print("List sorted by title.")
        elif choice == "8":
            sort_by_author(books)
            print("List sorted by author.")
        elif choice == "9":
            sort_by_publisher(books)
            print("List sorted by publisher.")
        elif choice == "10":
            sort_by_price(books)
            print("List sorted by price.")
        elif choice == "11":
            sort_by_rating(books)
            print("List sorted by rating.")
        elif choice == "0":
            print("Thank you for using the program. Goodbye!")
            break
        else:
            print("Invalid choice. Please try again.")

if __name__ == "__main__":
    main()
