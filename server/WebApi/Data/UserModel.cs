using System;
using System.Web;
using WebApi.Utils;
using WebApi.Utils.Parsers;

namespace WebApi.Data
{
  [MultipartFormData]
  public class UserModel
  {
    [FormData(Name = "name")]
    public string Name { get; set; }

    [FormData(Name = "date")]
    public DateTime? DateOfBirth { get; set; }

    [FormData(Name = "avatarFile", Parser = typeof(FileInfoFormDataParser))]
    public FileInfo Avatar { get; set; }

    [FormData(Name = "cvFile", Parser = typeof(FileInfoFormDataParser))]
    public FileInfo CV { get; set; }
  }

  public class FileInfo
  {
    public string FileName { get; set; }
    public byte[] FileData { get; set; }
  }
}
