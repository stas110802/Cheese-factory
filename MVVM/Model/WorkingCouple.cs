using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Рабочая_пара")]
    public class WorkingCouple
    {
        [Column("ID_Рабочая_пара")]
        public int ID { get; set; }

        [Column("FK_Сотрудник")]
        public int EmployeeFK { get; set; }

        [Column("FK_Корова")]
        public int CowFK { get; set; }

        [ForeignKey(nameof(EmployeeFK))]
        public virtual Employee Employee { get; set; }

        [ForeignKey(nameof(CowFK))]
        public virtual Cow Cow { get; set; }
    }
}
