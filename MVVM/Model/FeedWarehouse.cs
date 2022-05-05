using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Склад_Корма")]
    public class FeedWarehouse
    {
        [Column("ID_СК")]
        public int ID { get; set; }

        [Column("Количество")]
        public int Count { get; set; }

        [Column("FK_Склад")]
        public int WarehouseFK { get; set; }

        [Column("FK_Корм")]
        public int FeedFK { get; set; }

        [ForeignKey(nameof(WarehouseFK))]
        public virtual Warehouse Warehouse { get; set; }

        [ForeignKey(nameof(FeedFK))]
        public virtual Feed Feed { get; set; }
    }
}
