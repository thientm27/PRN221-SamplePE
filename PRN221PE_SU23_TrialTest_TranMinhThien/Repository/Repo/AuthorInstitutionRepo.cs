using DataAccessObject;
using DataAccessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class AuthorInstitutionRepo : IAuthorInstitutionRepo
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public MemberAccount? Login(string username, string password)
        {
           return unitOfWork.MemberAccoutDao.Get(filter: o => o.EmailAddress.ToLower().Equals(username.ToLower()) && o.MemberPassword.Equals(password)).FirstOrDefault();
        }
    }
}
