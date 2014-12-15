using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwndCMS.Data
{
    [Table(Name = "Customers")]
    public class Customer
    {
        #region Columns

        [Column(Name = "CustomerID", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public string CustomerId { get; set; }

        [Column(Name = "CompanyName")]
        public string CompanyName { get; set; }

        [Column(Name = "ContactName")]
        public string ContactName { get; set; }

        [Column(Name = "ContactTitle")]
        public string ContactTitle { get; set; }

        [Column(Name = "Address")]
        public string Address { get; set; }

        [Column(Name = "City")]
        public string City { get; set; }

        [Column(Name = "Region")]
        public string Region { get; set; }

        [Column(Name = "PostalCode")]
        public string PostalCode { get; set; }

        [Column(Name = "Country")]
        public string Country { get; set; }

        [Column(Name = "Phone")]
        public string Phone { get; set; }

        [Column(Name = "Fax")]
        public string Fax { get; set; }

        #endregion

        #region Associations

        private EntitySet<Order> _Orders = new EntitySet<Order>();

        [Association(Name = "FK_Orders_Customers", Storage = "_Orders", OtherKey = "CustomerId")]
        public EntitySet<Order> Orders
        {
            get { return _Orders; }
            set { _Orders.Assign(value); }
        }

        #endregion
    }
}
