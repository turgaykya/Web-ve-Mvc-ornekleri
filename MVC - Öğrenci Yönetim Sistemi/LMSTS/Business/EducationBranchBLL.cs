using _01_Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EducationBranchBLL 
    {
        UnitOfWork _uow;
        public EducationBranchBLL()
        {
            _uow = new UnitOfWork();
        }


        public List<EducationBranch> GetAll()
        {
            return _uow.EducationBranchRepository.GetAll();
        }
    }
}
