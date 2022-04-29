using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cheese_factory.MVVM.Model
{
    [Table("Сотрудник")]
    public class Employee
    {
        [Column("ID_Сотрудник")]
        public int ID { get; set; }

        [Column("Номер_телефона")]
        public string PhoneNumber { get; set; }

        [Column("Дата_рождения")]
        public DateTime DateBirth { get; set; }

        [Column("Фамилия")]
        public string Surname { get; set; }

        [Column("Имя")]
        public string Name { get; set; }

        [Column("Отчество")]
        public string LastName { get; set; }
        
       // public virtual List<ReportCard>? ReportCards { get; set; } 
    }
}
