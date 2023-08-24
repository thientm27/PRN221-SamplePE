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
        public string? Keyword { get; set; }
        public IActionResult OnGet()
        {
            var data = authorInstitutionRepo.GetAuthorPagination(PageIndex - 1, PageSize);
            TotalPages = data.TotalPagesCount;
            CorrespondingAuthor = data.Items.ToList();
            return Page();
        }
        public IActionResult OnPost()
        {
            if(Keyword == null)
            {
               return OnGet();
            }
            else
            {
                var data = authorInstitutionRepo.GetAuthorPaginationSearch(PageIndex - 1, PageSize, Keyword);
                TotalPages = data.TotalPagesCount;
                CorrespondingAuthor = data.Items.ToList();
                return Page();
            }

        }
    }
}
