using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Board.Data.Models;
using Board.Data.Repos;

namespace Board.Web.Controllers
{
    public class ChannelController : Controller
    {
        private readonly ChannelRepo cRepo = new ChannelRepo();
        public ActionResult Delete(int id)
        {
            cRepo.Drop(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Create(Channel channel)
        {
            if (ModelState.IsValid)
            {
                cRepo.Add(channel);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}