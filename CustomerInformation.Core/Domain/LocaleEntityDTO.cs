

using CustomerInformation.Core.CQRS.Contracts;
using HR.Harmony.Core.Data.Contracts;

namespace HR.Harmony.Core.CQRS.Domain
{
    public class LocaleEntityDTO : IDTO, ILocalizable
    {
        public int LanguageRef { get; set; }
        public string Content { get; set; }
    }
}