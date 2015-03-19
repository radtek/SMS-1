using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Web.Framework.Helpers
{
    public class GridPagingHelper<T>
    {
        //private Func<List<T>> m_GetDataForPaging;
        //private string m_FilterField;

        //public GridPagingHelper(Func<List<T>> repository, string filterField)
        //{
        //    m_GetDataForPaging = repository;
        //    m_FilterField = filterField;
        //}

        //public Paging<T> GetPaging(StoreRequestParameters parameters)
        //{
        //    return GetPaging(parameters.Start, parameters.Limit, parameters.SimpleSort, parameters.SimpleSortDirection, null, parameters.Query);
        //}

        //public Paging<T> GetPaging(int start, int limit, string sort, SortDirection dir, string filter, string query)
        //{
        //    List<T> dataList = m_GetDataForPaging.Invoke();

        //    if (!string.IsNullOrEmpty(filter) && filter != "*")
        //    {
        //        dataList.RemoveAll(Company => !TypeDescriptor.GetProperties(Company)[m_FilterField].GetValue(Company).ToString().ToLower().Contains(filter.ToLower()));
        //    }

        //    if (!string.IsNullOrEmpty(query) && query != "*")
        //    {
        //        dataList.RemoveAll(Company => !TypeDescriptor.GetProperties(Company)[m_FilterField].GetValue(Company).ToString().ToLower().Contains(query.ToLower()));
        //    }

        //    if (!string.IsNullOrEmpty(sort))
        //    {
        //        dataList.Sort(delegate(T x, T y)
        //        {
        //            object a;
        //            object b;

        //            int direction = dir == SortDirection.DESC ? -1 : 1;

        //            a = x.GetType().GetProperty(sort).GetValue(x, null);
        //            b = y.GetType().GetProperty(sort).GetValue(y, null);

        //            return CaseInsensitiveComparer.Default.Compare(a, b) * direction;
        //        });
        //    }

        //    if ((start + limit) > dataList.Count)
        //    {
        //        limit = dataList.Count - start;
        //    }

        //    List<T> rangeCompanys = (start < 0 || limit < 0) ? dataList : dataList.GetRange(start, limit);

        //    return new Paging<T>(rangeCompanys, dataList.Count);
        //}
    }
}
