namespace Fina.Core.Models;

    public class Expanse
    {
        public string UserId { get; set; } = string.Empty;    
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;
        public decimal Avarage { get; set; } = 0;
        public bool Pay { get; set; } = false;
    }
