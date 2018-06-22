using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;
using WebApplication6.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProjektZespolowy.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: ApplicationUsers
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.ApplicationUser.ToListAsync());
        //}
        [Authorize(Roles = "Pracownik, Administrator")]
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["EmailSortParm"] = sortOrder == "email" ? "email_desc" : "email";
            ViewData["UserConfSortParm"] = sortOrder == "userConf" ? "userConf_desc" : "userConf";
            ViewData["CurrentFilter"] = searchString;


            var users = from s in _context.Users.Where(u => u.IsNaturalPerson == true && u.IsEmployee == false)
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.LastName);
                    break;
                case "email_desc":
                    users = users.OrderByDescending(s => s.Email);
                    break;
                case "email":
                    users = users.OrderBy(s => s.Email);
                    break;
                case "userConf":
                    users = users.OrderBy(s => s.UserConfirmed);
                    break;
                case "userConf_desc":
                    users = users.OrderByDescending(s => s.UserConfirmed);
                    break;
                default:
                    users = users.OrderBy(s => s.LastName);
                    break;
            }
            return View(await users.AsNoTracking().ToListAsync());
        }

        [Authorize(Roles = "Pracownik, Administrator")]
        public async Task<IActionResult> Index2(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["EmailSortParm"] = sortOrder == "email" ? "email_desc" : "email";
            ViewData["UserConfSortParm"] = sortOrder == "userConf" ? "userConf_desc" : "userConf";
            ViewData["CurrentFilter"] = searchString;


            var users = from s in _context.Users.Where(u => u.IsNaturalPerson==false)
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.CompanyName.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.CompanyName);
                    break;
                case "email_desc":
                    users = users.OrderByDescending(s => s.Email);
                    break;
                case "email":
                    users = users.OrderBy(s => s.Email);
                    break;
                case "userConf":
                    users = users.OrderBy(s => s.UserConfirmed);
                    break;
                case "userConf_desc":
                    users = users.OrderByDescending(s => s.UserConfirmed);
                    break;
                default:
                    users = users.OrderBy(s => s.CompanyName);
                    break;
            }
            return View(await users.AsNoTracking().ToListAsync());
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index3(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["EmailSortParm"] = sortOrder == "email" ? "email_desc" : "email";
            ViewData["UserConfSortParm"] = sortOrder == "userConf" ? "userConf_desc" : "userConf";
            ViewData["CurrentFilter"] = searchString;


            var users = from s in _context.Users.Where(u => u.IsEmployee == true)
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.LastName);
                    break;
                case "email_desc":
                    users = users.OrderByDescending(s => s.Email);
                    break;
                case "email":
                    users = users.OrderBy(s => s.Email);
                    break;
                case "userConf":
                    users = users.OrderBy(s => s.UserConfirmed);
                    break;
                case "userConf_desc":
                    users = users.OrderByDescending(s => s.UserConfirmed);
                    break;
                default:
                    users = users.OrderBy(s => s.LastName);
                    break;
            }
            return View(await users.AsNoTracking().ToListAsync());
        }

        // GET: ApplicationUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserConfirmed,FirstName,LastName,Pesel,Nip,Regon,Points,IsNaturalPerson,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        [Authorize(Roles = "Pracownik, Administrator")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pracownik, Administrator")]
        public async Task<IActionResult> Edit(string id, [Bind("UserConfirmed,FirstName,LastName,CompanyName,Pesel,Nip,Regon,Points,IsNaturalPerson,IsEmployee,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                    if (applicationUser.IsEmployee == true)
                    {
                        await _userManager.RemoveFromRoleAsync(applicationUser, "Uzytkownik");
                        await _userManager.AddToRoleAsync(applicationUser, "Pracownik");
                        await _userManager.UpdateAsync(applicationUser);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }
        // GET: ApplicationUsers/Edit/5
        [Authorize(Roles = "Pracownik, Administrator")]
        public async Task<IActionResult> Edit2(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pracownik, Administrator")]
        public async Task<IActionResult> Edit2(string id, [Bind("UserConfirmed,FirstName,LastName,CompanyName,Pesel,Nip,Regon,Points,IsNaturalPerson,IsEmployee,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index2));
            }
            return View(applicationUser);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit3(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit3(string id, [Bind("UserConfirmed,FirstName,LastName,CompanyName,Pesel,Nip,Regon,Points,IsNaturalPerson,IsEmployee,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                    if (applicationUser.IsEmployee == false)
                    {
                        await _userManager.RemoveFromRoleAsync(applicationUser, "Pracownik");
                        await _userManager.AddToRoleAsync(applicationUser, "Uzytkownik");
                        await _userManager.UpdateAsync(applicationUser);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index3));
            }
            return View(applicationUser);
        }

        public async Task<IActionResult> Verify(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Verify(string id, [Bind("UserConfirmed, Id")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return View("~/Views/Home/About.cshtml");
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        [Authorize(Roles = "Pracownik, Administrator")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pracownik, Administrator")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApplicationUser.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pracownik, Administrator")]
        public async Task<IActionResult> Ver(string id, [Bind("UserConfirmed,FirstName,LastName,CompanyName,Pesel,Nip,Regon,Points,IsNaturalPerson,IsEmployee,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                    if (applicationUser.UserConfirmed == true)
                    {
                        await _userManager.RemoveFromRoleAsync(applicationUser, "UzytkownikNiezweryfikowany");
                        await _userManager.AddToRoleAsync(applicationUser, "Uzytkownik");
                        await _userManager.UpdateAsync(applicationUser);
                    }
                    else
                    {
                        await _userManager.RemoveFromRoleAsync(applicationUser, "Uzytkownik");
                        await _userManager.AddToRoleAsync(applicationUser, "UzytkownikNiezweryfikowany");
                        await _userManager.UpdateAsync(applicationUser);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        [Authorize(Roles = "Pracownik, Administrator")]
        public async Task<IActionResult> Ver(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pracownik, Administrator")]
        public async Task<IActionResult> Ver2(string id, [Bind("UserConfirmed,FirstName,LastName,CompanyName,Pesel,Nip,Regon,Points,IsNaturalPerson,IsEmployee,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                    if (applicationUser.UserConfirmed == true)
                    {
                        await _userManager.RemoveFromRoleAsync(applicationUser, "UzytkownikNiezweryfikowany");
                        await _userManager.AddToRoleAsync(applicationUser, "Uzytkownik");
                        await _userManager.UpdateAsync(applicationUser);
                    }
                    else
                    {
                        await _userManager.RemoveFromRoleAsync(applicationUser, "Uzytkownik");
                        await _userManager.AddToRoleAsync(applicationUser, "UzytkownikNiezweryfikowany");
                        await _userManager.UpdateAsync(applicationUser);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index2));
            }
            return View(applicationUser);
        }

        [Authorize(Roles = "Pracownik, Administrator")]
        public async Task<IActionResult> Ver2(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
        }
    }
}
