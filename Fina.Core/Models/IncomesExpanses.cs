using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fina.Core.Models;

    public class IncomesExpanses
    {
          
        public string UserId { get; set; } = string.Empty;    
        public string Mes { get; set; } = string.Empty;
        public string Ano { get; set; } = string.Empty;
        public decimal Incomes { get; set; } = 0;
        public decimal Expanse { get; set; } = 0;
        
    }
    
