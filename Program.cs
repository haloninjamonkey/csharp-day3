using System;
using library.Models;
//need a library
//need a class for books
namespace library
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.Clear();
            Library myLibrary = new Library("The Library!", "People of Boise", "Boise");
            System.Console.WriteLine(myLibrary.Name);
            Book hp = new Book("Harry Potter", "JK Rowling");
            Book lotr = new Book("The Hobbit", "Tolkein");
            Book narnia = new Book("The Last Battle", "CS Lewis", false);
            myLibrary.AddBook(hp);
            myLibrary.AddBook(lotr);
            myLibrary.AddBook(narnia);

            bool inLibrary = true;
            myLibrary.Greeting();
            while(inLibrary)
            {
                Console.ReadLine();
                Console.Clear();
                bool stayInLibrary = myLibrary.PrintDirectory();
                if(!stayInLibrary)
                {
                    inLibrary = false;
                    System.Console.WriteLine("Goodbye!");
                }
            }

        }
    }
}
