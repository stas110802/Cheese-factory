using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Товар")]
    public class Product
    {
        [Column("ID_Товар")]
        public int ID { get; set; }

        [Column("Название")]
        public string Name { get; set; }

        [Column("Производитель")]
        public string Manufacturer { get; set; }

        [Column("Цена")]
        public float Price { get; set; }
    }
}
