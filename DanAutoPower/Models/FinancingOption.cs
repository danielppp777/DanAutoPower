using System.ComponentModel.DataAnnotations;

namespace DanAutoPower.Models
{
    public class FinancingOption
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal InterestRate { get; set; }
        public int DurationMonths { get; set; }
    }

    public class FinancingCalculator
    {
        public decimal CalculateMonthlyPayment(decimal carPrice, decimal interestRate, int durationMonths)
        {
            decimal monthlyRate = interestRate / 12 / 100;
            return carPrice * monthlyRate / (1 - (decimal)Math.Pow((double)(1 + monthlyRate), -durationMonths));
        }
    }
}
