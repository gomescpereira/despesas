using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fina.Core.Requests.Reporters
{
    public class GetIncomesExpansesByCategoryRequest: Request
    {
       public DateTime? StartDate { get; set; }
       public DateTime? EndDate { get; set; }
    }
}