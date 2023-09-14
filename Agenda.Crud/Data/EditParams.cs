using Agenda.Crud.Models;

namespace Agenda.Crud.Data;

public class EditParams
{
    public string key { get; set; }
    public string action { get; set; }
    public List<ScheduleEvent> added { get; set; }
    public List<ScheduleEvent> changed { get; set; }
    public List<ScheduleEvent> deleted { get; set; }
    public ScheduleEvent value { get; set; }
}