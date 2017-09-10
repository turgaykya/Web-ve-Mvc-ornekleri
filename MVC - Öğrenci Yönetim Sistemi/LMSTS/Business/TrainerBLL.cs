using _01_Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TrainerBLL : IBusiness<Trainer>
    {
        UnitOfWork _uow;
        public TrainerBLL()
        {
            _uow = new UnitOfWork();
        }
        public bool Add(Trainer item)
        {
            throw new NotImplementedException();
        }

        public Trainer Get(int id)
        {
            return _uow.TrainerRepository.Get(id);
        }

        public List<Trainer> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Title> TitleList()
        {
            return _uow.TitleRepository.GetAll();
        }

        public List<Gender> GenderList()
        {
            return _uow.GenderRepository.GetAll();
        }

        public bool Remove(Trainer item)
        {
            throw new NotImplementedException();
        }

        public List<Branch> BranchList()
        {
            return _uow.BranchRepository.GetAll();
        }

        public bool Update(Trainer item)
        {
            throw new NotImplementedException();
        }

        public Login LoginControl(string val)
        {
            return _uow.LoginRepository.GetAll().FirstOrDefault(x => x.UserName == val || x.Mail==val);
        }

        public bool Add(Trainer trainer, string mail, string password, string contract, out string messaj)
        {
            if (trainer.Login.Mail!=mail)
            {
                messaj = "Girdiğiniz mail adresleri bir birleri ile uyuşmuyor";
                return false;
            }
            else if (trainer.Login.Password!=password)
            {
                messaj = "Girdiğiniz şifreler bir birleri ile uyuşmuyor";
                return false;
            }
            else if (contract!="on")
            {
                messaj = "Kayıt için sözleşmeyi kabul etmelisiniz";
                return false;
            }
            else
            {
                int id = 1;
                List<Trainer> trainerList = _uow.TrainerRepository.GetAll();
                if (trainerList.Count != 0)
                {
                    id = trainerList[trainerList.Count - 1].Id + 2;
                }
                trainer.Id = trainer.Login.Id = id;
                trainer.IsOnline = false;
                trainer.Status = true;
                trainer.DateOfRegistration = DateTime.Now.Date;
                _uow.TrainerRepository.Add(trainer);
                if (_uow.ApplyChanges())
                {
                    messaj = "Kayıt işlemi başarılı sisteme giriş yapabilirsiniz";
                    return true;
                }
                else
                {
                    messaj = "Sistemde sorun oluştu daha sonra tekrar deneyiniz";
                    return false;
                }
            }
        }
    }
}
