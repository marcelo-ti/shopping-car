using Klir.TechChallenge.Web.Api.Application.Domain.Enums;
using Klir.TechChallenge.Web.Api.Extensions;
using Xunit;

namespace Klir.TechChallenge.Tests.Extensions
{
    public class EnumExtensionsTests
    {
        [Fact(DisplayName = "Get Enum value from string")]
        public void GetEnumValueFromString()
        {
            // Arrange & Act
            var promotion = EnumExtensions.GetValueFromDescription<Promotion>("Buy 1 Get 1 Free");

            // Assert
            Assert.Equal(Promotion.Buy1Get1Free, promotion);
        }

        [Fact(DisplayName = "When string description doesn't exists on Enum, return default")]
        public void ReturnDefaultFromEnum()
        {
            // Arrange & Act
            var promotion = EnumExtensions.GetValueFromDescription<Promotion>("Test");

            // Assert
            Assert.Equal(Promotion.UnmappedPromotion, promotion);
        }

        [Fact(DisplayName = "Get description from Enum")]
        public void GetDescriptionFromEnum()
        {
            // Arrange & Act
            var description = Promotion.Buy1Get1Free.GetDescription();

            // Assert
            Assert.Equal("Buy 1 Get 1 Free", description);
        }
    }
}