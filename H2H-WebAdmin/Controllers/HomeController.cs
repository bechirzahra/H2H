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
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<RendezVous> Rdvs = new List<RendezVous>();

            var query = ParseObject.GetQuery("RendezVous").WhereGreaterThanOrEqualTo("DateRendezVous", DateTime.Now);
            IEnumerable<ParseObject> results = await query.FindAsync();
            List<ParseObject> list = results.ToList();

            if (list.Count() == 0)
            {
                ViewBag.count = list.Count();
            }

            for (int i = 1; i < list.Count(); i++)
            {
                RendezVous r = new RendezVous();
                r.Comment = list[i].Get<string>("Comment");
                r.Confirmation = list[i].Get<byte>("Confirmation");

                r.Date = list[i].Get<DateTime>("DateRendezVous");
                Rdvs.Add(r);

            }
            IEnumerable<ParseUser> w = await (from User in ParseUser.Query
                                              where User.Get<string>("Type") == "Patient"
                                              //where User.Get<string>("DoctorId")==ParseUser.CurrentUser.ObjectId
                                              select User).FindAsync();
            //GetAllPAtient
            List<User> Users = new List<User>();
            List<ParseUser> listP = w.ToList();
            ViewBag.image = Server.MapPath("~/Content/mytemplate/img/user.png");

            for (int i = 1; i < listP.Count(); i++)
            {

                    // ParseFile img = listP[i].Get<ParseFile>("Image");
                    User u = new User();
              //  u.Phone = listP[i].Get<string>("Phone");
                u.adresse = listP[i].Get<string>("adresse");
                u.username = listP[i].Get<string>("username");
                u.Image = Server.MapPath("~/Content/mytemplate/img/user.png");
                
                Users.Add(u);
            }
            //Doctors
            ParseUser user = ParseUser.CurrentUser;
            IEnumerable<ParseUser> du = await (from User in ParseUser.Query.Select("username")
                                               where User.Get<ParseUser>("User").Equals(user)
                                               select User).FindAsync();

            
    List <User> Doctors = new List<User>();
            List<ParseUser> listD = du.ToList<ParseUser>();
            ViewBag.username = listD.Count();
            if (listD.Count() != 0)
            {
                for (int i = 1; i < listD.Count(); i++)
                {

                    User d = new User();
                    d.Phone = listD[i].Get<string>("Phone");
                    d.adresse = listD[i].Get<string>("adresse");
                    d.username = listD[i].Get<string>("username");
                    d.Image = listD[i].Get<ParseFile>("Image").Url.AbsoluteUri;
                    Doctors.Add(d);
                }
            }
            else
                ViewBag.er = "liste Vide!!!";

            List<Object> obj = new List<object>();
    
            obj.Add(Rdvs);
            obj.Add(Users);
            obj.Add(Doctors);
            return View(obj);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}