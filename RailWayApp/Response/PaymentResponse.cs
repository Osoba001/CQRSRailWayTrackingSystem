using RailWayModelLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Response
{
    public class PaymentResponse:EntityBase
    {
        public Guid PaymentID { get; set; }
        public string PassengerName { get; set; }
        public DateTime TripDate { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimeOfPayment { get; set; }
        public bool IsAprove { get; set; }
    }
}
