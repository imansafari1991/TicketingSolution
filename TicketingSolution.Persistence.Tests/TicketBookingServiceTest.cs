﻿
using Microsoft.EntityFrameworkCore;
using TicketingSolution.Domain;
using TicketingSolution.Persistence.Repositories;
using Xunit;

namespace TicketingSolution.Persistence.Tests;

public class TicketBookingServiceTest
{
    [Fact]
    public void Should_Return_Available_Services()
    {
        //Arrange
        var date = new DateTime(2022, 07, 15);

        var dbOptions = new DbContextOptionsBuilder<TicketingSolutionDbContext>()
            .UseInMemoryDatabase("AvailabeTicketTest",b=>b.EnableNullChecks(false))
            .Options;
        using var context = new TicketingSolutionDbContext(dbOptions);
        context.Add(new Ticket { Id = 1, Name = "Ticket 1" });
        context.Add(new Ticket { Id = 2, Name = "Ticket 2" });
        context.Add(new Ticket { Id = 3, Name = "Ticket 3" });

        context.Add(new TicketBooking { TicketID = 1, Date = date });
        context.Add(new TicketBooking { TicketID=2, Date = date.AddDays(-1) });
        //context.Add(new TicketBooking { TicketID = 1, Name = "T1", Family = "T1", Email = "T1@gmail.com", Date = date });
        //context.Add(new TicketBooking { TicketID = 2, Name = "T2", Family = "T2", Email = "T2@gmail.com", Date = date.AddDays(-1) });
        context.SaveChanges();

        var ticketBookingService = new TicketBookingService(context);

        //Act

        var availabeServices = ticketBookingService.GetAvailabeTickets(date);

        //Assert

        Assert.Equal(2, availabeServices.Count());
        Assert.Contains(availabeServices, q=>q.Id==2);
        Assert.Contains(availabeServices, q => q.Id == 3);
        Assert.DoesNotContain(availabeServices, q => q.Id == 1);



    }

    [Fact]
    public void Should_Save_Ticket_Booking()
    {
        //Arrange

        var dbOptions = new DbContextOptionsBuilder<TicketingSolutionDbContext>()
            .UseInMemoryDatabase("ShouldSaveTest", b => b.EnableNullChecks(false))
            .Options;

        var ticketBooking = new TicketBooking { TicketID = 1, Date = new DateTime(2022, 07, 22) };

        //Act 
        using var context = new TicketingSolutionDbContext(dbOptions);
        var ticketBookingService = new TicketBookingService(context);
        ticketBookingService.Save(ticketBooking);

        //Assert 
        var bookings = context.TicketBookings.ToList();
        var booking = Assert.Single(bookings); // only be one

        Assert.Equal(ticketBooking.Date,booking.Date);
        Assert.Equal(ticketBooking.TicketID,booking.TicketID);



    }
}
