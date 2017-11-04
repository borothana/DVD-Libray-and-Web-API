using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDWebAPIModels;

namespace DVDWEBAPIData.EF
{
    public class DvdContext:DbContext
    {
        public DvdContext():base("DvdLibrary")
        {
            
        }

        public DbSet<Rating> Rating { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Dvd> Dvd { get; set; }
    }
}
