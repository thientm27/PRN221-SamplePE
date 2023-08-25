using DataAccessObject;
using DataAccessObject.Models;
using System.Text.RegularExpressions;
using DataAccessObject.Utils;

namespace Repository.Repo
{
    public class AuthorInstitutionRepo : IAuthorInstitutionRepo
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public void DeleteAuthor(object id)
        {
            unitOfWork.CorrespondingAuthorDao.DeleteById(id);
        }

        public CorrespondingAuthor? GetAuthorById(object id)
        {
            return unitOfWork.CorrespondingAuthorDao.GetById(id);
        }

        public Pagination<CorrespondingAuthor> GetAuthorPagination(int pageIndex, int pageSize)
        {
            var entities = unitOfWork.CorrespondingAuthorDao.Get(includeProperties: "Institution");
            return unitOfWork.CorrespondingAuthorDao.ToPagination(entities, pageIndex, pageSize);

        }
        public Pagination<CorrespondingAuthor> GetAuthorPaginationSpecialEntity(int pageIndex, int pageSize, string keyId)
        {
            var entities = unitOfWork.CorrespondingAuthorDao.Get(includeProperties: "Institution", orderBy: q => q.OrderBy(author => author.AuthorId != keyId));
            return unitOfWork.CorrespondingAuthorDao.ToPagination(entities, pageIndex, pageSize);
        }
        public Pagination<CorrespondingAuthor> GetAuthorPaginationNewItemFirst(int pageIndex, int pageSize)
        {
            var entities = unitOfWork.CorrespondingAuthorDao.Get(includeProperties: "Institution", orderBy: q => q.OrderByDescending(author => author.AuthorId));
            return unitOfWork.CorrespondingAuthorDao.ToPagination(entities, pageIndex, pageSize);
        }
        public Pagination<CorrespondingAuthor> GetAuthorPaginationSearch(int pageIndex, int pageSize, string key, int type = 0)
        {
            switch (type)
            {
                case 0:
                    {
                        var entities = unitOfWork.CorrespondingAuthorDao.Get(filter: o => o.AuthorName.ToLower().Contains(key.ToLower()) || o.Skills.ToLower().Contains(key.ToLower()), includeProperties: "Institution");
                        return unitOfWork.CorrespondingAuthorDao.ToPagination(entities, pageIndex, pageSize);
                    }
                case 1:
                    {
                        var entities = unitOfWork.CorrespondingAuthorDao.Get(filter: o => o.AuthorName.ToLower().Contains(key.ToLower()), includeProperties: "Institution");
                        return unitOfWork.CorrespondingAuthorDao.ToPagination(entities, pageIndex, pageSize);

                    }
                case 2:
                    {
                        var entities = unitOfWork.CorrespondingAuthorDao.Get(filter: o => o.Skills.ToLower().Contains(key.ToLower()), includeProperties: "Institution");
                        return unitOfWork.CorrespondingAuthorDao.ToPagination(entities, pageIndex, pageSize);

                    }
            }
            return new Pagination<CorrespondingAuthor>();
        }

        public MemberAccount? Login(string username, string password)
        {
            return unitOfWork.MemberAccoutDao.Get(filter: o => o.EmailAddress.ToLower().Equals(username.ToLower()) && o.MemberPassword.Equals(password)).FirstOrDefault();
        }

        public List<InstitutionInformation> GetInstitutionInformations()
        {
            return unitOfWork.InstitutionInformationDao.Get();
        }
        public CorrespondingAuthor? AddNewAuthor(CorrespondingAuthor author)
        {
            author.AuthorId = GetNextAuthorIdString();
            unitOfWork.CorrespondingAuthorDao.Create(author);
            unitOfWork.Save();
            return unitOfWork.CorrespondingAuthorDao.GetById(author.AuthorId);
        }

        private string GetNextAuthorIdString()
        {
            try
            {
                string lastId = unitOfWork.CorrespondingAuthorDao.Get().OrderBy(p => p.AuthorId).LastOrDefault().AuthorId;
                string pattern = @"^([A-Za-z]+)(\d+)$";

                Match match = Regex.Match(lastId, pattern);

                if (match.Success)
                {
                    // Extract the alphabetic prefix and numeric part from the ID
                    string prefix = match.Groups[1].Value;
                    string numericPart = match.Groups[2].Value;

                    // Convert the numeric part to an integer, increment by one, and then format with leading zeros
                    int numericValue = int.Parse(numericPart);
                    numericValue++;
                    // Reconstruct the ID with the incremented numeric part
                    string incrementedID = prefix + new string('0', (4 - numericValue.ToString().Length)) + numericValue.ToString();


                    return incrementedID;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CorrespondingAuthor? UpdateAuthor(CorrespondingAuthor author)
        {
            unitOfWork.CorrespondingAuthorDao.Update(author);
            unitOfWork.Save();
            return unitOfWork.CorrespondingAuthorDao.GetById(author.AuthorId);
        }
    }
}
