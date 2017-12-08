using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Board.Data.Models;
using Board.Data.Repos;
using Board.Web.Models;

namespace Board.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentRepo cRepo = new CommentRepo();
        private readonly PostRepo pRepo = new PostRepo();
        private readonly UserRepo uRepo = new UserRepo();
        private readonly ChannelRepo chRepo = new ChannelRepo();
        // GET: Comment
        public ActionResult Index(int postId)
        {
            List<Comment> Comments = cRepo.Get(pRepo.Get(postId));


            var top = uRepo.GetTop();
            var extras = new Dictionary<string, int>();

            extras.Add(top[0].Username, 0);
            extras.Add(top[1].Username, 1);
            extras.Add(top[2].Username, 2);
            extras.Add(top[3].Username, 3);
            extras.Add(top[4].Username, 4);

            List<CVMExtra> CVM = new List<CVMExtra>();
            foreach (var i in Comments)
            {
                if (extras.ContainsKey(i.User.Username))
                {
                    CVM.Add(new CVMExtra() { Comment = i, CommentRating = extras[i.User.Username] });
                }
                else
                {
                    CVM.Add(new CVMExtra() { Comment = i, CommentRating = 10 });
                }
            }
            return PartialView("CommentIndexPartial", CVM);
        }


        public ActionResult CreateForm(int postId)
        {
            var Model = new CommentCreateViewModel()
            {
                PostId = postId
            };

            return PartialView("Create", Model);
        }

        [HttpPost]
        public ActionResult Create(CommentCreateViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var newComment = new Comment();
                newComment.User = uRepo.Get(Session["CurrentUser-Username"].ToString());
                newComment.Content = comment.Content;
                newComment.Post = pRepo.Get(comment.PostId);
                cRepo.Add(newComment);
                return new EmptyResult();
            }
            return View(comment);
        }

        [HttpPost]
        public ActionResult Delete(int comment)
        {
            cRepo.Drop(comment);
            return new EmptyResult();
        }


        [HttpPost]
        public ActionResult Edit(int commentId, string content)
        {
            if (content != null)
            {
                var newComment = new Comment
                {
                    Content = content,
                    Id = commentId
                };
                cRepo.Edit(newComment);
                return new EmptyResult();
            }
            return new EmptyResult();
        }
    }
}