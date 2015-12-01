﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Books.Models;

namespace Books.Controllers
{
    public class BooksController : Controller
    {
        private BooksContext db = new BooksContext();

        // GET: Books
        public async Task<ActionResult> Index()
        {
            var grouped = new BookListViewModel(GetBooks());
            return View(grouped);
            //return View(await db.Books.ToListAsync());
        }

        private List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book
                {
                    Isbn = 1,
                    Title = "Apple",
                    Description = "About apples"
                },
                new Book
                {
                    Isbn = 3,
                    Title = "Animal",
                    Description = "About animals"
                },
                new Book
                {
                    Isbn = 5,
                    Title = "Acorn",
                    Description = "About acorns"
                },
                new Book
                {
                    Isbn = 2,
                    Title = "Banana",
                    Description = "About bananas"
                },
                 new Book
                {
                    Isbn = 4,
                    Title = "Zebra",
                    Description = "About zebras"
                },
            };
        }

        // GET: Books/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Isbn,Title,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
