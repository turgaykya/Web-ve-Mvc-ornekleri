using _01_Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EducationGroupBLL : IBusiness<EducationGroup>
    {
        UnitOfWork _uow;
        public EducationGroupBLL()
        {
            _uow = new UnitOfWork();
        }
        public bool Add(EducationGroup item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name))
            {
                _uow.EducationGroupRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public bool Remove(EducationGroup item)
        {
            _uow.EducationGroupRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(EducationGroup item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name))
            {
                _uow.EducationGroupRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public EducationGroup Get(int id)
        {
            return _uow.EducationGroupRepository.Get(id);
        }

        public List<EducationGroup> GetAll()
        {
            return _uow.EducationGroupRepository.GetAll();
        }

        public List<Trainer> TrainerList()
        {
            return _uow.TrainerRepository.GetAll();
        }

        public void EducationStudentAdd(Education_Group_Student _eduGroupStu)
        {
            _uow.EducationGroupStudentRepository.Add(_eduGroupStu);
            _uow.ApplyChanges();
        }
        public List<EducationGroup> TrainerEducationGroup(int id)
        {
      
                return _uow.EducationGroupRepository.GetAll().Where(x => x.TrainerID == id).ToList();      
        }
    }
}
