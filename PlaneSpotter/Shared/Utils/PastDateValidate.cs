using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.Shared.Utils
{
    internal class PastDateValidate :ValidationAttribute
    {
        private readonly DateTime nowDateTime = DateTime.UtcNow;

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool IsValid(object value)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        {
            DateTime val = (DateTime)value;
            return val.ToUniversalTime() <= nowDateTime; 
        }
    }
}
