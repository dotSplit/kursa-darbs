using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Board.Data.Models;
using Board.Data.Repos;
using Board.Web.Models;

namespace Board.Web.Controllers
{
    public class PostController : Controller
    {
        readonly PostRepo repo = new PostRepo();
        readonly UserRepo uRepo = new UserRepo();
        readonly ChannelRepo cRepo = new ChannelRepo();

        // GET: Post
        public ActionResult Index(int chn)
        {
            var posts = new List<Post>();
            posts = repo.Get(cRepo.Get(chn));
            posts.OrderByDescending(c => c.Date).ThenByDescending(c => c.Id).ToList();

            var channels = cRepo.Get();
            var PVMC = new PVMChannels() {Channels = channels, CurrentChannel = chn, NewChannel = new Channel()};

            var top = uRepo.GetTop();
            var extras = new Dictionary<string,int>();

            extras.Add(top[0].Username, 0);
            extras.Add(top[1].Username, 1);
            extras.Add(top[2].Username, 2);
            extras.Add(top[3].Username, 3);
            extras.Add(top[4].Username, 4);

            List<PVMExtra> PVME = new List<PVMExtra>();
            foreach (var i in posts)
            {
                if (extras.ContainsKey(i.User.Username))
                {
                    PVME.Add(new PVMExtra() {Post = i, PostRating = extras[i.User.Username]});
                }
                else
                {
                    PVME.Add(new PVMExtra() {Post = i, PostRating = 10});
                }
            }


            var vModel = new PostViewModel() {Posts = PVME, ChannelModel = PVMC, NewPost = new PostCreateViewModel(){Channel = chn}, NewComment = new Comment()};
            return View(vModel);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        public ActionResult Create(int channelId)
        {
            var Model = new PostCreateViewModel();
            Model.Channel = channelId;
            return View(Model);
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(PostCreateViewModel post)
        {
            if (ModelState.IsValid)
            {
                Post newPost = new Post
                {
                    Title = post.Title,
                    Content = post.Content,
                    Channel = cRepo.Get(post.Channel),
                    User = uRepo.Get(Session["CurrentUser-Username"].ToString()),
                    Date = DateTime.Now
                };
                repo.Add(newPost);
                return RedirectToAction("Index", "Post", new {chn = post.Channel});
            }
            return View();
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int editPost)
        {
            var editablePost = repo.Get(editPost);
            PostEditModel editModel = new PostEditModel();
            editModel.Id = editablePost.Id;
            editModel.Content = editablePost.Content;
            editModel.Title = editablePost.Title;

            return PartialView("~/Views/Post/EditPartial.cshtml", editModel);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(PostEditModel Post)
        {
            string message = "";
            try
            {
                var editPost = repo.Get(Post.Id);
                editPost.Content = Post.Content;
                editPost.Title = Post.Title;
                repo.Edit(editPost);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int post, int returningChannel)
        {
            repo.Drop(post);
            return RedirectToAction("Index", "Post", new { chn = returningChannel });
        }
    }
}
