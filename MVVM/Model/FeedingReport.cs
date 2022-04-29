using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Отчет_кормления")]
    class FeedingReport
    {
        [Column("ID_Отчет_кормления")]
        public int ID { get; set; }


        [Column("FK_Корм")]
        public int FeedFK { get; set; }


        [Column("Дата_кормления")]
        public DateTime FeedingDate { get; set; }


        [Column("Количество_корма")]
        public int CountFeed { get; set; }


        [ForeignKey(nameof(FeedFK))]
        public Feed Feed { get; set; }

    }
}
