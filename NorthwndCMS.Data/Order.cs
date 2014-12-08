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
        #region Columns

        [Column(Name = "OrderID", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int Id { get; set; }

        [Column(Name = "CustomerID")]
        public string CustomerId { get; set; }

        [Column(Name = "EmployeeID")]
        private int? _EmployeeId { get; set; }

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

        private EntityRef<Employee> _Employee = new EntityRef<Employee>();

        [Association(Name = "FK_Orders_Employees", IsForeignKey = true, Storage = "_Employee", ThisKey = "_EmployeeId")]
        public Employee Employee
        {
            get { return _Employee.Entity; }
            set { _Employee.Entity = value; }
        }

        #endregion
    }
}
