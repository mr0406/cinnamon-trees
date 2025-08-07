namespace CinnamonTrees.Samples.Discounts;

public record DiscountInput(
    decimal OrderValue,
    CustomerStatus Status);