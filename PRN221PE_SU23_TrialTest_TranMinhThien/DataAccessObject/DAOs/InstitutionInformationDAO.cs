using DataAccessObject.Models;

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
