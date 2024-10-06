using DatabaseManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class Context : DbContext
    {
        public DbSet<Report> Reports { get; set; }
    }
}
