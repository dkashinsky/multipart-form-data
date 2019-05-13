using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebApi.Data;

namespace WebApi.Utils.Parsers
{
  public class FileInfoFormDataParser: FormDataParser<FileInfo>
  {
    public override async Task<FileInfo> ParseDataAsync(HttpContent content)
    {
      if (!string.IsNullOrEmpty(content.Headers.ContentDisposition.FileName))
      {
        return new FileInfo()
        {
          FileName = Extenstions.Normalize(content.Headers.ContentDisposition.FileName),
          FileData = await content.ReadAsByteArrayAsync()
        };
      }

      return null;
    }
  }
}
