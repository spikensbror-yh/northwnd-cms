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
        private readonly static Geometry _Ascending = Geometry.Parse("M 0,0 L 10,0 L 5,5 Z");
        private readonly static Geometry _Descending = Geometry.Parse("M 0,5 L 10,5 L 5,0 Z");

        public ListSortDirection Direction { get; private set; }

        public SortAdorner(UIElement element, ListSortDirection direction) : base(element)
        {
            Direction = direction;
        }

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
                Direction == ListSortDirection.Ascending ? _Ascending : _Descending
            );

            drawingContext.Pop();
        }
    }
}
