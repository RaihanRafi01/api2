using api2.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api2.Controllers
{
    public class CategoryController : ApiController
    {
            [HttpGet]
            [Route("api/category")]
            public HttpResponseMessage All()
            {
                var db = new Api2Entities1();
                var data = db.Categories.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            [HttpPost]
            [Route("api/category/create")]
            public HttpResponseMessage Create(Category obj)
            {
                var db = new Api2Entities1();
                try
                {

                    db.Categories.Add(obj);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            [HttpPost]
            [Route("api/category/update")]
            public HttpResponseMessage Update(Category upd)
            {
                var db = new Api2Entities1();
                var exobj = db.Categories.Find(upd.Id);
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
            [Route("api/category/delete")]
            public HttpResponseMessage Delete(Category upd)
            {
                var db = new Api2Entities1();
                var exobj = db.Categories.Find(upd.Id);
                db.Categories.Remove(exobj);
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
