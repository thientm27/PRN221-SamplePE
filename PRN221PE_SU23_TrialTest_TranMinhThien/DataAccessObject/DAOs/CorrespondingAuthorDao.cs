using DataAccessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
