using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketingSolution.Domain;

namespace TicketingSolution.Persistence;
public class TicketingSolutionDbContext:DbContext
{

    public TicketingSolutionDbContext(DbContextOptions<TicketingSolutionDbContext> options):base(options)
    {

    }
    public DbSet<Ticket> Tickets { get; set; }

    public DbSet<TicketBooking> TicketBookings { get; set; }

   
}
