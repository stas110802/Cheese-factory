using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Корм")]
    public class Feed
    {
        [Column("ID_Корм ")]
        public int ID { get; set; }

        [Column("Название")]
        public string Name { get; set; }

        [Column("Производитель")]
        public string Manufacturer { get; set; }
    }
}
