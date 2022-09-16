namespace Trading.App.Model
{
    public sealed class TradeViewModel
    {
        public Guid? Id { get; set; }
        public string Security { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string BuySell { get; set; }
        public DateTime TradeDate { get; set; }
    }
}