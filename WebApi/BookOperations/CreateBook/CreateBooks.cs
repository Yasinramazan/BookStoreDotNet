using System.Collections.Generic;
using System.Linq;
using System.IO;
using WebApi.DBOperations;
using WebApi.Common;
using System;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBooks
    {
        private readonly BookStoreDBContext _dbContext;

        public CreateBookModel Model { get; set; }
        public CreateBooks(BookStoreDBContext dbContext)
        {
            this._dbContext=dbContext;
        }

        public void handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Title==Model.title);
            if(book is not null)
                throw new InvalidOperationException("Kitap zaten mevcut.");
                
            book = new Book();    
            book.Title=Model.title;
            book.GenreId=Model.GenreID;
            book.SayfaSayisi=Model.sayfaSayisi;
            book.YayinTarihi=Model.publishDate;
            
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
    }

    public class CreateBookModel
    {
        public string title { get; set; }
        public int sayfaSayisi { get; set; }
        public DateTime publishDate { get; set; }
        public int GenreID { get; set; }
    }
}