using System;
using System.Collections.Generic;
using System.Text;

namespace ZeeShine.Data.ComponentModel
{
    public class PagingQuery
    {
        private int pageIndex;

        public PagingQuery()
        {
            PageIndex = 1;
            PerPageSize = 50;
        }

        public int PageIndex
        {
            get
            {
                return pageIndex;
            }
            set
            {
                if (value <= 0)
                {
                    pageIndex = 1;
                }
                else
                {
                    pageIndex = value;
                }
            }
        }

        public int PerPageSize
        {
            get;
            set;
        }

        public string Keyword
        {
            get;
            set;
        }

        public string Sort
        {
            get;
            set;
        }
    }
}
