using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Web.Mvc;
using Board.Data;
using Board.Data.Models;
using Board.Data.Repos;
using Board.Web.Helpers;
using Board.Web.Models;

namespace Board.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepo repo = new UserRepo();
        private readonly PostRepo pRepo = new PostRepo();
        private readonly ReputationRepo repRepo = new ReputationRepo(); 

        public ActionResult Index()
        {
            var users = repo.Get();
            var viewModel = new List<UserIndexViewModel>();

            foreach (var item in users)
            {
                viewModel.Add(new UserIndexViewModel
                {

                });
            }

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserRegisterViewModel user)
        {

            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Username = user.Username,
                    EMail = user.EMail,
                    Password = user.Password,
                    Screenname = user.Screenname,
                    BirthDate = user.BirthDate,
                    Gender = user.Gender
                };

                repo.Add(newUser);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            return View(repo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(UserEditViewModel user)
        {
            if (ModelState.IsValid)
            {
                user.OriginalUser = repo.Get(Session["CurrentUser-Username"].ToString());
                User newUser = user.OriginalUser;
                newUser.Gender = user.Gender;
                newUser.Name = user.Name;
                newUser.Surname = user.Surname;
                newUser.Screenname = user.Screenname;
                newUser.Password = user.Password;
                repo.Edit(newUser);
                Session["CurrentUser-Screenname"] = newUser.Screenname;
                return RedirectToAction("UserPanel");
            }
            return RedirectToAction("UserPanel", user);
        }

        public ActionResult Delete(int id)
        {
            var user = repo.Get(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(User user)
        {
            repo.Drop(user);
            return RedirectToAction("Index");
        }

        public ActionResult Authenticate()
        {
            var model = new UserAuthModel();
            model.loginModel = new UserLoginViewModel();
            model.regModel = new UserRegisterViewModel();
            return View("Authenticate", model);
        }

        //public ActionResult Authenticate(UserAuthModel model)
        //{

        //}

        [HttpPost]
        public ActionResult Login(UserLoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var values = repo.Login(user.AuthString, user.AuthPass);
                    Session["CurrentUser-Username"] = values["Username"];
                    Session["CurrentUser-Screenname"] = values["Screenname"];
                    Session["CurrentUser-Admin"] = values["Admin"];
                    return RedirectToAction("Index", "Home");
                }
                catch (NoUserFoundException e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                }

            }
            return View("Authenticate", new UserAuthModel() { loginModel = user, regModel = new UserRegisterViewModel() });

        }

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                Create(user);
                return RedirectToAction("Authenticate");
            }
            return RedirectToAction("Authenticate", user);
        }

        [HttpPost]
        public JsonResult EmailAlreadyRegistered(string Email)
        {
            return Json(!repo.EmailTaken(Email));
        }

        [HttpPost]
        public JsonResult UsernameAlreadyRegistered(string Username)
        {
            return Json(!repo.UsernameTaken(Username));
        }

        [HttpPost]
        public JsonResult ScreennameAlreadyRegistered(string Screenname, string OriginalScreenname)
        {
            return Json(!repo.ScreennameTaken(Screenname, OriginalScreenname));
        }

        public ActionResult Logout()
        {
            Session["CurrentUser-Username"] = null;
            Session["CurrentUser-Screenname"] = null;
            Session["CurrentUser-Admin"] = null;
            return RedirectToAction("Authenticate");
        }

        public ActionResult AdminPanel()
        {
            if (Session["CurrentUser-Admin"].ToString() == "True")
            {
                return View("AdminPanel", new AdminViewModel());
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UserPanel()
        {
            if (Session["CurrentUser-Username"] != null)
            {
                var User = repo.Get(Session["CurrentUser-Username"].ToString());
                var Model = new UserPanelModel()
                {
                    NewComment = new Comment(),
                    User = User,
                    UserEdit = new UserEditViewModel()
                    {
                        Gender = User.Gender,
                        Name = User.Name,
                        Surname = User.Surname,
                        Screenname = User.Screenname,
                        OriginalUser = User
                    }
                };
                return View("UserPanel", Model);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult GrantRep(string target)
        {
            Reputation rep = new Reputation()
            {
                Amount = 1,
                Receiver = repo.Get(target),
                Sender = repo.Get(Session["CurrentUser-Username"].ToString())
            };
            repRepo.Add(rep);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult TakeRep(string target)
        {
            Reputation rep = new Reputation()
            {
                Amount = -1,
                Receiver = repo.Get(target),
                Sender = repo.Get(Session["CurrentUser-Username"].ToString())
            };
            repRepo.Add(rep);
            return new EmptyResult();
        }
    }
}
