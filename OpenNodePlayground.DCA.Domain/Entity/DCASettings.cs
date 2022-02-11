namespace OpenNodePlayground.DCA.Domain.Entity;

public class DCASettings
{
    public double Amount { get; set; }
    public int RecurrenceMinutes { get; set; } // Purchase every X minutes
}