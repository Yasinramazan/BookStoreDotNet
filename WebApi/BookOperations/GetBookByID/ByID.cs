using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;

namespace WebApi.BookOperations.GetBookByID
{
    public class GetByID
    {
        private readonly BookStoreDBContext _dbContext;
        public ByIDModel model;
        public int Id{get; set;}
        public GetByID(BookStoreDBContext dbContext)
        {
            this._dbContext=dbContext;
        }

        public ByIDModel handle()
        {
            var book = _dbContext.Books.SingleOrDefault(i=>i.Id==Id);

            if(book is null)
                throw new InvalidOperationException("Kitap Bulunamadi.");

            model = new ByIDModel();
            model.GenreID=((GenreEnum)book.GenreId).ToString();
            model.PublishDate=book.YayinTarihi;
            model.SayfaSayisi=book.SayfaSayisi;
            model.Title=book.Title;
            return model;
        }
    }

    public class ByIDModel
    {
        public string Title { get; set; }
        public string GenreID { get; set; }
        public int SayfaSayisi { get; set; } 
        public DateTime PublishDate { get; set; }
    }
}