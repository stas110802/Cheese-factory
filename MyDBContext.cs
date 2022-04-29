using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cheese_factory.MVVM.Model;

namespace Cheese_factory
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("name=DefaultConnection") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ReportCard> ReportCards { get; set; }
        public DbSet<Cow> Cows { get; set; }
        public DbSet<WorkingCouple> WorkingCouples { get; set; }
        public DbSet<MilkCollection> MilkCollections { get; set; }
    }
}
