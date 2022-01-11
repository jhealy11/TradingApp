using System;
using System.ComponentModel.DataAnnotations;

namespace Trading.App.Repository.Model
{
    public sealed class Trade
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Security { get; set; }
        
        [Required]
        public DateTime TradeDate { get; set; }
        
        [Required]
        public TradeType TradeType { get; set; }
        
        [Required]
        [Range(1, 16)]
        public decimal Price { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        [Range(1, 16)]
        public decimal Total { get; set; }
    }
}
