using DataAccessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAuthorInstitutionRepo
    {
        public MemberAccount? Login(string username, string password);

    }
}
