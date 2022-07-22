namespace TicketingSolution.Domain;

public abstract class ServiceBookingBase
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string Email { get; set; }
    public DateTime Date { get; set; }
}