using SalaryPackagingCalculator.Models;

namespace SalaryPackagingCalculator.Services
{
    public class SalaryPackagingCalculator
    {
        public double CalculateSalaryPackagingLimit(Employee employee)
        {
            if (employee == null || employee.Salary <= 0)
                return 0;

            double limit = 0;

            switch (employee.CompanyType)
            {
                case "Corporate":
                    if (employee.EmploymentType == "Casual")
                    {
                        limit = 0;
                    }
                    else
                    {
                        double baseLimit = Math.Min(0.01 * employee.Salary, 100000) +
                                           Math.Max(0, (employee.Salary - 100000) * 0.001);

                        if (employee.EmploymentType == "Part-time")
                            baseLimit *= (employee.HoursWorked / 38.0);

                        limit = baseLimit;
                    }
                    break;

                case "Hospital":
                    double hospitalBase = Math.Max(10000, Math.Min(0.2 * employee.Salary, 30000));
                    if (employee.IsEducated)
                        hospitalBase += 5000;

                    if (employee.EmploymentType == "Full-time")
                    {
                        hospitalBase += 0.095 * hospitalBase + 0.012 * employee.Salary;
                    }

                    limit = hospitalBase;
                    break;

                case "PBI":
                    double pbiBase = Math.Min(50000, 0.3255 * employee.Salary);

                    if (employee.EmploymentType == "Casual")
                    {
                        limit = 0.1 * employee.Salary;
                    }
                    else if (employee.EmploymentType == "Part-time")
                    {
                        pbiBase *= 0.8;
                    }

                    if (employee.IsEducated)
                    {
                        pbiBase += 2000 + 0.01 * employee.Salary;
                    }

                    limit = pbiBase;
                    break;

                default:
                    return 0;
            }

            return limit;
        }
    }
}
