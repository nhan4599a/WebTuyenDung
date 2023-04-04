using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using WebTuyenDung.Helper;

namespace WebTuyenDung.Data.Conversions
{
    public class NullableDateOnlyConverter : ValueConverter<DateOnly?, string?>
    {
        public NullableDateOnlyConverter()
            : base(
                  e => e.HasValue ? e.GetApplicationTimeRepresentation() : null,
                  e => e != null ? e.ToDateOnly() : null)
        {
        }
    }
}
