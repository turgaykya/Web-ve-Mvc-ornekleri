using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMSTS.Models
{
    public class AssessmentListModel
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string Text { get; set; }

        public int Point { get; set; }

    }
}