using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Партия_сыра")]
    public class BatchCheese
    {
        [Column("ID_ПС")]
        public int ID { get; set; }

        [Column("Количество_штук")]
        public int Count { get; set; }

        [Column("FK_Партия")]
        public int BatchFK { get; set; }

        [Column("FK_Сыр")]
        public int CheeseFK { get; set; }

        [ForeignKey(nameof(BatchFK))]
        public virtual Batch Batch { get; set; }

        [ForeignKey(nameof(CheeseFK))]
        public virtual Cheese Cheese { get; set; }
    }
}
