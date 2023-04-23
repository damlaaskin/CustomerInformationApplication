using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Harmony.Core.Data.Contracts
{
    public interface ILocalizable
    {
        int LanguageRef { get; set; }
    }
}