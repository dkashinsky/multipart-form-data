using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Data;

namespace WebApi.Controllers
{
  public class UploadController : ApiController
  {
    // GET api/upload
    public string Get()
    {
      return "test";
    }

    // POST api/upload
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public IHttpActionResult Post(UserModel userModel)
    {
      return Ok(userModel);
    }
  }
}
