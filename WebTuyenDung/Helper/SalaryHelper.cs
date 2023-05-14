using System;
using System.Text.RegularExpressions;
using WebTuyenDung.ViewModels.User.Abstraction;

namespace WebTuyenDung.Helper
{
    public static class SalaryHelper
    {
        //[GeneratedRegex(@"^(\d+) - (\d+) triệu$")]
        //private static partial Regex SalaryRegex();
        private static Regex SalaryRegex = new Regex(@"^(\d+) - (\d+) triệu$", RegexOptions.Compiled);

        public static (int? MinimumSalary, int? MaximumSalary) ParseSalary(string salary)
        {
            try
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

                var salaryGroups = SalaryRegex.Match(salary).Groups;

                return (int.Parse(salaryGroups[1].ValueSpan), int.Parse(salaryGroups[2].ValueSpan));
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
