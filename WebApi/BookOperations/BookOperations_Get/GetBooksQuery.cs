using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using WebApi.DBOperations;
using WebApi.Common;

namespace WebApi.BookOperations.BookOperations_Get
{
    public class GetBooksQuery
    {
        private readonly BookStoreDBContext _dbContext;
        public GetBooksQuery(BookStoreDBContext dbContext)
        {
            this._dbContext=dbContext;
      
        }

        public List<BooksViewModel> handle()
        {
            var BookList = _dbContext.Books.OrderBy(x=>x.Id).ToList<Book>();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach(var book in BookList)
            {
                vm.Add(new BooksViewModel()
                {
                    title=book.Title,
                    GenreID=((GenreEnum)book.GenreId).ToString(),
                    publishDate=book.YayinTarihi.Date.ToString("dd/MM/yy"),
                    sayfaSayisi=book.SayfaSayisi
                }
                );
                
            }
            return vm;
        }

        
    }

    public class BooksViewModel
    {
        public string title { get; set; }
        public int sayfaSayisi { get; set; }
        public string publishDate { get; set; }
        public string GenreID { get; set; }     
    }

}