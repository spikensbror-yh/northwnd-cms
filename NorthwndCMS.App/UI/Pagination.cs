using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwndCMS.App.UI
{
    public class Pagination<T>
    {
        public IEnumerable<T> Entities { get; private set; }
        public int PerPage { get; set; }
        public int Pages { get { return (int)Math.Ceiling((double)Entities.Count() / PerPage); } }
        public int Page { get; set; }

        public Pagination(IEnumerable<T> entities, int page = 1, int perPage = 10)
        {
            Entities = entities;
            Page = page;
            PerPage = perPage;
        }

        public IEnumerable<T> Next()
        {
            return AtPage(Page + 1);
        }

        public IEnumerable<T> Current()
        {
            return AtPage(Page);
        }

        public IEnumerable<T> Previous()
        {
            return AtPage(Page - 1);
        }

        public IEnumerable<T> AtPage(int page)
        {
            Page = (page < 1) ? 1 : (page > Pages) ? Pages : page;
            return Entities.Skip(PerPage * (Page - 1)).Take(PerPage);
        }

        public override string ToString()
        {
            return string.Format("{0} / {1}", Page, Pages);
        }
    }
}
