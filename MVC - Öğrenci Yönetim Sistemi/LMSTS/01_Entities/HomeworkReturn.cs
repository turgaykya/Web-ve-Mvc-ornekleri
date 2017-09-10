using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Entities
{
  public  class HomeworkReturn
    {
        public int Id { get; set; }
        public int HomeworkDeliveryID { get; set; }
        public short EvaluationPoint { get; set; }
        public int ReturnTypeID { get; set; }
        public string Description { get; set; }
        public virtual HomeworkDelivery HomeworkDelivery { get; set; }
        public virtual ReturnType ReturnType { get; set; }  

    }
}
