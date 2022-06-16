using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Cотрудники_кормежки")]
    public class FeedingEmployee
    {
        [Column("ID_Cотрудники_кормежки")]
        public int ID { get; set; }


        [Column("FK_Сотрудник")]
        public int EmployeeFK { get; set; }

        [Column("FK_Кормежка")]
        public int FeedingFK { get; set; }


        [ForeignKey(nameof(EmployeeFK))]
        public virtual Employee Employee { get; set; }

        [ForeignKey(nameof(FeedingFK))]
        public virtual Feeding Feeding { get; set; }
    }
}
