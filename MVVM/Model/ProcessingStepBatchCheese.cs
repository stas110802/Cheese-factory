using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Этап_обработки_партии_сыра")]
    public class ProcessingStepBatchCheese
    {
        [Column("ID_ЭОПС")]
        public int ID { get; set; }

        [Column("Дата_начала_обработки")]
        public DateTime ProcessingStartDate { get; set; }

        [Column("FK_Партия_сыра")]
        public int BatchCheeseFK { get; set; }

        [Column("FK_Этап_обработки")]
        public int ProcessingStepFK { get; set; }

        //[ForeignKey(nameof(BatchCheeseFK))]
        //public virtual BatchCheese BatchCheese { get; set; }
    }
}
