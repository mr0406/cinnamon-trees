using Shouldly;

namespace CinnamonTrees.Samples.Discounts.Tests;

public class EvaluationDiscountTreeTests
{
    [Test]
    public void GivenLoyalCustomer_WithOrderAbove500_ThenEvaluateDiscountTree_ThenShouldGetBigDiscount_AndCorrectPath()
    {
        // Given
        var input = new DiscountInput(OrderValue: 600, Status: CustomerStatus.Loyal);

        // When
        var result = DiscountTreeBuilder.Build().Evaluate(input);

        // Then
        result.Result.ShouldBe(DiscountType.BigDiscount);
        result.Path.ShouldBe(new[] { 1, 1 });
    }

    [Test]
    public void GivenLoyalCustomer_WithOrderBetween200And500_WhenEvaluateDiscountTree_ThenShouldGetSmallDiscount_AndCorrectPath()
    {
        // Given
        var input = new DiscountInput(OrderValue: 300, Status: CustomerStatus.Loyal);

        // When
        var result = DiscountTreeBuilder.Build().Evaluate(input);

        // Then
        result.Result.ShouldBe(DiscountType.SmallDiscount);
        result.Path.ShouldBe(new[] { 1, 2 });
    }

    [Test]
    public void LoyalCustomer_WithOrderBelow200_WhenEvaluateDiscountTree_ThenShouldGetNoDiscount_AndCorrectPath()
    {
        // Given
        var input = new DiscountInput(OrderValue: 100, Status: CustomerStatus.Loyal);

        // When
        var result = DiscountTreeBuilder.Build().Evaluate(input);

        // Then
        result.Result.ShouldBe(DiscountType.NoDiscount);
        result.Path.ShouldBe(new[] { 1, 0 });
    }

    [Test]
    public void NewCustomer_WithAnyOrder_WhenEvaluateDiscountTree_ThenShouldGetNoDiscount_AndCorrectPath()
    {
        // Given
        var input = new DiscountInput(OrderValue: 999, Status: CustomerStatus.New);

        // When
        var result = DiscountTreeBuilder.Build().Evaluate(input);

        // Then
        result.Result.ShouldBe(DiscountType.NoDiscount);
        result.Path.ShouldBe(new[] { 0 });
    }
}