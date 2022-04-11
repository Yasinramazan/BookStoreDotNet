using System.Collections.Generic;
using System.Linq;
using System.IO;
using WebApi.DBOperations;
using WebApi.Common;
using System;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBooks
    {
        private readonly BookStoreDBContext _dbContext;
        public int Id{get; set;}
        public UpdateModel model{get; set;}
        
        public UpdateBooks(BookStoreDBContext dbcontext)
        {
            this._dbContext=dbcontext;
        }

        public void handle()
        {
            var book = _dbContext.Books.SingleOrDefault(i=>i.Id==Id);

            if(book is null)
                throw new InvalidOperationException("Kitap bulunamadi.");

            
            book.GenreId= model.GenreID != default ? model.GenreID : book.GenreId;
            book.SayfaSayisi=model.sayfaSayisi!=default ? model.sayfaSayisi : book.SayfaSayisi;
            book.Title =model.title != default ? model.title : book.Title;
            book.YayinTarihi = model.publishDate != default ? model.publishDate : book.YayinTarihi;

            _dbContext.SaveChanges();
                    
        }
    }

    public class UpdateModel
    {
        public string title { get; set; }
        public int sayfaSayisi { get; set; }
        public DateTime publishDate { get; set; }
        public int GenreID { get; set; }
    }
}