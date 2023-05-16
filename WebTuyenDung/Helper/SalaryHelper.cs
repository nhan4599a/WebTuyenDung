using System;
using System.Text.RegularExpressions;
using WebTuyenDung.ViewModels.User.Abstraction;

namespace WebTuyenDung.Helper
{
    public static partial class SalaryHelper
    {
        [GeneratedRegex(@"^(\d+) - (\d+) triệu$")]
        private static partial Regex SalaryRegex();

        public static (uint? MinimumSalary, uint? MaximumSalary) ParseSalary(string salary)
        {
            try
            {
                if (salary == "Thỏa thuận")
                {
                    return (null, null);
                }

                if (salary.StartsWith("Dưới"))
                {
                    return (0, uint.Parse(salary[5..^6]));
                }
                else if (salary.StartsWith("Trên"))
                {
                    return (uint.Parse(salary[5..^6]), null);
                }

                var salaryGroups = SalaryRegex().Match(salary).Groups;

                return (uint.Parse(salaryGroups[1].ValueSpan), uint.Parse(salaryGroups[2].ValueSpan));
            }
            catch (Exception)
            {
                return (null, null);
            }
        }

        public static string GetSalaryRepresentation(this BaseRecruimentNewsViewModel viewModel)
        {
            if (viewModel.Salary != "Khác")
            {
                return viewModel.Salary;
            }

            if (viewModel.MinimumSalary.HasValue && viewModel.MaximumSalary.HasValue)
            {
                return $"Từ {viewModel.MinimumSalary} đến {viewModel.MaximumSalary} triệu";
            }
            else if (viewModel.MinimumSalary.HasValue)
            {
                return $"Từ {viewModel.MinimumSalary} triệu";
            }
            else
            {
                return $"Upto {viewModel.MaximumSalary} triệu";
            }
        }
    }
}
