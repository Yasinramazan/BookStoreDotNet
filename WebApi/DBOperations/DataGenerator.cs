using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void initialize(IServiceProvider serviceProvider)
        {
            using(var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
            {
               if(context.Books.Any())
               {
                   return;
               } 
               context.Books.AddRange
               (
                    new Book
                    {
                        //Id=1,
                        Title="Strateji",
                        GenreId=1,
                        SayfaSayisi=210,
                        YayinTarihi= new DateTime(2010,05,01)
                    },
                    new Book
                    {
                        //Id=2,
                        Title="Inanc ve Iktidar",
                        GenreId=3,
                        SayfaSayisi=185,
                        YayinTarihi= new DateTime(1997,08,23)
                    },
                    new Book
                    {
                        //Id=3,
                        Title="de Bello Gallica",
                        GenreId=2,
                        SayfaSayisi=120,
                        YayinTarihi= new DateTime(51,03,09)
                    }
               );

               context.SaveChanges();
            }
        }
    }
}