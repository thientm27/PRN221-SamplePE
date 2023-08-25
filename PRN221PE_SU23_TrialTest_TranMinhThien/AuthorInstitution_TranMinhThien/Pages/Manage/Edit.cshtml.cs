using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessObject.Models;
using Repository;
using Repository.Repo;

namespace AuthorInstitution_TranMinhThien.Pages.Manage
{
    public class EditModel : PageModel
    {
        private IAuthorInstitutionRepo authorInstitutionRepo = new AuthorInstitutionRepo();
     

        [BindProperty]
        public CorrespondingAuthor CorrespondingAuthor { get; set; } = default!;

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }

            var correspondingauthor = authorInstitutionRepo.GetAuthorById(id);
            if (correspondingauthor == null)
            {
                return RedirectToPage("./Index");
            }

            CorrespondingAuthor = correspondingauthor;
            ViewData["InstitutionId"] = new SelectList(authorInstitutionRepo.GetInstitutionInformations(), "InstitutionId", "Area");
            return Page();
        }

        public IActionResult OnPostAsync()
        {

            if (CorrespondingAuthor == null)
            {
                return RedirectToPage("./Index");
            }

            if (!CheckName(CorrespondingAuthor.AuthorName))
            {
                ModelState.AddModelError("CorrespondingAuthor.AuthorName", "Author’s name from 6 to 100 characters. Each word of the corresponding author name (AuthorName) must begin with the capital letter.");
                return OnGet(CorrespondingAuthor.AuthorId);
            }

                var result =   authorInstitutionRepo.UpdateAuthor(CorrespondingAuthor);

            return RedirectToPage("./Index", new { id = result?.AuthorId });
        }
        private bool CheckName(string name)
        {
            bool check = true;
            if (name.Length < 6 || name.Length > 100)
            {
                check = false;
            }

            // Check if each word starts with a capital letter
            string[] nameParts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in nameParts)
            {
                if (!char.IsUpper(part[0]))
                {
                    check = false;
                }
            }
            return check;
        }
    }
}
