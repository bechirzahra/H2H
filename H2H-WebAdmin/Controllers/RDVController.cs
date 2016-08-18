using H2H_WebAdmin.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace H2H_WebAdmin.Controllers
{
    public class RDVController : Controller
    {
     
        // GET: RDV
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index(User u)
        {
            return View();
        }



        public ActionResult getRDV()
        {
            return View();
        }
        public async Task<ActionResult> getAllRDV()
        {
           
           List<RendezVous> Rdvs = new List<RendezVous>();
            var query = ParseObject.GetQuery("RendezVous");
            query = query.Limit(3);
            try {
                IEnumerable<ParseObject> results = await query.FindAsync();
                List<ParseObject> list = results.ToList();
                for (int i = 1; i < list.Count(); i++)
                {
                    RendezVous r = new RendezVous();
                    r.Comment = list[i].Get<string>("Comment");
                    r.Confirmation = list[i].Get<byte>("Confirmation");
                    r.Critique = list[i].Get<byte>("Critique");
                    r.Date = list[i].Get<DateTime>("DateRendezVous");
                    Rdvs.Add(r);

                }
            }
            catch
            {
                ViewBag.error = "error";
            }
           
           

            
            return View(Rdvs);
        }

        public async Task<ActionResult> getAllPatient()
        {
            IEnumerable<ParseUser> w = await (from User in ParseUser.Query
                               where User.Get<string>("Type") == "Patient"
                               select User).FindAsync();
            List<User> Users = new List<User>();
            List<ParseUser> list = w.ToList();
            ViewBag.test = list.Count();
            
            for (int i = 1; i < list.Count(); i++)
            {
                ParseFile img = list[i].Get<ParseFile>("Image");
                User u = new User();
                u.Phone = list[i].Get<string>("Phone");
                u.adresse = list[i].Get<string>("adresse");
                u.username = list[i].Get<string>("username");
                u.Image = img.Url.AbsoluteUri;
                Users.Add(u);
            }
            
            return View(Users);
        }
       


    }
}