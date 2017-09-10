using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMSTS.Models
{
    public class SubjectListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EducationGroupName { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Document { get; set; }
    }
}