using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models
{
    public class ZenithSocietyContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
