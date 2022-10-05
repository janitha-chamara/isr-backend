namespace ISRDataAccess.Models;

public class WFMJobModel
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public string UUID { get; set; }
    public string JobName { get; set; }
    public string Client { get; set; }
    public string ProjectManger { get; set; }
    public string SDM { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal QuotedHours { get; set; }
    public decimal ActualHours { get; set; }

}