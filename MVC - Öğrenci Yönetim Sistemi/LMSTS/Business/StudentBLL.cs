using _01_Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class StudentBLL : IBusiness<Student>
    {
        UnitOfWork _uow;
        public StudentBLL()
        {
            _uow = new UnitOfWork();
        }
        public bool Add(Student item)
        {
            if (!string.IsNullOrWhiteSpace(item.FirstName) && !string.IsNullOrWhiteSpace(item.LastName))
            {
                _uow.StudentRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public bool Remove(Student item)
        {
            _uow.StudentRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Student item)
        {
            if (!string.IsNullOrWhiteSpace(item.FirstName) && !string.IsNullOrWhiteSpace(item.LastName))
            {
                _uow.StudentRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public Student Get(int id)
        {
            return _uow.StudentRepository.Get(id);
        }

        public List<EducationBranch> EducationList()
        {
            return _uow.EducationBranchRepository.GetAll();
           
        }

        public List<Student> GetAll()
        {
            return _uow.StudentRepository.GetAll();
        }

        public List<Gender> GenderList()
        {
            return _uow.GenderRepository.GetAll();
        }

       
    }
}
