using System;

namespace DiscountСalculator
{
    public class Product : IDiscount
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string DiscountType { get; set; }
        public int DiscountValue { get; set; }
        public int CardPoints { get; set; }
        public DateTime? StartSellDate { get; set; }
        public DateTime? EndSellDate { get; set; }

        public int CalculateDiscountPrice()
        {
            if (DiscountValue != 0 &&
                StartSellDate.HasValue &&
                EndSellDate.HasValue &&
                StartSellDate <= DateTime.UtcNow &&
                EndSellDate >= DateTime.UtcNow)
            {
                if (DiscountType == "процент") return Price - (Price * DiscountValue / 100);
                else return Price - DiscountValue;
            }
            else return Price;
        }

        public string GetSellInformation()
        {
            if (DiscountValue != 0 && StartSellDate.HasValue && EndSellDate.HasValue)
            {
                if (DiscountType == "сумма")
                    return $"На данный товар действует скидка {DiscountValue}р. в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                        $"Сумма с учётом скидки: {CalculateDiscountPrice()}р.";
                else if (DiscountType == "карта")
                    return $"На данный товар действует скидка {DiscountValue}р в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                        $"Сумма с учётом скидки: {CalculateDiscountPrice()}р." + $"На карте осталось: {CardPoints} рублей.";
                else if (DiscountType == "процент")
                    return $"На данный товар действует скидка {DiscountValue}% в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                        $"Сумма с учётом скидки: {CalculateDiscountPrice()}р.";
                else return "error";
            }
            else return "В настоящий момент на данный товар нет скидок.";
        }
    }
}