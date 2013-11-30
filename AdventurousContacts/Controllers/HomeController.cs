using ContactLab.Models;
using ContactLab.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactLab.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController()
            : this(new Repository())
        {

        }

        public HomeController(IRepository rep) {
            repository = rep;
        }

        public ActionResult Index()
        {
            return View(repository.GetContacts(20));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ContactId")]Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.AddContact(contact);
                    repository.Save();
                    return View("Saved", contact);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då kontakten skulle sparas.");
            }

            return View(contact);
        }

        public ActionResult Edit(int id)
        {
            Contact contact = repository.GetContactById(id);

            if (contact == null)
            {
                return View("NotFound");
            }

            return View(contact);
        }

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.UpdateContact(contact);
                    repository.Save();
                    return View("Saved", contact);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då kontakten skulle sparas.");
            }

            return View(contact);
        }

        public ActionResult Delete(int id = 0)
        {
            Contact contact = repository.GetContactById(id);

            if (contact == null) {
                return View("NotFound");
            }

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                repository.DeleteContact(id);
                repository.Save();
                return View("Deleted");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då kontaken skulle tas bort.");
            }

            return View(repository.GetContactById(id));
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
