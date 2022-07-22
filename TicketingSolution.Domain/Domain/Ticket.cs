﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSolution.Domain;
public class Ticket
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public List<TicketBooking> TicketBookings { get; set; }
}
