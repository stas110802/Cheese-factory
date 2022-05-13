using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Склад")]
    public class Warehouse
    {
        [Column("ID_Склад")]
        public int ID { get; set; }

        [Column("Площадь")]
        public int FloorArea { get; set; }
    }
}
