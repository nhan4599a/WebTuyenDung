using System.Text.RegularExpressions;

namespace WebTuyenDung.Helper
{
    public static partial class SalaryHelper
    {
        [GeneratedRegex(@"^(\d+) - (\d+) triệu$")]
        private static partial Regex SalaryRegex();

        public static (int? MinimumSalary, int? MaximumSalary) ParseSalary(string salary)
        {
            if (salary == "Thỏa thuận")
            {
                return (null, null);
            }

            if (salary.StartsWith("Dưới"))
            {
                return (0, int.Parse(salary[5..^6]));
            }
            else if (salary.StartsWith("Trên"))
            {
                return (int.Parse(salary[5..^6]), null);
            }

            var salaryGroups = SalaryRegex().Match(salary).Groups;

            return (int.Parse(salaryGroups[1].ValueSpan), int.Parse(salaryGroups[2].ValueSpan));
        }
    }
}
