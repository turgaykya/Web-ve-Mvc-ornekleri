using _01_Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public class GenderBLL
    {
       UnitOfWork _uow;

       public GenderBLL()
       {
           _uow = new UnitOfWork();
       }

       public List<Gender> GetAll()
       {
           return _uow.GenderRepository.GetAll();
       }
    }
}
