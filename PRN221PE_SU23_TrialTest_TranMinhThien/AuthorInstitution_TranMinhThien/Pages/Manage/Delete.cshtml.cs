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
    public class DeleteModel : PageModel
    {
        IAuthorInstitutionRepo authorInstitutionRepo = new AuthorInstitutionRepo();
        [BindProperty] public CorrespondingAuthor CorrespondingAuthor { get; set; } = default!;

        public IActionResult OnGet(string id)
        {
            var loginId = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(loginId))
            {
                return RedirectToPage("../Login");
            }

            if (authorInstitutionRepo.CheckUser(loginId) == null)
            {
                return RedirectToPage("../Login");
            }


            if (id == null)
            {
                return NotFound();
            }

            var correspondingauthor = authorInstitutionRepo.GetAuthorById(id);

            if (correspondingauthor == null)
            {
                return NotFound();
            }
            else
            {
                CorrespondingAuthor = correspondingauthor;
            }

            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            authorInstitutionRepo.DeleteAuthor(id);

            return RedirectToPage("./Index");
        }
    }
}