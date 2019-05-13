using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using WebApi.Data;

namespace WebApi.Utils
{
  public class MultipartFormDataMediaTypeFormatter : MediaTypeFormatter
  {
    public MultipartFormDataMediaTypeFormatter()
    {
      SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
    }

    public override bool CanReadType(Type type)
    {
      return type == typeof(UserModel);
    }

    public override bool CanWriteType(Type type)
    {
      return false;
    }

    public override async Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
    {
      return new UserModel();
    }
  }
}
