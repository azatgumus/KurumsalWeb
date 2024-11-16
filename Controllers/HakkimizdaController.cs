using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using KurumsalWeb.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class HakkimizdaController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            var h = db.Hakkimizda.ToList();
            return View(h);
        }
        public ActionResult CreateOrUpdate(int? id)
        {
            if (id == null)
            {
                return View(new HakkimizdaViewModel());
            }
            else
            {
                var h = db.Hakkimizda.Find(id);

                if (h == null)
                {
                    return HttpNotFound();
                }
                return View(new HakkimizdaViewModel { Aciklama = h.Aciklama, ResimURL = h.ResimURL, HakkimizdaId = h.HakkimizdaId });
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateOrUpdate(HakkimizdaViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.HakkimizdaId == null)
                {
                    Hakkimizda entity = new Hakkimizda();
                    if (model.Resim != null)
                    {
                        WebImage img = new WebImage(model.Resim.InputStream);
                        FileInfo imginfo = new FileInfo(model.Resim.FileName);

                        string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                        //img.Resize(500, 500);
                        img.Save("~/Uploads/Hakkimizda/" + logoname);

                        entity.ResimURL = "/Uploads/Hakkimizda/" + logoname;
                    }
                    entity.Aciklama = model.Aciklama;
                    db.Hakkimizda.Add(entity);
                }
                else
                {
                    var hakkimizda = db.Hakkimizda.Find(model.HakkimizdaId);

                    if (model.Resim != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(hakkimizda.ResimURL)))
                        {
                            System.IO.File.Delete(Server.MapPath(hakkimizda.ResimURL));
                        }
                        WebImage img = new WebImage(model.Resim.InputStream);
                        FileInfo imginfo = new FileInfo(model.Resim.FileName);

                        string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                        //img.Resize(500, 500);
                        img.Save("~/Uploads/Hakkimizda/" + logoname);

                        hakkimizda.ResimURL = "/Uploads/Hakkimizda/" + logoname;
                    }

                    hakkimizda.Aciklama = model.Aciklama;

                }
                db.SaveChanges();
                return RedirectToAction("Index", "Hakkimizda");
            }

            return View(model);
        }


    }
}