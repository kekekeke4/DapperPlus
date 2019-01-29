using System;
using System.Collections.Generic;
using System.Text;

namespace ZeeShine.Data.ComponentModel
{
    public class Pagination<TEntity>
    {
        public List<TEntity> Items { get; set; }

        public long TotalItems { get; set; }

        public int PerPageSize { get; set; }

        public long PageIndex
        {
            get;
            set;
        }

        public long TotalPage
        {
            get
            {
                if (PerPageSize == 0)
                {
                    return 0;
                }

                var page = TotalItems / PerPageSize;
                if (TotalItems % PerPageSize != 0)
                {
                    page++;
                }
                return page;
            }
        }
    }
}
