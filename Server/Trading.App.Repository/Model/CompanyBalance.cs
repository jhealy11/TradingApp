using System.ComponentModel.DataAnnotations;

namespace Trading.App.Repository.Model
{
    public sealed class CompanyBalance
    {
        [Key]
        public Guid Id { get; set; }

        [Range(0,16)]
        public decimal Balance { get; set; }
    }
}
