using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Сыр")]
    public class Cheese
    {
        [Column("ID_Сыр")]
        public int ID { get; set; }

        [Column("Название")]
        public string Name { get; set; }

        [Column("Вид")]
        public string Type { get; set; }

        [Column("Процентное_соотношение")]
        public string Percentage { get; set; }

        [Column("Тип_пастеризации")]
        public string TypePasteurization { get; set; }
    }
}
