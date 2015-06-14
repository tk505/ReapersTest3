using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReapersTest3.Models
{
    public class ImageGallery
    {
        public ImageGallery()
        {
            ImageList = new List<string>();
        }
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<string> ImageList { get; set; }
    }

    public class DbConnectionContext : DbContext
    {
        public DbConnectionContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges
            <DbConnectionContext>());
        }
        public DbSet<ImageGallery> ImageGallery { get; set; }
    }
}