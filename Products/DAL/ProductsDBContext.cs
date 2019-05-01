using Products.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Configuration;
using System.Runtime.Remoting.Contexts;
using System.Linq;
using System.Web;

namespace Products.DAL
{
    public class ProductsDBContext : DbContext
    {
        public ProductsDBContext()
        
            :base("name=ProductsDBContext")
        {

        }

        public DbSet<Product> Products { get; set; }
        
    }
}