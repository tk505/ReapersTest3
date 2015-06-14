using ReapersTest3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReapersTest3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calendar()
        {
            ViewBag.Title = "Calendar";
            ViewBag.Message = "Your Calendar page";

            using (Calendar cal = new Calendar())
            {
                //var getAllEntries = cal.calenderEntries.ToList();
                //return View(getAllEntries);
                var getAllMonths = cal.Months.OrderBy(i => int.Parse(i.Year.ToString() + i.Month.ToString())).ToList();
                return View(getAllMonths);
            }

            //return View();
        }

        [HttpGet]
        public ActionResult AddCalEntry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCalEntry(string title, DateTime date, string location)
        {

            if (date != null)
            {
                using (Calendar cal = new Calendar())
                {
                    CalendarEntry entry = new CalendarEntry
                    {
                        EntryName = title,
                        Date = date,
                        Location = location
                    };
                    cal.calenderEntries.Add(entry);
                    cal.SaveChanges();
                }
            }
            return RedirectToAction("Calendar", "Home");
        }

        public ActionResult Gallery()
        {
            ViewBag.Title = "Gallery";
            ViewBag.Message = "Your Gallery page";

            using (DemoContext contextObj = new DemoContext())
            {
                var getAllImage = contextObj.gallery.ToList();
                return View(getAllImage);
            }

            //return View();
        }

        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(string ImagePath)
        {
            if (ImagePath != null)
            {
                //string pic = Path.GetFileName(ImagePath.FileName);
                //string path = Path.Combine(Server.MapPath("~/Images/"), pic);
                //ImagePath.SaveAs(path);
                using (DemoContext myContext = new DemoContext())
                {
                    Gallery galleryobj = new Gallery
                    {
                        ImagePath = ImagePath
                    };
                    myContext.gallery.Add(galleryobj);
                    myContext.SaveChanges();
                }
            }
            return RedirectToAction("Gallery", "Home");
        }

        [HttpGet]
        public ActionResult ClearGallery()
        {
            using (DemoContext myContext = new DemoContext())
            {
                var temp = myContext.gallery.ToList();
                foreach (Gallery gal in temp)
                {
                    myContext.gallery.Remove(gal);
                }
                myContext.SaveChanges();
            }
            return RedirectToAction("Gallery", "Home");
        }

        public ActionResult Forum()
        {
            ViewBag.Message = "Your Forum page";

            return View();
        }

        public ActionResult Venue()
        {
            ViewBag.Message = "Your Venue page";

            return View();
        }

        public ActionResult Store()
        {
            ViewBag.Message = "Your Store page";

            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.Message = "Your Blog Page";
            return View();
        }

        public ActionResult BuyTicket()
        {
            ViewBag.Message = "Bought Ticket";
            ApplicationUser AppUser;
            //ShopModel.EnterOrderHistory(AppUser, DateTime.Now, "product1", 23.42);

            return View();
        }
    }
}