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
        // переделать под синглЧмоньк
        public MyDBContext() : base("name=DefaultConnection") { }
        public DbSet<Employee> Employees { get; set; } // сотрудники
        public DbSet<Position> Positions { get; set; } // должности
        public DbSet<ReportCard> ReportCards { get; set; } // табели
        public DbSet<Cow> Cows { get; set; } // коровы
        public DbSet<MilkCollection> MilkCollections { get; set; } // сборы молока
        public DbSet<Feed> Feeds { get; set; } // корма
        public DbSet<Feeding> Feeding { get; set; } // кормежка
        public DbSet<Product> Prosucts { get; set; } // товары
        public DbSet<Warehouse> Warehouses { get; set; } // склады
        public DbSet<ProductWarehouse> ProductWarehouses { get; set; } // склада продуктов
        public DbSet<FeedWarehouse> FeedWarehouses { get; set; } // склада корма
        public DbSet<Equipment> Equipments { get; set; } // оборудования
        public DbSet<Cheese> Cheeses { get; set; } // сыры
        public DbSet<Batch> Batches { get; set; } // партии
        public DbSet<BatchCheese> BatchCheeses { get; set; } // партии сыра
        public DbSet<Storage> Storages { get; set; } // хранилища
        public DbSet<UsedStorage> UsedStorages { get; set; } // занятые хранилища
        public DbSet<ProcessingStep> ProcessingSteps { get; set; } // этап обработок
        public DbSet<FeedingEmployee> FeedingEmployees { get; set; } // сотрудники кормежки

    }
}
