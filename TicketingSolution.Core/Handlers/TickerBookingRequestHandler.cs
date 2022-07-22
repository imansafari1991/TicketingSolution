using TicketingSolution.Core.DataServices;

using TicketingSolution.Core.Enums;
using TicketingSolution.Core.Models;
using TicketingSolution.Domain;

namespace TicketingSolution.Core.Handlers
{
    public class TickerBookingRequestHandler
    {
        private readonly ITicketBookingService _ticketBookingService;
        public TickerBookingRequestHandler(ITicketBookingService ticketBookingService)
        {
            _ticketBookingService = ticketBookingService;
        }

        public ServiceBookingResult BookService(TicketBookingRequest bookingRequest)
        {
            if (bookingRequest is null)
            {
                throw new ArgumentNullException("request");
            }

            var availabeTickets = _ticketBookingService.GetAvailabeTickets(bookingRequest.Date);
            var result= CreateTicketBookingObject<ServiceBookingResult>(bookingRequest);
            if (availabeTickets.Any())
            {
                var Ticket = availabeTickets.First();
                var TicketBooking = CreateTicketBookingObject<TicketBooking>(bookingRequest);
                TicketBooking.TicketID = Ticket.Id;
                _ticketBookingService.Save(TicketBooking);
                result.TicketBookingId = TicketBooking.TicketID;
                result.Flag = BookingResultFlag.Success;

            }
            else
            {
                result.Flag = BookingResultFlag.Failure;
            }
            return result;
        }


        private static TTicketBooking CreateTicketBookingObject<TTicketBooking>(TicketBookingRequest bookingRequest) where TTicketBooking :
            ServiceBookingBase, new()
        {
            return new TTicketBooking
            {
                Name = bookingRequest.Name,
                Family = bookingRequest.Family,
                Email = bookingRequest.Email
            };
        }
    }
}