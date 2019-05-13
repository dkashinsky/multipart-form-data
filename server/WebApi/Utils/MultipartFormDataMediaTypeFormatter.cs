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
      var customAttributes = type.GetCustomAttributes(typeof(MultipartFormDataAttribute), false);
      return customAttributes.Any();
    }

    public override bool CanWriteType(Type type)
    {
      return false;
    }

    public override async Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
    {
      if (!content.IsMimeMultipartContent())
        return null;

      var provider = await content.ReadAsMultipartAsync();

      var instance = Activator.CreateInstance(type);
      foreach (var propertyInfo in type.GetProperties())
      {
        var formDataAttribute = propertyInfo.GetCustomAttributes(typeof(FormDataAttribute), false).FirstOrDefault() as FormDataAttribute;
        if (formDataAttribute != null)
        {
          var parser = formDataAttribute.GetParser(propertyInfo.PropertyType);
          var formData = provider.GetFormData(formDataAttribute.Name);
          if (formData != null)
            propertyInfo.SetValue(instance, await parser.ParseAsync(formData));
        }
      }

      return instance;
    }
  }

  public static class Extenstions
  {
    public static HttpContent GetFormData(this MultipartMemoryStreamProvider provider, string formDataKey)
    {
      return provider.Contents.FirstOrDefault(c => formDataKey.Equals(Normalize(c.Headers.ContentDisposition.Name), StringComparison.OrdinalIgnoreCase));
    }

    public static string Normalize(this string text)
    {
      if (string.IsNullOrWhiteSpace(text))
        return text;

      return text.Replace("\"", "");
    }
  }
}
