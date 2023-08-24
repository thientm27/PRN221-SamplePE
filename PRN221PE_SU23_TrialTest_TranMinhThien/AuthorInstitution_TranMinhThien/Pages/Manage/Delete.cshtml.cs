using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessObject.Models;

namespace AuthorInstitution_TranMinhThien.Pages.Manage
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccessObject.Models.AuthorInstitution2023DBContext _context;

        public DeleteModel(DataAccessObject.Models.AuthorInstitution2023DBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CorrespondingAuthor CorrespondingAuthor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CorrespondingAuthors == null)
            {
                return NotFound();
            }

            var correspondingauthor = await _context.CorrespondingAuthors.FirstOrDefaultAsync(m => m.AuthorId == id);

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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.CorrespondingAuthors == null)
            {
                return NotFound();
            }
            var correspondingauthor = await _context.CorrespondingAuthors.FindAsync(id);

            if (correspondingauthor != null)
            {
                CorrespondingAuthor = correspondingauthor;
                _context.CorrespondingAuthors.Remove(CorrespondingAuthor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
