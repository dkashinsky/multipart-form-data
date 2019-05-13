using System;
using System.Web;
using WebApi.Utils;

namespace WebApi.Data
{
  [MultipartFormData]
  public class UserModel
  {
    [FormData(Name = "name")]
    public string Name { get; set; }

    [FormData(Name = "date")]
    public DateTime DateOfBirth { get; set; }

    [FormData(Name = "avatarFile")]
    public HttpPostedFile Avatar { get; set; }

    [FormData(Name = "cvFile")]
    public HttpPostedFile CV { get; set; }
  }
}
