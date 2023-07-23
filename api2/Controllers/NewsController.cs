using api2.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api2.Controllers
{
    public class NewsController : ApiController
    {
        [HttpGet]
        [Route("api/news")]
        public HttpResponseMessage AllNews()
        {
            var dba = new Api2Entities1();
            var data = dba.News.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/news/create")]
        public HttpResponseMessage CreateNews(News obj)
        {
            var db = new Api2Entities1();
            try
            {

                db.News.Add(obj);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/news/update")]
        public HttpResponseMessage UpdateNews(News upd)
        {
            var db = new Api2Entities1();
            var exobj = db.News.Find(upd.Id);
            db.Entry(exobj).CurrentValues.SetValues(upd);
            try
            {

                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [HttpPost]
        [Route("api/news/delete")]
        public HttpResponseMessage DeleteNews(News upd)
        {
            var db = new Api2Entities1();
            var exobj = db.News.Find(upd.Id);
            db.News.Remove(exobj);
            try
            {

                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}

