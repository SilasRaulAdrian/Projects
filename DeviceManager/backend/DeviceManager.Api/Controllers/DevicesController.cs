using System.Security.Claims;
using DeviceManager.Api.DTOs;
using DeviceManager.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DevicesController : ControllerBase
{
    private readonly IDeviceService _deviceService;
    private readonly IAiService _aiService;

    public DevicesController(IDeviceService deviceService, IAiService aiService)
    {
        _deviceService = deviceService;
        _aiService = aiService;
    }

    // GET /api/devices
    [HttpGet]
    public async Task<ActionResult<List<DeviceDto>>> GetAll()
    {
        var devices = await _deviceService.GetAllAsync();
        return Ok(devices);
    }

    // GET /api/devices/search?q=iphone
    [HttpGet("search")]
    public async Task<ActionResult<List<DeviceDto>>> Search([FromQuery] string q)
    {
        if (string.IsNullOrWhiteSpace(q))
            return BadRequest("Search query cannot be empty.");

        var results = await _deviceService.SearchAsync(q);
        return Ok(results);
    }

    // GET /api/devices/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<DeviceDto>> GetById(int id)
    {
        var device = await _deviceService.GetByIdAsync(id);
        if (device == null) return NotFound();
        return Ok(device);
    }

    // POST /api/devices
    [HttpPost]
    public async Task<ActionResult<DeviceDto>> Create([FromBody] CreateDeviceDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // Validate type
        if (dto.Type != "phone" && dto.Type != "tablet")
            return BadRequest("Type must be 'phone' or 'tablet'.");

        // Check duplicate name
        if (await _deviceService.ExistsAsync(dto.Name))
            return Conflict(new { message = $"A device named '{dto.Name}' already exists." });

        var device = await _deviceService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = device.Id }, device);
    }

    // PUT /api/devices/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<DeviceDto>> Update(int id, [FromBody] UpdateDeviceDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (dto.Type != "phone" && dto.Type != "tablet")
            return BadRequest("Type must be 'phone' or 'tablet'.");

        var device = await _deviceService.UpdateAsync(id, dto);
        if (device == null) return NotFound();
        return Ok(device);
    }

    // DELETE /api/devices/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _deviceService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

    // POST /api/devices/{id}/assign
    [HttpPost("{id}/assign")]
    public async Task<IActionResult> Assign(int id)
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();

        var success = await _deviceService.AssignDeviceAsync(id, userId.Value);
        if (!success)
            return BadRequest(new { message = "Device not found or already assigned to another user." });

        return Ok(new { message = "Device assigned successfully." });
    }

    // POST /api/devices/{id}/unassign
    [HttpPost("{id}/unassign")]
    public async Task<IActionResult> Unassign(int id)
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();

        var success = await _deviceService.UnassignDeviceAsync(id, userId.Value);
        if (!success)
            return BadRequest(new { message = "Device not found or not assigned to you." });

        return Ok(new { message = "Device unassigned successfully." });
    }

    // POST /api/devices/generate-description
    [HttpPost("generate-description")]
    public async Task<ActionResult<string>> GenerateDescription([FromBody] GenerateDescriptionDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var description = await _aiService.GenerateDeviceDescriptionAsync(dto);
        return Ok(new { description });
    }

    private int? GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.TryParse(claim, out var id) ? id : null;
    }
}
