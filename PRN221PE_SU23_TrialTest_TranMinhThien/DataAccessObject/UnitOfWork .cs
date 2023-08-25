using DataAccessObject.DAOs;
using DataAccessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class UnitOfWork
    {
        private AuthorInstitution2023DBContext context = new AuthorInstitution2023DBContext();
        private GenericDAO<MemberAccount> memberAccoutDao;
        private GenericDAO<CorrespondingAuthor> correspondingAuthorDao;
        private GenericDAO<InstitutionInformation> institutionInformationDAO;

        public GenericDAO<MemberAccount> MemberAccoutDao => memberAccoutDao ??= new MemberAccoutDao(context);
        public GenericDAO<CorrespondingAuthor> CorrespondingAuthorDao => correspondingAuthorDao ??= new CorrespondingAuthorDao(context);
        public GenericDAO<InstitutionInformation> InstitutionInformationDao => institutionInformationDAO ??= new InstitutionInformationDAO(context);
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
