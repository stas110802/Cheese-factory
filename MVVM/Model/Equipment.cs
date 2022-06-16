using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Оборудование")]
    public class Equipment
    {
        [Column("ID_Оборудование")]
        public int ID { get; set; }

        [Column("Устройство")]
        public string Name { get; set; }

        [Column("Модель")]
        public string Model { get; set; }

        [Column("Производитель")]
        public string Manufacturer { get; set; }
    }
}
