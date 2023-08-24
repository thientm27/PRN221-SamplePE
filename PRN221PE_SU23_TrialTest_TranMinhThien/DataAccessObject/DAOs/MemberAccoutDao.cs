using DataAccessObject.Models;


namespace DataAccessObject.DAOs
{
    internal class MemberAccoutDao : GenericDAO<MemberAccount>
    {
        public MemberAccoutDao(AuthorInstitution2023DBContext context) : base(context)
        {
        }

        public override MemberAccount? GetById(object? id)
        {
            if (id == null)
            {
                return null;
            }
            return Get(filter: o => o.MemberId.Equals(id)).FirstOrDefault();
        }
    }
}
