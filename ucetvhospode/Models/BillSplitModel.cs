using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ucetvhospode.Models
{
    public class BillSplitModel
    {
        public decimal BillAmount { get; set; }
        public decimal TipPercentage { get; set; }
        public int NumberOfGuests { get; set; } = 1;

        public decimal TotalAmount => BillAmount * (1 + TipPercentage / 100);

        public decimal Share => NumberOfGuests > 0 ? BillAmount / NumberOfGuests : 0;

        public decimal ShareWithTip => NumberOfGuests > 0 ? TotalAmount / NumberOfGuests : 0;
    }
}
