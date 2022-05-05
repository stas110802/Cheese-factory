using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Партия")]
    public class Batch
    {
        [Column("ID_Партия")]
        public int ID { get; set; }

        [Column("Уникальный_номер")]
        public int UIDConsignment { get; set; }
    }
}
