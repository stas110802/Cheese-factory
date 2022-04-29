using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cheese_factory.MVVM.Model
{
    [Table("Корова")]
    public class Cow
    {
        [Column("ID_Корова")]
        public int ID { get; set; }

        [Column("Уникальный_номер")]
        public int UID { get; set; }

        [Column("Вес")]
        public int Weight { get; set; }

        [Column("Дата_рождения")]
        public DateTime DateBirth { get; set; }
    }
}
