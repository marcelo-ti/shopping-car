using System.ComponentModel;

namespace Klir.TechChallenge.Web.Api.Application.Domain.Enums
{
    [DefaultValue(UnmappedPromotion)]
    public enum Promotion
    {
        [Description("Unmapped Promotion")] UnmappedPromotion,
        [Description("Buy 1 Get 1 Free")] Buy1Get1Free,
        [Description("3 for 10 Euro")] Buy3For10Euro
    }
}