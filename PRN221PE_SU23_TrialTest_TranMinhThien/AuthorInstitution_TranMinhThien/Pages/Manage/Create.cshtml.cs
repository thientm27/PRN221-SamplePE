
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessObject.Models;
using Repository.Repo;
using Repository;

namespace AuthorInstitution_TranMinhThien.Pages.Manage
{
    public class CreateModel : PageModel
    {
        private IAuthorInstitutionRepo authorInstitutionRepo = new AuthorInstitutionRepo();
        public IActionResult OnGet()
        {
        ViewData["InstitutionId"] = new SelectList(authorInstitutionRepo.GetInstitutionInformations(), "InstitutionId", "Area");
            return Page();
        }

        [BindProperty]
        public CorrespondingAuthor CorrespondingAuthor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          if (!ModelState.IsValid || CorrespondingAuthor == null)
            {
                return Page();
            }

            authorInstitutionRepo.AddNewAuthor(CorrespondingAuthor);

            return RedirectToPage("./Index");
        }
    }
}
