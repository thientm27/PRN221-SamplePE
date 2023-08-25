using DataAccessObject.Models;

namespace DataAccessObject.DAOs
{
    public class CorrespondingAuthorDao : GenericDAO<CorrespondingAuthor>
    {
        public CorrespondingAuthorDao(AuthorInstitution2023DBContext context) : base(context)
        {
        }

        public override CorrespondingAuthor? GetById(object? id)
        {
            if (id == null)
            {
                return null;
            }
            return Get(filter: o => o.AuthorId.Equals(id)).FirstOrDefault();
        }
      
    }
}
