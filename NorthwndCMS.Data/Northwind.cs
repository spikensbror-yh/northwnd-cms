using System;
using System.Data.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwndCMS.Data
{
    public class Northwind : DataContext
    {
        #region Tables

        public Table<Order> Orders;
        public Table<Employee> Employees;

        #endregion

        #region Construct

        public Northwind(string connection) : base(connection) { }

        #endregion
    }
}
