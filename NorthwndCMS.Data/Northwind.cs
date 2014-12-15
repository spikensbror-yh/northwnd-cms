using System;
using System.Data.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace NorthwndCMS.Data
{
    [Database]
    public class Northwind : DataContext
    {
        #region Tables

        public Table<Order> Orders;
        public Table<OrderDetail> OrderDetails;
        public Table<Employee> Employees;
        public Table<Complaint> Complaints;

        #endregion

        #region Construct

        public Northwind(string connection) : base(connection) { }

        #endregion
    }
}
