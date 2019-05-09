using System;
using System.Collections.Generic;

namespace library.Models
{
    class Library
    {

        public string Name { get; set; }
        public string Owner { get; set; }
        public string City { get; set; }
        //list of books
        //need to be able to check out a book and add it to a list of checked out
        private List<Book> AvailableBooks { get; set; }
        private List<Book> CheckedOutBooks { get; set; }

        public void AddBook(Book book)
        {
            if(book.Available)
            {
                AvailableBooks.Add(book);
            }
            else
            {
                CheckedOutBooks.Add(book);
            }
        }

        public void ViewBooks(List<Book> books)
        {   
            int count = 1;
            foreach (Book book in books)
            {
                System.Console.WriteLine("{0}. {1} - {2}", count, book.Title, book.Author);
                count ++;
            }
        }

        public bool PrintDirectory()
        {
            bool StayInLibrary = true;
            System.Console.WriteLine("(V)iew all books");
            System.Console.WriteLine("(R)eturn a book");
            System.Console.WriteLine("(C)heckout a book");
            System.Console.WriteLine("(Q) to leave the library.");
            string input = Console.ReadLine();
            switch(input.ToLower()){
                case "v":
                    Console.Clear();
                    System.Console.WriteLine("The available books are: ");
                    ViewBooks(AvailableBooks);
                    break;
                case "r":
                    Console.Clear();
                    ReturnBook();
                    break;
                case "c":
                    Console.Clear();
                    CheckOutBooks();
                    break;
                case "q":
                    StayInLibrary = false;
                    break;
                default:
                    System.Console.WriteLine("Invalid option!\n Press Enter to Continue");
                    Console.ReadLine();
                    Console.Clear();
                    PrintDirectory();
                    break;
            }
            return StayInLibrary;
        }

        public void CheckOutBooks()
        {
            System.Console.WriteLine("Enter the number of the book that you'd like to check out: ");
            ViewBooks(AvailableBooks);
            Book bookToCheckOut = ValidateUserInput(AvailableBooks);
            if(bookToCheckOut == null) return;
            bookToCheckOut.Available = false;
            AvailableBooks.Remove(bookToCheckOut);
            CheckedOutBooks.Add(bookToCheckOut);
            System.Console.WriteLine("We hope that you enjoy {0}", bookToCheckOut.Title);
        }
        public void ReturnBook()
        {   
            System.Console.WriteLine("Enter the number of the book you would like to return: ");
            ViewBooks(CheckedOutBooks);
            Book bookToReturn = ValidateUserInput(CheckedOutBooks);
            //null check to prevent breaking errors
            if(bookToReturn == null) return;
            //if found a book to return
            //1. Reassign available property to true
            //2. remove the book from the CheckedOutBooks list
            //3. add the book to AvailableBooks
            bookToReturn.Available = true;
            CheckedOutBooks.Remove(bookToReturn);
            AvailableBooks.Add(bookToReturn);
            System.Console.WriteLine("Thanks for returning {0}!", bookToReturn.Title);
        }


        public Book ValidateUserInput(List<Book> books)
        {   
            if(books.Count == 0)
            {
                System.Console.WriteLine("No books currently.");
                return null;
            }
            int bookNum = 0;
            while (!Int32.TryParse(Console.ReadLine(), out bookNum) || bookNum < 1 || bookNum > books.Count) {
                System.Console.WriteLine("Not a valid choice.");
            }
            return books[bookNum - 1];
        }

        public void Greeting()
        {
            System.Console.WriteLine("Welcome to {0}. Thanks for visiting {1}", City, Name);
        }

        //constructor method
        //always always is named the same as the class name
        //used to assign values to the class properties
        //cannot specify a return type
        public Library(string name, string owner, string city)
        {
            Name = name;
            Owner = owner;
            City = city;
            AvailableBooks = new List<Book>();
            CheckedOutBooks = new List<Book>();
        }
        

        

    }
}