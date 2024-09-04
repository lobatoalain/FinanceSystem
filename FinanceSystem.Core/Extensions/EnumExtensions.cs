using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FinanceSystem.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string? GetDisplayName(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var displayAttribute = fieldInfo?.GetCustomAttribute<DisplayAttribute>();

            return displayAttribute != null ? displayAttribute.Name : value.ToString();
        }
    }
}
