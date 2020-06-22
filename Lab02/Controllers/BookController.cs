using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab02.Models;
using System.Data.Entity.Core.Objects;
using System.Diagnostics.Eventing.Reader;
using System.Web.UI.WebControls;
using System.Net.Http.Headers;
using System.Drawing;
namespace Lab02.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
    
        public string HelloTeacher(string university)
    {
            return "Hello"+university;
    } 
    public ActionResult ListBook()
    {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTML5 & CSS3 Responsive web Design cookbook - Author Name Book 2");
            books.Add("Professional ASP.NET MVC5 - Author Name Book 3");
            ViewBag.Books = books;
            return View();
    }

        public ActionResult ListBookModel()
    {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/hinh-nen-sach-4.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 Responsive web Design cookbook", "Author Name Book 2", "/Content/Images/image2 (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/Images/image2.jpg"));
            return View(books);
    }
        public ActionResult EditBook(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/hinh-nen-sach-4.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 Responsive web Design cookbook", "Author Name Book 2", "/Content/Images/image2 (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/Images/image2.jpg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View( book);
        }

        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBookcomfirm(int id,string Title,string Author,string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/hinh-nen-sach-4.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 Responsive web Design cookbook", "Author Name Book 2", "/Content/Images/image2 (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/Images/image2.jpg"));          
            if(id==null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }
            return View("ListBookModel", books);
        }
  
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBookComfirm([Bind(Include ="id ,Title ,Author ,ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/hinh-nen-sach-4.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 Responsive web Design cookbook", "Author Name Book 2", "/Content/Images/image2 (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/Images/image2.jpg"));
            try
            {
                if(ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }
        public ActionResult DeleteBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/hinh-nen-sach-4.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 Responsive web Design cookbook", "Author Name Book 2", "/Content/Images/image2 (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/Images/image2.jpg"));
            Book book = new Book();
            foreach (Book a in books)
            {
                if (a.Id == id)
                {
                    book = a;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("DeleteBook")]

        public ActionResult DeleteBook(int id,string Title,string Author,string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/hinh-nen-sach-4.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 Responsive web Design cookbook", "Author Name Book 2", "/Content/Images/image2 (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/Images/image2.jpg"));
            Book book = new Book();
            if (book == null)
                return HttpNotFound();
            foreach (Book a in books)
            {
                if (a.Id == id)
                {
                    a.Title = Title;
                    a.Author = Author;
                    a.ImageCover = ImageCover;
                    books.RemoveAt(a.Id - 1);
                    break;
                }
            }
            return View("ListBookModel", books);
        }
    }
 
}