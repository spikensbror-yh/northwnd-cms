using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace NorthwndCMS.App.UI
{
    public partial class ListWindow : Window
    {
        public ListView List { get; protected set; }
        private GridViewColumnHeader _ActiveColumn = null;
        private SortAdorner _ColumnAdorner = null;

        protected void List_Sort(object sender, RoutedEventArgs e)
        {
            if (List == null)
            {
                throw new Exception("No list has been set to be handled by the ListWindow base class.");
            }

            GridViewColumnHeader column = sender as GridViewColumnHeader;
            string field = column.Tag as string;

            if (_ActiveColumn != null)
            {
                AdornerLayer.GetAdornerLayer(_ActiveColumn).Remove(_ColumnAdorner);
                List.Items.SortDescriptions.Clear();
            }

            if (_ActiveColumn == column && _ColumnAdorner.Direction == ListSortDirection.Descending)
            {
                _ActiveColumn = null;
                _ColumnAdorner = null;

                return;
            }

            ListSortDirection direction = (_ActiveColumn == column && _ColumnAdorner.Direction == ListSortDirection.Ascending)
                ? ListSortDirection.Descending
                : ListSortDirection.Ascending;
            _ActiveColumn = column;
            _ColumnAdorner = new SortAdorner(_ActiveColumn, direction);

            AdornerLayer.GetAdornerLayer(_ActiveColumn).Add(_ColumnAdorner);
            List.Items.SortDescriptions.Add(new SortDescription(field, direction));
        }
    }
}
