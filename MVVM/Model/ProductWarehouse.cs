using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.MVVM.Model
{
    [Table("Склад_Товара")]
    public class ProductWarehouse
    {
        [Column("ID_СТ")]
        public int ID { get; set; }

        [Column("FK_Склад")]
        public int WarehouseFK { get; set; }

        [Column("FK_Товар")]
        public int ProductFK { get; set; }

        [ForeignKey(nameof(WarehouseFK))]
        public virtual Warehouse Warehouse { get; set; }

        [ForeignKey(nameof(ProductFK))]
        public virtual Product Product { get; set; }
    }
}
