using System.ComponentModel.DataAnnotations.Schema;

namespace Cheese_factory.MVVM.Model
{
    [Table("Табель")]
    public class ReportCard
    {
        [Column("ID_Табель")]
        public int ID { get; set; }

        [Column("Оклад")]
        public int Salary { get; set; }

        [Column("FK_Сотрудник")]
        public int EmployeeFK { get; set; }        

        [Column("FK_Должность")]
        public int PositionFK { get; set; }

        [ForeignKey("EmployeeFK")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("PositionFK")]
        public virtual Position Position { get; set; }
    }
}
