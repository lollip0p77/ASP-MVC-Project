using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_MVC_SitePandas.Models;
using System.Security.Claims;

namespace ASP_MVC_SitePandas.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AspNetUserRolesController : Controller
    {
        private readonly LesPetitsPandasContext _context;

        public AspNetUserRolesController(LesPetitsPandasContext context)
        {
            _context = context;
        }

        //Get: Edit
        public async Task<IActionResult> Edit()
        {
            ViewData["Completion"] = "";

            ViewData["RoleId"] = new SelectList(_context.AspNetRoles, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "UserName");
            return View(await _context.AspNetUserRoles.Include(ur => ur.User).Include(ur => ur.Role).OrderBy(t => t.User.UserName).ToListAsync());
        }

        //Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,RoleId")] AspNetUserRole userRole)
        {
            if (_context.AspNetUserRoles.Where(ur => ur.UserId == userRole.UserId
                        && ur.RoleId == userRole.RoleId).FirstOrDefault() == null)
            {

                if (_context.AspNetUsers.Where(u => u.Id == userRole.UserId) != null &&
                   _context.AspNetRoles.Where(r => r.Id == userRole.RoleId) != null)
                {
                    //Tout est OK
                    _context.Add(userRole);
                    await _context.SaveChangesAsync();
                    ViewData["Completion"] = "Nouvel agencement ajouté avec succès";
                }
            }
            else
            {
                ViewData["Completion"] = "Cet usager possède déjà ce rôle.";
            }



            ViewData["RoleId"] = new SelectList(_context.AspNetRoles, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "UserName");
            return View(_context.AspNetUserRoles.Include(ur => ur.User).Include(ur => ur.Role).OrderBy(t => t.User.UserName));
        }

        // POST: AspNetUserRoles/Delete/5
        public async Task<IActionResult> Delete(string uid, string rid)
        {

            var aspNetUserRole = await _context.AspNetUserRoles.SingleOrDefaultAsync(t => t.UserId == uid && t.RoleId == rid);

            if (aspNetUserRole != null)
            {
                _context.AspNetUserRoles.Remove(aspNetUserRole);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Edit");
        }

        private bool AspNetUserRoleExists(string id)
        {
            return _context.AspNetUserRoles.Any(e => e.UserId == id);
        }
    }
}
