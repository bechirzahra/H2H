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
    public class PatientController : Controller
    {
        // GET: Patient
        [HttpGet]
        public async Task<ActionResult> Analyse()
        {
            List<EEGBrain> eeg = new List<EEGBrain>();
            List<Pulse> pl = new List<Pulse>();
            List<EMG> emg = new List<EMG>();
            List<Respiration> resp = new List<Respiration>();
            var query = ParseObject.GetQuery("Pulse").OrderBy("createdAt").OrderByDescending("createdAt");
            var query1 = ParseObject.GetQuery("EMG").OrderBy("createdAt").OrderByDescending("createdAt");
            var query2 = ParseObject.GetQuery("Respiration").OrderBy("createdAt").OrderByDescending("createdAt");
            var query3 = ParseObject.GetQuery("EEGBrain").OrderBy("createdAt").OrderByDescending("createdAt");
            IEnumerable <ParseObject> results = await query.FindAsync();
            IEnumerable<ParseObject> results1 = await query1.FindAsync();
            IEnumerable<ParseObject> results2 = await query2.FindAsync();
            IEnumerable<ParseObject> results3 = await query3.FindAsync();
            List<ParseObject> list = results.ToList();
            List<ParseObject> list1 = results1.ToList();
            List<ParseObject> list2 = results2.ToList();
            List<ParseObject> list3 = results3.ToList();
            for (int i = 0; i < list3.Count(); i++)
            {
                EEGBrain r = new EEGBrain();
                r.n1 = list3[i].Get<int>("n1");
                r.n2 = list3[i].Get<int>("n2");
                r.n3 = list3[i].Get<int>("n3");
                r.n4 = list3[i].Get<int>("n4");
                r.n5 = list3[i].Get<int>("n5");
                r.n6 = list3[i].Get<int>("n6");
                r.n7 = list3[i].Get<int>("n7");
                r.n8 = list3[i].Get<int>("n8");
                r.n9 = list3[i].Get<int>("n9");


                eeg.Add(r);

            }
            for (int i = 0; i < list.Count(); i++)
            {
                Pulse r = new Pulse();
                r.Data = list[i].Get<int>("Data");
                r.UpdatedAt = (DateTime) list[i].UpdatedAt;
                pl.Add(r);

            }
            for (int i = 0; i < list1.Count(); i++)
            {
                EMG e = new EMG();
                e.valEMG = list1[i].Get<int>("emgValue");
                emg.Add(e);

            }
            for (int i =0; i < list2.Count(); i++)
            {
                Respiration re = new Respiration();
                re.valRespiration = list2[i].Get<int>("respValue");
                resp.Add(re);

            }
            ViewBag.li = pl;
            ViewBag.li1 = emg;
            ViewBag.li2 = resp;
            ViewBag.li3 = eeg;
            List<Object> obj = new List<object>();
            obj.Add(pl);
            obj.Add(emg);
            obj.Add(resp);
            obj.Add(eeg);
            ViewBag.a = pl.Count();
            return View(obj);
        }
    }
}