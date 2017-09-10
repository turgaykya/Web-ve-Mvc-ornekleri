using _01_Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{

    public class ContentBLL : IBusiness<Content>
    {
        UnitOfWork _uow;
        public ContentBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Content item)
        {
            _uow.ContentRepository.Add(item);
            return _uow.ApplyChanges();
        }

        public Content Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Content item)
        {
            throw new NotImplementedException();
        }

        public bool Update(Content item)
        {
            throw new NotImplementedException();
        }
        public List<EducationGroup> GetContent(int id)
        {
            return _uow.EducationGroupRepository.GetAll().Where(x => x.TrainerID == id).ToList();
        }

        public List<Subject> GetSubject(int id)
        {
            return _uow.SubjectRepository.GetAll()
                .Where(x => x.EducationGroup.TrainerID == id).ToList();
        }

    }
}
