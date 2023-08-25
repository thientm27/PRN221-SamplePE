using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessObject.Models;
using Repository.Repo;
using Repository;

namespace AuthorInstitution_TranMinhThien.Pages.Manage
{
    public class IndexModel : PageModel
    {
        IAuthorInstitutionRepo authorInstitutionRepo = new AuthorInstitutionRepo();

        public IList<CorrespondingAuthor> CorrespondingAuthor { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 4;

        [BindProperty]
        public string? SearchBy { get; set; }

        [BindProperty]
        public string? Keyword { get; set; }
        [BindProperty]
        public string? NewId { get; set; }
        public IActionResult OnGet(string? id)
        {
            if(id == null)
            {
                NewId = null;
                var data = authorInstitutionRepo.GetAuthorPagination(PageIndex - 1, PageSize);
                TotalPages = data.TotalPagesCount;
                CorrespondingAuthor = data.Items.ToList();
                return Page();
            }
            else
            {
                NewId = id;
                var data = authorInstitutionRepo.GetAuthorPaginationSpecialEntity(PageIndex - 1, PageSize, NewId);
                TotalPages = data.TotalPagesCount;
                CorrespondingAuthor = data.Items.ToList();
                return Page();
            }

        }
        public IActionResult OnPost()
        {
            if(Keyword == null)
            {
               return OnGet(NewId);
            }
            else
            {
                NewId = null;
                if (SearchBy!.Equals("name"))
                {
                    var data = authorInstitutionRepo.GetAuthorPaginationSearch(PageIndex - 1, PageSize, Keyword, 1);
                    TotalPages = data.TotalPagesCount;
                    CorrespondingAuthor = data.Items.ToList();
                    return Page();
                }
                else
                {
                    var data = authorInstitutionRepo.GetAuthorPaginationSearch(PageIndex - 1, PageSize, Keyword, 2);
                    TotalPages = data.TotalPagesCount;
                    CorrespondingAuthor = data.Items.ToList();
                    return Page();
                }
            }

        }
    }
}
