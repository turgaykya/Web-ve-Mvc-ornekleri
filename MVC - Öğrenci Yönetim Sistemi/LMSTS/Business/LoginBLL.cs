using _01_Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public class LoginBLL : IBusiness<Login>
    {
        UnitOfWork _uow;
        public LoginBLL()
        {
            _uow = new UnitOfWork();
        }
        public bool Add(Login item)
        {
            throw new NotImplementedException();
        }

        public Login Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Login> GetAll()
        {
            throw new NotImplementedException();
        }

        public Login LoginUser(string userId, string password)
        {
            return _uow.LoginRepository.GetAll().Where(x => (x.Mail == userId || x.UserName == userId || x.CitizenNumber == userId) && x.Password == password &&( x.Trainer.Status==true||x.Student.Status==true)).FirstOrDefault();
        }

        public bool Remove(Login item)
        {
            throw new NotImplementedException();
        }

        public bool Update(Login item)
        {
            throw new NotImplementedException();
        }
    }
}
