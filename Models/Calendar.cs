using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ReapersTest3.Models
{
    public class CalendarEntry
    {
        [Key]
        public int Id { get; set; }
        public string EntryName { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }

    public class Calendar : DbContext
    {
        public DbSet<CalendarEntry> calenderEntries { get; set; }

        private List<CalendarMonth> months;
        public List<CalendarMonth> Months
        {
            get
            {
                if (months == null) getMonths();
                return months;
            }
            set
            {
                months = value;
                bool changed = false;
                foreach (var mon in months)
                {
                    foreach (CalendarEntry ce in mon.MonthEntries)
                    {
                        if (!calenderEntries.Contains(ce))
                        {
                            calenderEntries.Add(ce);
                            changed = true;
                        }
                    }
                }
                if (changed) this.SaveChanges();
            }
        }

        private void getMonths()
        {
            months = new List<CalendarMonth>();
            foreach (CalendarEntry ce in calenderEntries.Where(c=>c.Date >= DateTime.Today))
            {
                CalendarMonth cm = months.FirstOrDefault(i => i.Year == ce.Date.Year && i.Month == ce.Date.Month);
                if (cm == null)
                {
                    cm = new CalendarMonth(ce.Date.Year, ce.Date.Month);
                    months.Add(cm);
                }
                cm.MonthEntries.Add(ce);
            }
        }
    }

    public class CalendarMonth
    {
        public CalendarMonth(int year, int month)
        {
            Year = year;
            Month = month;
            MonthEntries = new List<CalendarEntry>();
        }
        public int Year { get; set; }
        public int Month { get; set; }
        public List<CalendarEntry> MonthEntries { get; set; }

        public List<CalendarEntry> OrderedMonthEntries { get { return MonthEntries.OrderBy(d => d.Date).ToList(); } }

        public string monthDisplay
        {
            get
            {
                if(MonthEntries.Count == 0) return "No Entries";
                string s = Month.ToString() + " / " + Year.ToString();

                List<CalendarEntry> list = MonthEntries.OrderBy(d => d.Date).ToList();
                foreach (var entry in list)
                {
                    s += entry.EntryName + "<br/>" + entry.Date.ToShortDateString() + "<br/>" + entry.Location + "<br/>" + "<br/>" + "<br/>";
                }

                return s;
            }
        }
    }
}