using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Utils.Parsers;

namespace WebApi.Utils
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public class FormDataAttribute : Attribute
  {
    public string Name { get; set; }
    public Type Parser { get; set; }

    private static readonly Dictionary<Type, IFormDataParser> KnownParsers = new Dictionary<Type, IFormDataParser>();
    private static readonly Dictionary<Type, IFormDataParser> KnownTypes = new Dictionary<Type, IFormDataParser>()
    {
      { typeof(string), new StringFormDataParser() },
      { typeof(DateTime?), new DateTimeFormDataParser() }
    };

    public IFormDataParser GetParser(Type propertyType)
    {
      if (Parser != null)
        return ResolveParser(Parser);

      if (KnownTypes.ContainsKey(propertyType))
        return KnownTypes[propertyType];

      throw new Exception("Unable to resolve data parser");
    }

    private IFormDataParser ResolveParser(Type parserType)
    {
      if (KnownParsers.ContainsKey(parserType))
        return KnownParsers[parserType];

      var parser = Activator.CreateInstance(parserType) as IFormDataParser;
      KnownParsers.Add(parserType, parser);
      return parser;
    }
  }
}
