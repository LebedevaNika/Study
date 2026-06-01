using Microsoft.AspNetCore.Mvc;
using Study.LabWork3.Logic;
using Study.LabWork3.Storage;

namespace Study.LabWork3.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly AppointmentService _appointmentService;

    public AppointmentsController(AppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet]
    public List<Appointment> Get() => _appointmentService.GetAll();

    [HttpPost]
    public IActionResult Post(Appointment appointment)
    {
        _appointmentService.Add(appointment);
        return CreatedAtAction(nameof(Get), new { id = appointment.Id }, appointment);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Appointment appointment)
    {
        if (id != appointment.Id) return BadRequest();
        _appointmentService.Update(appointment);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _appointmentService.Delete(id);
        return NoContent();
    }
}
