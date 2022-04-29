using System.ComponentModel.DataAnnotations.Schema;

namespace Cheese_factory.MVVM.Model
{
    [Table("Должность")]
    public class Position
    {
        [Column("ID_Должность")]
        public int ID { get; set; }

        [Column("Должность")]
        public string JobTitle { get; set; }
    }
}
