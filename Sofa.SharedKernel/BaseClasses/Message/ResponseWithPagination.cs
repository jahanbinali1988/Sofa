using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.SharedKernel.BaseClasses.Message
{
    [JsonObject]
    public class ResponseWithPagination<T> : ResponseBase
    {
        public ResponseWithPagination(bool isSuccess, string message, IQueryable<T> source, int pageIndex, int pageSize, string orderBy, bool accending) : base(isSuccess, message)
        {
            var total = source.Count();
            this.TotalCount = total;
            this.TotalPages = total / pageSize;
            if (total % pageSize > 0)
                TotalPages++;
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;

            IEnumerable<T> temp;
            if (accending)
                temp = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().OrderBy(o => o.GetType().GetProperty(orderBy));
            else
                temp = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().OrderByDescending(o => o.GetType().GetProperty(orderBy));
            
            this.Result.AddRange(temp);
        }

        public ResponseWithPagination(bool isSuccess, string message, string errorMessage, IQueryable<T> source, int pageIndex, int pageSize, string orderBy, bool accending) : base(isSuccess, message, errorMessage)
        {
            var total = source.Count();
            this.TotalCount = total;
            this.TotalPages = total / pageSize;
            if (total % pageSize > 0)
                TotalPages++;
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;

            List<T> temp = new List<T>(); 
            if (accending)
                temp = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderBy(o=> o.GetType().GetProperty(orderBy)).ToList();
            else
                temp = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderByDescending(o => o.GetType().GetProperty(orderBy)).ToList();

            this.Result.AddRange(temp);
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<T> Result { get; set; }
        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
    }
}
