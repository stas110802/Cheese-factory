using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Хранилище")]
    public class Storage
    {
        [Column("ID_Хранилище")]
        public int ID { get; set; }

        [Column("Площадь")]
        public string FloorArea { get; set; }
    }
}
