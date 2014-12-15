using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwndCMS.Data
{
    [Table(Name = "Order Details")]
    public class OrderDetail
    {
        #region Columns

        [Column(Name = "OrderID", IsPrimaryKey = true, IsDbGenerated = false)]
        public int OrderId { get; set; }

        [Column(Name = "ProductID", IsPrimaryKey = true, IsDbGenerated = false)]
        public int ProductId { get; set; }

        [Column(Name = "UnitPrice")]
        public decimal UnitPrice { get; set; }

        [Column(Name = "Quantity")]
        public short Quantity { get; set; }

        [Column(Name = "Discount")]
        public float Discount { get; set; }

        #endregion

        #region Associations

        private EntityRef<Order> _Order = new EntityRef<Order>();

        [Association(Name = "FK_Order_Details_Orders", IsForeignKey = true, Storage = "_Order", ThisKey = "OrderId")]
        public Order Order
        {
            get { return _Order.Entity; }
            set { _Order.Entity = value; }
        }

        // TODO: Product association.

        #endregion
    }
}
