using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Utils
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
  public class MultipartFormDataAttribute : Attribute
  {
  }
}
