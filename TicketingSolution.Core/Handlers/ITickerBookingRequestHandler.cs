using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSolution.Core.Models;
using TicketingSolution.Domain;

namespace TicketingSolution.Core.Handlers;
public interface ITickerBookingRequestHandler
{

    ServiceBookingResult BookService(TicketBookingRequest bookingRequest);

}
