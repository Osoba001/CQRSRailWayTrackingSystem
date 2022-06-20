using RailWayModelLibrary.Entities.Base;

namespace RailWayModelLibrary.Entities
{
    public class Payment:EntityBase,IBaseModel
    {
        public Payment()
        {

        }
        public Payment(Passenger passenger, decimal amount, BookedTrip bookedTrip, DateTime timeofpayment)
        {
            Passenger = passenger;
            BookedTrip = bookedTrip;
            Amount = amount;
            IsAprove = false;
            TimeOfPayment = timeofpayment;
        }
        public Passenger Passenger { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimeOfPayment { get; set; }
        public bool IsAprove { get; set; }
        public BookedTrip BookedTrip { get; set; }
    }
}
