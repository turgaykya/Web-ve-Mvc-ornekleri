using _01_Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CommentBLL : IBusiness<Comment>
    {
        UnitOfWork _uow;
         
        public CommentBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Comment item)
        {
            if (!string.IsNullOrWhiteSpace(item.Description))
            {
                _uow.CommentRepository.Add(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

        public Comment Get(int id)
        {
            return _uow.CommentRepository.Get(id);
        }

        public List<Comment> GetAll()
        {
            return _uow.CommentRepository.GetAll();
        }

        public bool Remove(Comment item)
        {
            return _uow.ApplyChanges();
        }

        public bool Update(Comment item)
        {
            if (!string.IsNullOrWhiteSpace(item.Description))
            {
                _uow.CommentRepository.Update(item);
                return _uow.ApplyChanges();
            }
            return false;
        }

    }
}
