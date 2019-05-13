using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebApi.Utils.Parsers
{
  public class StringFormDataParser: FormDataParser<string>
  {
    public override async Task<string> ParseDataAsync(HttpContent content)
    {
      return await content.ReadAsStringAsync();
    }
  }
}
