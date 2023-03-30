using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using WebTuyenDung.Helper;

namespace WebTuyenDung.Data.Conversions
{
    public class DateOnlyConverter : ValueConverter<DateOnly, string>
    {
        public DateOnlyConverter()
            : base(
                  e => e.GetApplicationTimeRepresentation(),
                  e => e.ToDateOnly())
        {
        }
    }
}
