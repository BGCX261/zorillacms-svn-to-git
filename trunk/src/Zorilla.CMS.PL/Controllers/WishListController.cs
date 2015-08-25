using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zorilla.CMS.BL.Entities;
using Zorilla.CMS.BL.Repositories;

namespace Zorilla.CMS.Controllers
{
    public class WishListController : Controller
    {
        private readonly IWishRepository wishRepository;

        public WishListController(IWishRepository wishRepository)
        {
            this.wishRepository = wishRepository;
        }

        //
        // GET: /WishList/

        public ActionResult Index()
        {
            return View(wishRepository.GetAll());
        }

        public ActionResult Reserve(long id)
        {
            return View(wishRepository.GetByPrimaryKey(id));
        }

        public ActionResult Cancel(long id)
        {
            return View(wishRepository.GetByPrimaryKey(id));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateReservation([Bind]Wish wish)
        {
            var existing = wishRepository.GetByPrimaryKey(wish.Id);
            if (existing.Reserved + wish.Reserved > existing.Amount)
                throw new Exception("Amount reserved exceeds amount wanted");
            existing.Reserved += wish.Reserved;
            existing.IP = Request.UserHostAddress;
            wishRepository.Update(existing);
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CancelReservation([Bind]Wish wish)
        {
            var existing = wishRepository.GetByPrimaryKey(wish.Id);
            if (existing.Reserved - wish.Reserved < 0 )
                throw new Exception("Amount reserved cannot be less than zero");
            existing.Reserved -= wish.Reserved;
            existing.IP = Request.UserHostAddress;
            wishRepository.Update(existing);
            return View();
        }
    }
}
