using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwndCMS.Data
{
    [Table(Name = "Products")]
    public class Product
    {
        #region Columns

        [Column(Name = "ProductID", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int ProductId { get; set; }

        [Column(Name = "ProductName")]
        public string ProductName { get; set; }

        [Column(Name = "SupplierID")]
        public int? SupplierId { get; set; }

        [Column(Name = "CategoryID")]
        public int? CategoryId { get; set; }

        [Column(Name = "QuantityPerUnit")]
        public string QuantityPerUnit { get; set; }

        [Column(Name = "UnitPrice")]
        public decimal UnitPrice { get; set; }

        [Column(Name = "UnitsInStock")]
        public short UnitsInStock { get; set; }

        [Column(Name = "UnitsOnOrder")]
        public short UnitsOnOrder { get; set; }

        [Column(Name = "ReorderLevel")]
        public short ReorderLevel { get; set; }

        [Column(Name = "Discontinued")]
        public bool Discontinued { get; set; }

        #endregion

        #region Associations

        private EntitySet<OrderDetail> _OrderDetails = new EntitySet<OrderDetail>();

        // TODO: Supplier association.
        // TODO: ProductCategory association.

        [Association(Name = "FK_Order_Details_Products", Storage = "_OrderDetails", OtherKey = "ProductId")]
        public EntitySet<OrderDetail> OrderDetails
        {
            get { return _OrderDetails; }
            set { _OrderDetails.Assign(value); }
        }

        #endregion
    }
}
