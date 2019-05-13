using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.Utils
{
  public interface IFormDataParser
  {
    Task<object> ParseAsync(HttpContent content);
  }

  public abstract class FormDataParser<T> : IFormDataParser
  {
    public async Task<object> ParseAsync(HttpContent content)
    {
      return await ParseDataAsync(content);
    }

    public abstract Task<T> ParseDataAsync(HttpContent content);
  }
}
