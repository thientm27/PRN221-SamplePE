using ClubMemberShip.Repo.Utils;
using DataAccessObject.Models;

namespace Repository
{
    public interface IAuthorInstitutionRepo
    {
        public MemberAccount? Login(string username, string password);
        public Pagination<CorrespondingAuthor> GetAuthorPagination(int pageIndex, int pageSize);

    }
}
