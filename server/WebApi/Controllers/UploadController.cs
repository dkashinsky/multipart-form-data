using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
    public IHttpActionResult Post([FromBody]string value)
    {
      return Ok(new { test = 123 });
    }
  }
}
