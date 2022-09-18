using DEDSEC.Domain.Models;
using DEDSEC.WPF.ViewModels.Donations.Donations;
using System.Collections.Generic;
using System.Linq;

namespace DEDSEC.WPF.Extensions
{
    public static class DonationExtensions
    {
        public static string SetTitleDisplay(this DonationGoal donationGoal) 
            => !string.IsNullOrEmpty(donationGoal.Title) ? donationGoal.Title : "Без названия";

        public static string SetDescriptionDisplay(this DonationGoal donationGoal)
            => !string.IsNullOrEmpty(donationGoal.Description) ? donationGoal.Description : "Без описания";

        public static string SetTargetDisplay(this DonationGoal donationGoal)
            => donationGoal.CurrentValue + " / " + donationGoal.TargetValue;

        public static string SetDonationViewModelsCountDisplay(this IEnumerable<DonationViewModel> donationViewModels)
        {
            var count = donationViewModels.Count();
            return count + " " + Pluralize(count);
        }

        private static string Pluralize(int num)
        {
            if (num % 10 == 1 && num != 11)
            {
                return "донат";
            }
            else if (num <= 4 && num >= 2 || num % 10 <= 4 && num % 10 >= 2 && num < 12 && num > 14)
            {
                return "доната";
            }
            else
            {
                return "донатов";
            }
        }
    }
}
