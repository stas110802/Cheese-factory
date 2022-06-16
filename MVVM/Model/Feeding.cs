using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Кормежка")]
    public class Feeding
    {
        [Column("ID_Кормежка")]
        public int ID { get; set; }

        [Column("FK_Корм")]
        public int FeedFK { get; set; }

        [Column("Дата_кормления")]
        public DateTime FeedingDate { get; set; }

        [Column("Количество_корма_порции")]
        public int CountFeed { get; set; }

        [Column("Всего_потрачено_корма")]
        public int TotalCountFeed { get; set; }

        //  

        [ForeignKey(nameof(FeedFK))]
        public Feed Feed { get; set; }
    }
}
