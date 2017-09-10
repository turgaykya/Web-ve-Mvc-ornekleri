using _01_Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public class TopicBLL : IBusiness<Topic>
    {
        UnitOfWork _uow;

        public TopicBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Topic item)
        {
            if (!string.IsNullOrWhiteSpace(item.Head)&& !string.IsNullOrWhiteSpace(item.Description))
            {
                _uow.TopicRepository.Add(item);

                return _uow.ApplyChanges();
            }
            return false;
        }

        public Topic Get(int id)
        {
            return _uow.TopicRepository.Get(id);
        }

        public List<Topic> GetAll()
        {
            return _uow.TopicRepository.GetAll().ToList();
        }
        public List<Topic> GetAll(int id)
        {
            return _uow.TopicRepository.GetAll().ToList();
        }

        public List<EducationGroup> GetEducationAll(int id)//Buraya Sessiondan ID geleck
        {
            if (id % 2 == 1)
            {
                return _uow.EducationGroupRepository.GetAll().Where(x => x.TrainerID == id).ToList();
            }
            else
            {
                return _uow.EducationGroupRepository.GetAll()
                    .Where(x => x.Id == x.Students.FirstOrDefault(s => s.Id == id).Id).ToList();
            }

        }

        public bool Remove(Topic item)
        {
            _uow.TopicRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Topic item)
        {
            if (!string.IsNullOrWhiteSpace(item.Head) && !string.IsNullOrWhiteSpace(item.Description))
            {
                _uow.TopicRepository.Update(item);

                return _uow.ApplyChanges();
            }
            return false;
        }

        public void CommentAdd(Comment comment)
        {
            _uow.CommentRepository.Add(comment);
            _uow.ApplyChanges();
        }
    }
}
