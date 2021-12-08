using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Klir.TechChallenge.Web.Api.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            return enumValue is null
                ? string.Empty
                : enumValue.GetType()
                    .GetMember(enumValue.ToString())
                    .First()
                    .GetCustomAttribute<DescriptionAttribute>()?
                    .Description ?? string.Empty;
        }
    }
}