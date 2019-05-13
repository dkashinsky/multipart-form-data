using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Data
{
  public class UserModel
  {
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public HttpPostedFile Avatar { get; set; }
    public HttpPostedFile CV { get; set; }
   
    //formData.append('name', userModel.name);
    //formData.append('date', userModel.date);
    //formData.append('avatarFile', userModel.avatar, userModel.avatar.name);
    //formData.append('cvFile', userModel.cv, userModel.cv.name);
  }
}
