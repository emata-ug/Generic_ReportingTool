using System;

namespace Domain.Sales
{
    public class Sale
    {
        public Guid Id { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public string ItemType { get; set; }

        public string Channel { get; set; }

        public string OrderPriority { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderId { get; set; }

        public DateTime ShipDate { get; set; }

        public int UnitsSold { get; set; }

        public decimal UnitCost { get; set; }

        public decimal TotalRevenue { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalProfit { get; set; }
    }
}
