using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Этап_обработки")]
    public class ProcessingStep
    {
        [Column("ID_ЭО")]
        public int ID { get; set; }

        [Column("Этап_обработки")]
        public string Step { get; set; }

        [Column("Дата_начала_обработки")]
        public DateTime ProcessingStartDate { get; set; }

        [Column("FK_Партия_сыра")]
        public int BatchCheeseFK { get; set; }

        [Column("FK_Оборудование_сотрудника")]
        public int EmployeeEquipmentFK { get; set; }

        [ForeignKey(nameof(EmployeeEquipmentFK))]
        public virtual EmployeeEquipment EmployeeEquipment { get; set; }

        [ForeignKey(nameof(BatchCheeseFK))]
        public virtual BatchCheese BatchCheese { get; set; }
    }
}
