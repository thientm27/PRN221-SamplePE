﻿using System;
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
        public void OnGet()
        {
            var data = authorInstitutionRepo.GetAuthorPagination(PageIndex - 1, PageSize);
            TotalPages = data.TotalPagesCount;
            CorrespondingAuthor = data.Items.ToList();
        }
    }
}