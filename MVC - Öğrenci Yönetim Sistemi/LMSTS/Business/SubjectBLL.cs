using _01_Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{

  public  class SubjectBLL : IBusiness<Subject>
    {
        UnitOfWork _uow;

        public SubjectBLL()
        {
            _uow = new UnitOfWork();
        }
        public bool Add(Subject item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name))
            {
                _uow.SubjectRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public Subject Get(int id)
        {
            return _uow.SubjectRepository.Get(id);
        }

        public List<Subject> GetAll()
        {

            return _uow.SubjectRepository.GetAll();
        }

        public bool Remove(Subject item)
        {
            _uow.SubjectRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Subject item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name))
            {
                _uow.SubjectRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }
        public List<EducationGroup> EducationList()
        {
            return _uow.EducationGroupRepository.GetAll();

        }
        public List<Subject> Subject(int id)
        {
            return _uow.SubjectRepository.GetAll().Where(x => x.EducationGroup.TrainerID == id).ToList();
        }
    }
}
