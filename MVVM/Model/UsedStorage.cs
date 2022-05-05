using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Занятое_хранилище")]
    public class UsedStorage
    {
        [Column("ID_ЗХ")]
        public int ID { get; set; }

        [Column("Дата_поступления")]
        public DateTime ReceiptDate { get; set; }

        [Column("FK_Хранилище")]
        public int StorageFK { get; set; }

        [Column("FK_Партия_сыра")]
        public int BatchCheeseFK { get; set; }

        [ForeignKey(nameof(StorageFK))]
        public virtual Storage Storage { get; set; }

        [ForeignKey(nameof(BatchCheeseFK))]
        public virtual BatchCheese BatchCheese { get; set; }
    }
}
