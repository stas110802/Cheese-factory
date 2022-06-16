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
    }
}
