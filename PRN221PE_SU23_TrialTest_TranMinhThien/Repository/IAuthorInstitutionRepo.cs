﻿using ClubMemberShip.Repo.Utils;
using DataAccessObject.Models;

namespace Repository
{
    public interface IAuthorInstitutionRepo
    {
        public MemberAccount? Login(string username, string password);
        public Pagination<CorrespondingAuthor> GetAuthorPagination(int pageIndex, int pageSize);
        public Pagination<CorrespondingAuthor> GetAuthorPaginationSpecialEntity(int pageIndex, int pageSize, string keyId);
        public Pagination<CorrespondingAuthor> GetAuthorPaginationSearch(int pageIndex, int pageSize, string key, int type = 0 );
        public Pagination<CorrespondingAuthor> GetAuthorPaginationNewItemFirst(int pageIndex, int pageSize);
        public void DeleteAuthor(object id);
        public CorrespondingAuthor GetAuthorById(object id);
        public List<InstitutionInformation> GetInstitutionInformations();
        public CorrespondingAuthor? AddNewAuthor(CorrespondingAuthor author);
        public CorrespondingAuthor? UpdateAuthor(CorrespondingAuthor author);

    }
}
