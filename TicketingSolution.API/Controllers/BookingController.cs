using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingSolution.Core.Handlers;
using TicketingSolution.Domain;

namespace TicketingSolution.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly ITickerBookingRequestHandler _tickerBookingRequestHandler;

    public BookingController(ITickerBookingRequestHandler tickerBookingRequestHandler)
    {
        _tickerBookingRequestHandler = tickerBookingRequestHandler;
    }


    public async Task<IActionResult> Book(TicketBookingRequest request)
    {
        if (ModelState.IsValid)
        {
            var result = _tickerBookingRequestHandler.BookService(request);
            if (result.Flag == Core.Enums.BookingResultFlag.Success)
            {
                return Ok(result);
            }

            ModelState.AddModelError(nameof(TicketBookingRequest.Date), "No Ticket Available For Given Date");
        }

        return BadRequest(ModelState);
    }

}
