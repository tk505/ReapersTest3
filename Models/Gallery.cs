using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ReapersTest3.Models
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }
    }

    public class DemoContext : DbContext
    {
        public DbSet<Gallery> gallery { get; set; }
    }

}