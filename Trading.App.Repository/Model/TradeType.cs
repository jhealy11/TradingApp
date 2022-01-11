using System.ComponentModel.DataAnnotations;


namespace Trading.App.Repository.Model
{
    public class TradeType
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Description { get; set; }
    }
}
