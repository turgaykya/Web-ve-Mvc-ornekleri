using _01_Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public class QuestionBLL:IBusiness<Question>
    {
        UnitOfWork _uow;

        public QuestionBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Question item)
        {
            if (!string.IsNullOrWhiteSpace(item.Text))
            {
                _uow.QuestionRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public Question Get(int id)
        {
            return _uow.QuestionRepository.Get(id);
        }

        public List<Question> GetAll()
        {
            return _uow.QuestionRepository.GetAll();
        }

        public bool Remove(Question item)
        {
            _uow.QuestionRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Question item)
        {
            if (!string.IsNullOrWhiteSpace(item.Text))
            {
                _uow.QuestionRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        //public List<Subject> SubjectList()
        //{
            //return _uow.SubjectRepository.GetAll().Where();

        //}


    }
}
