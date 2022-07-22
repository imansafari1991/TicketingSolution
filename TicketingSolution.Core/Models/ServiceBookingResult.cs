using TicketingSolution.Core.Enums;
using TicketingSolution.Domain;

namespace TicketingSolution.Core.Models
{
    public class ServiceBookingResult : ServiceBookingBase
    {
        public BookingResultFlag Flag { get; set; }
        public int? TicketBookingId { get; set; }
    }
}