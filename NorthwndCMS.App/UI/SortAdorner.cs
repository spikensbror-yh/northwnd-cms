using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace NorthwndCMS.App.UI
{
    class SortAdorner : Adorner
    {
        #region Constants

        private const Geometry ASCENDING = Geometry.Parse("M 0,0 L 10,0 L 5,5 Z");
        private const Geometry DESCENDING = Geometry.Parse("M 0,5 L 10,5 L 5,0 Z");

        #endregion

        #region Properties

        public ListSortDirection Direction { get; private set; }

        #endregion

        #region Construct

        public SortAdorner(UIElement element, ListSortDirection direction) : base(element)
        {
            Direction = direction;
        }

        #endregion

        #region Method Overrides

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (AdornedElement.RenderSize.Width < 20)
            {
                return;
            }

            drawingContext.PushTransform(
                new TranslateTransform(
                    AdornedElement.RenderSize.Width - 15,
                    (AdornedElement.RenderSize.Height - 5) / 2
                )
            );

            drawingContext.DrawGeometry(
                Brushes.Black,
                null,
                Direction == ListSortDirection.Ascending ? ASCENDING : DESCENDING
            );

            drawingContext.Pop();
        }

        #endregion
    }
}
