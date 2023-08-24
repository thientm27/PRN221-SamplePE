using DataAccessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using Repository.Repo;

namespace AuthorInstitution_TranMinhThien.Pages
{
    public class LoginModel : PageModel
    {
        IAuthorInstitutionRepo authorInstitutionRepo = new AuthorInstitutionRepo();

        [BindProperty]
        public MemberAccount MemberAccount { get; set; } = default!;

        public IActionResult OnPostLogin()
        {
            MemberAccount? loginAccount = authorInstitutionRepo.Login(MemberAccount.EmailAddress, MemberAccount.MemberPassword);
            if (loginAccount == null)
            {
                ViewData["notification"] = "Email or Password is wrong!";
                return Page();
            }
            else
            if (loginAccount.MemberRole == 1)
            {
                return RedirectToPage("./Manage/Index");
            }
            else
            {
                ViewData["notification"] = "You do not have permission to do this function!";
                return Page();
            }

        }
    }
}
