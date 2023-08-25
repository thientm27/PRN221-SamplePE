using DataAccessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.DAOs 
{
    public class InstitutionInformationDAO : GenericDAO<InstitutionInformation>
    {
        public InstitutionInformationDAO(AuthorInstitution2023DBContext context) : base(context)
        {
        }

        public override InstitutionInformation? GetById(object? id)
        {
            throw new NotImplementedException();
        }
    }
}
