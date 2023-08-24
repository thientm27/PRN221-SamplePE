using ClubMemberShip.Repo.Utils;
using DataAccessObject.Models;

namespace Repository
{
    public interface IAuthorInstitutionRepo
    {
        public MemberAccount? Login(string username, string password);
        public Pagination<CorrespondingAuthor> GetAuthorPagination(int pageIndex, int pageSize);
        public Pagination<CorrespondingAuthor> GetAuthorPaginationSearch(int pageIndex, int pageSize, string key);

    }
}
