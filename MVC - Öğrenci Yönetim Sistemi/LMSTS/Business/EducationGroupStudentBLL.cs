using _01_Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    
   public class EducationGroupStudentBLL : IBusiness<Education_Group_Student>
    {
        UnitOfWork _uow;
        public EducationGroupStudentBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Education_Group_Student item)
        {
            _uow.EducationGroupStudentRepository.Add(item);
            return _uow.ApplyChanges();
        }

        public Education_Group_Student Get(int id)
        {
           return _uow.EducationGroupStudentRepository.Get(id);
        }

        public List<Education_Group_Student> GetAll()
        {
            return _uow.EducationGroupStudentRepository.GetAll();
        }

        public bool Remove(Education_Group_Student item)
        {
            _uow.EducationGroupStudentRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Education_Group_Student item)
        {
            _uow.EducationGroupStudentRepository.Update(item);
            return _uow.ApplyChanges();
        }

        


    }
}
