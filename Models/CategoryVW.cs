using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RS.TreeView.Models
{
    public class CategoryVW
    {
        public CategoryVW()
        {
            ReportVW = new List<ReportVW>();
        }
        public int Id { get; set; }
        public string Category { get; set; }
        public bool IsCategory
        {
            get;
            set;
        }
        public IList<ReportVW> ReportVW
        {
            get;
            set;
        }
    }
}