using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebApi.Utils.Parsers
{
  public class DateTimeFormDataParser: FormDataParser<DateTime?>
  {
    public override async Task<DateTime?> ParseDataAsync(HttpContent content)
    {
      var formData = await content.ReadAsStringAsync();

      if (DateTime.TryParse(formData, out DateTime result))
        return result;

      return null;
    }
  }
}
