using System;
using System.Collections.Generic;
using System.Text;

public class PriceCalculator
{
    private decimal pricePerDay;
    private int numberOfDays;
    private SeasonsMultiplier season;
    private Discount discount;


    public PriceCalculator(string input)
    {
        var tokens = input
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var price = decimal.Parse(tokens[0]);
        var daysCount = int.Parse(tokens[1]);
        var seasonMultiplier = Enum.Parse<SeasonsMultiplier>(tokens[2]);
        Discount discountPercents = GetDiscountPercentage(tokens);

        this.pricePerDay = price;
        this.numberOfDays = daysCount;
        this.season = seasonMultiplier;
        this.discount = discountPercents;
    }

    public decimal CalculatePrice()
    {
        var priceNoDisc = this.pricePerDay * this.numberOfDays * (int)this.season;
        var discountFromPrice = ((int)this.discount / 100.0m) * priceNoDisc;
        var totalPriceToPay = priceNoDisc - discountFromPrice;

        return totalPriceToPay;
    }

    private static Discount GetDiscountPercentage(string[] tokens)
    {
        var discountPercents = Discount.None;

        if (tokens.Length > 3)
        {
            discountPercents = Enum.Parse<Discount>(tokens[3]);
        }

        return discountPercents;
    }
}
