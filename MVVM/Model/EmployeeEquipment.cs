using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Оборудование_сотрудника")]
    public class EmployeeEquipment
    {
        [Column("ID_ОС")]
        public int ID { get; set; }

        [Column("FK_Оборудование")]
        public int EquipmentFK { get; set; }

        [Column("FK_Сотрудник")]
        public int EmployeeFK { get; set; }

        [ForeignKey(nameof(EquipmentFK))]
        public virtual Equipment Equipment { get; set; }

        [ForeignKey(nameof(EmployeeFK))]
        public virtual Employee Employee { get; set; }
    }
}
