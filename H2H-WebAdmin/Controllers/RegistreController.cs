using H2H_WebAdmin.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace H2H_WebAdmin.Controllers
{
    public class RegistreController : Controller
    {
        

        public ActionResult regitre()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> regitre(User u)
        {
            if(ModelState.IsValid)
            {
               ParseUser user = new ParseUser();
                user["username"] = u.username;
                user["Phone"] = u.Phone;
                user["Type"] = "Patient";
                user["password"] = u.passeword;
                user["adresse"] = u.adresse;
                user["email"] = u.Email;
                await user.SignUpAsync();
                //await user.SaveAsync();
                ModelState.Clear();
                u = null;
                ViewBag.Message = "Successfully Registration Done!!";
                ViewBag.Message2 = "fail";
            }
            return View(u);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(String username,String passeword)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await ParseUser.LogInAsync(username ,passeword);
                    // Login was successful.
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    e.ToString();
                    ViewBag.Message = "error Login!!";
                }
              
                ModelState.Clear();
                ViewBag.Message = "fail login";
               
            }
            return View();
        }
    }
}