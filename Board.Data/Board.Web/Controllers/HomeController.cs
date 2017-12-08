using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Board.Data.Models;
using Board.Data.Repos;
using Board.Web.Models;

namespace Board.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly UserRepo uRepo = new UserRepo();
        readonly ChannelRepo cRepo = new ChannelRepo();
        public ActionResult Index()
        {
            var vModel = new HomeViewModel();
            vModel.Channels = new PVMChannels(){Channels = cRepo.Get(), CurrentChannel = cRepo.Get()[0].Id};
            vModel.TopUsers = uRepo.GetTop();
            return View(vModel);
        }
    }
}