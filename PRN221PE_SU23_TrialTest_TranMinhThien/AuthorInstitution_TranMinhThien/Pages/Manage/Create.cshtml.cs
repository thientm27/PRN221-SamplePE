
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

        public IActionResult OnPost()
        {
            if (CorrespondingAuthor == null)
            {
                return Page();
            }

            if (!CheckName(CorrespondingAuthor.AuthorName))
            {
                ModelState.AddModelError("CorrespondingAuthor.AuthorName", "Author’s name from 6 to 100 characters. Each word of the corresponding author name (AuthorName) must begin with the capital letter.");
                return OnGet();
            }

            var result = authorInstitutionRepo.AddNewAuthor(CorrespondingAuthor);

            return RedirectToPage("./Index", new {id = result?.AuthorId});
        }

        private bool CheckBirthday(DateTime birthday)
        {
            var check = true;
            DateTime minDate;
            DateTime.TryParseExact("1991-01-01 00:00", "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out minDate);
            DateTime maxDate = DateTime.Now;
            if (birthday >= maxDate || birthday <= minDate)
            {
                check = false;
            }
            return check;
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
