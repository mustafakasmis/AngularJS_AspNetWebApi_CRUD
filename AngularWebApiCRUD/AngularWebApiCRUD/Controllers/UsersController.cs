using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularWebApiCrudOperations.Models;

namespace AngularWebApiCrudOperations.Controllers
{

    public class UsersController : ApiController
    {

        private DbProcess dbProcess = new DbProcess();

        // GET: api/Users
        public IEnumerable<User> Get()
        {
            return dbProcess.users.AsEnumerable();   
        }

        // GET: api/Users/5
        public HttpResponseMessage Get(int? id)
        {
            if (dbProcess.users.FirstOrDefault(x => x.id == id) != null)
                return Request.CreateResponse(HttpStatusCode.OK, dbProcess.users.FirstOrDefault(x => x.id == id));

            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "USER NOT FOUND");

        }

        // POST: api/Users
        public HttpResponseMessage Post([FromBody] User u)
        {
            
           if (u != null)
             {
               dbProcess.users.Add(u);
               dbProcess.SaveChanges();
               return Request.CreateResponse(HttpStatusCode.OK, dbProcess.users.AsEnumerable());
             }


           else
               return Request.CreateErrorResponse(HttpStatusCode.NotFound, "USER NOT ADD ");

        }

        // PUT: api/Users/5
        public HttpResponseMessage Put(int? id, [FromBody]User u)
        {
            if (id!=null && u != null)
            {
                User usr = dbProcess.users.FirstOrDefault(x => x.id == id);

                if (usr != null)
                {
                    usr.id = u.id;
                    usr.name = u.name;
                    usr.surname = u.surname;

                    dbProcess.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, dbProcess.users.AsEnumerable()); 
                }

                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "USER NOT FOUND"); ;
                }
            }

            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "USER NOT EDIT ");
        }

        // DELETE: api/Users/5
        public HttpResponseMessage Delete(int? id)
        {
            if (id!=null && dbProcess.users.FirstOrDefault(x => x.id == id) != null)
            {
                dbProcess.users.Remove(dbProcess.users.FirstOrDefault(x => x.id == id));
                dbProcess.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, dbProcess.users.AsEnumerable());
            }

            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "USER NOT REMOVE "); ;
        }

    }

}
