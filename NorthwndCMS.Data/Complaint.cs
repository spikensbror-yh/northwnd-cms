using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwndCMS.Data
{
    [Table(Name = "Complaints")]
    public class Complaint
    {
        #region Columns

        [Column(Name = "ComplaintID", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int Id { get; set; }

        [Column(Name = "OrderID")]
        public int OrderId { get; set; }

        [Column(Name = "CauseID")]
        public int CauseId { get; set; }

        [Column(Name = "ComplaintDate")]
        public DateTime? ComplaintDate { get; set; }

        [Column(Name = "WorkCompHours")]
        public decimal WorkCompHours { get; set; }

        [Column(Name = "Created")]
        public DateTime Created { get; set; }

        [Column(Name = "RegByEmployeeID")]
        public int RegByEmployeeId { get; set; }

        [Column(Name = "FinishedDate")]
        public DateTime? FinishedDate { get; set; }

        #endregion

        #region Associations

        private EntityRef<Order> _Order = new EntityRef<Order>();
        private EntityRef<Employee> _Employee = new EntityRef<Employee>();

        [Association(Name = "FK_Complaints_Orders", IsForeignKey = true, Storage = "_Order", ThisKey = "OrderId")]
        public Order Order
        {
            get { return _Order.Entity; }
            set { _Order.Entity = value; }
        }

        // TODO: ComplaintCause association.

        [Association(Name = "FK_Complaints_Employees", IsForeignKey = true, Storage = "_Employee", ThisKey = "RegByEmployeeId")]
        public Employee Employee
        {
            get { return _Employee.Entity; }
            set { _Employee.Entity = value; }
        }

        #endregion
    }
}
