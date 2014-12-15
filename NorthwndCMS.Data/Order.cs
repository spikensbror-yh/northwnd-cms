using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwndCMS.Data
{
    [Table(Name = "Orders")]
    public class Order
    {
        #region Properties

        public decimal Price
        {
            get { return OrderDetails.Sum(od => od.Price); }
        }

        public string FormattedPrice
        {
            get { return Price.ToString("C"); }
        }

        #endregion

        #region Columns

        [Column(Name = "OrderID", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int Id { get; set; }

        [Column(Name = "CustomerID")]
        public string CustomerId { get; set; }

        [Column(Name = "EmployeeID")]
        public int? EmployeeId { get; set; }

        [Column(Name = "OrderDate")]
        public DateTime? OrderDate { get; set; }

        [Column(Name = "RequiredDate")]
        public DateTime? RequiredDate { get; set; }

        [Column(Name = "ShippedDate")]
        public DateTime? ShippedDate { get; set; }

        [Column(Name = "ShipVia")]
        public int? ShipVia { get; set; }

        [Column(Name = "Freight")]
        public decimal Freight { get; set; }

        [Column(Name = "ShipName")]
        public string ShipName { get; set; }

        [Column(Name = "ShipAddress")]
        public string ShipAddress { get; set; }

        [Column(Name = "ShipCity")]
        public string ShipCity { get; set; }

        [Column(Name = "ShipRegion")]
        public string ShipRegion { get; set; }

        [Column(Name = "ShipPostalCode")]
        public string ShipPostalCode { get; set; }

        [Column(Name = "ShipCountry")]
        public string ShipCountry { get; set; }

        #endregion

        #region Associations

        private EntityRef<Customer> _Customer = new EntityRef<Customer>();
        private EntityRef<Employee> _Employee = new EntityRef<Employee>();
        private EntitySet<OrderDetail> _OrderDetails = new EntitySet<OrderDetail>();
        private EntitySet<Complaint> _Complaints = new EntitySet<Complaint>();

        [Association(Name = "FK_Orders_Customers", IsForeignKey = true, Storage = "_Customer", ThisKey = "CustomerId")]
        public Customer Customer
        {
            get { return _Customer.Entity; }
            set { _Customer.Entity = value; }
        }

        [Association(Name = "FK_Orders_Employees", IsForeignKey = true, Storage = "_Employee", ThisKey = "EmployeeId")]
        public Employee Employee
        {
            get { return _Employee.Entity; }
            set { _Employee.Entity = value; }
        }

        [Association(Name = "FK_Order_Details_Orders", Storage = "_OrderDetails", OtherKey = "OrderId", DeleteRule = "CASCADE")]
        public EntitySet<OrderDetail> OrderDetails
        {
            get { return _OrderDetails; }
            set { _OrderDetails.Assign(value); }
        }

        [Association(Name = "FK_Complaints_Orders", Storage = "_Complaints", OtherKey = "OrderId", DeleteRule = "CASCADE")]
        public EntitySet<Complaint> Complaints
        {
            get { return _Complaints; }
            set { _Complaints.Assign(value); }
        }

        #endregion
    }
}
