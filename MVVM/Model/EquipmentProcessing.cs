using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Обработка_оборудованием")]
    public class EquipmentProcessing
    {
        [Column("ID_ОО")]
        public int ID { get; set; }

        [Column("FK_Этап_обработки_партии_сыра")]
        public int ProcessingStepBatchCheeseFK { get; set; }

        [Column("FK_Оборудование")]
        public int EquipmentFK { get; set; }

        [Column("FK_Сотрудник")]
        public int EmployeeFK { get; set; }
    }
}
