using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwndCMS.Data
{
    [Table(Name = "Employees")]
    public class Employee
    {
        #region Properties

        public string FullName { get { return FirstName + " " + LastName; } }

        #endregion

        #region Columns

        [Column(Name = "EmployeeID", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int Id { get; set; }

        [Column(Name = "LastName")]
        public string LastName { get; set; }

        [Column(Name = "FirstName")]
        public string FirstName { get; set; }

        [Column(Name = "Title")]
        public string Title { get; set; }

        [Column(Name = "TitleOfCourtesy")]
        public string TitleOfCourtesy { get; set; }

        [Column(Name = "BirthDate")]
        public DateTime? BirthDate { get; set; }

        [Column(Name = "HireDate")]
        public DateTime? HireDate { get; set; }

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

        [Column(Name = "HomePhone")]
        public string HomePhone { get; set; }

        [Column(Name = "Extension")]
        public string Extension { get; set; }

        [Column(Name = "Photo")]
        public Binary Photo { get; set; }

        [Column(Name = "Notes")]
        public string Notes { get; set; }

        [Column(Name = "ReportsTo")]
        public int? ReportsToId { get; set; }

        [Column(Name = "PhotoPath")]
        public string PhotoPath { get; set; }

        #endregion

        #region Associations

        private EntityRef<Employee> _ReportsTo = new EntityRef<Employee>();
        private EntitySet<Order> _Orders = new EntitySet<Order>();

        [Association(Name = "FK_Employees_Employees", IsForeignKey = true, Storage = "_ReportsTo", ThisKey = "ReportsToId")]
        public Employee ReportsTo
        {
            get { return _ReportsTo.Entity; }
            set { _ReportsTo.Entity = value; }
        }

        [Association(Name = "FK_Orders_Employees", Storage = "_Orders", OtherKey = "EmployeeId")]
        public EntitySet<Order> Orders
        {
            get { return _Orders; }
            set { _Orders.Assign(value); }
        }

        #endregion
    }
}
