using DeviceManager.Api.Data;
using DeviceManager.Api.DTOs;
using DeviceManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Api.Services;

public interface IDeviceService
{
    Task<List<DeviceDto>> GetAllAsync();
    Task<DeviceDto?> GetByIdAsync(int id);
    Task<DeviceDto> CreateAsync(CreateDeviceDto createDto);
    Task<DeviceDto?> UpdateAsync(int id, UpdateDeviceDto updateDto);
    Task<bool> DeleteAsync(int id);
    Task<bool> AssignDeviceAsync(int deviceId, int userId);
    Task<bool> UnassignDeviceAsync(int deviceId, int userId);
    Task<List<DeviceDto>> SearchAsync(string query);
    Task<bool> ExistsAsync(string name, int? excludeId = null);
}

public class DeviceService : IDeviceService
{
    private readonly AppDbContext _db;

    public DeviceService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<DeviceDto>> GetAllAsync()
    {
        return await _db.Devices
            .Include(d => d.AssignedToUser)
            .Select(d => MapToDto(d))
            .ToListAsync();
    }

    public async Task<DeviceDto?> GetByIdAsync(int id)
    {
        var device = await _db.Devices
            .Include(d => d.AssignedToUser)
            .FirstOrDefaultAsync(d => d.Id == id);

        return device == null ? null : MapToDto(device);
    }

    public async Task<DeviceDto> CreateAsync(CreateDeviceDto createDto)
    {
        var device = new Device
        {
            Name = createDto.Name,
            Manufacturer = createDto.Manufacturer,
            Type = createDto.Type,
            OperatingSystem = createDto.OperatingSystem,
            OsVersion = createDto.OsVersion,
            Processor = createDto.Processor,
            RamAmount = createDto.RamAmount,
            Description = createDto.Description
        };

        _db.Devices.Add(device);
        await _db.SaveChangesAsync();

        return MapToDto(device);
    }

    public async Task<DeviceDto?> UpdateAsync(int id, UpdateDeviceDto updateDto)
    {
        var device = await _db.Devices.FindAsync(id);
        if (device == null) return null;

        device.Name = updateDto.Name;
        device.Manufacturer = updateDto.Manufacturer;
        device.Type = updateDto.Type;
        device.OperatingSystem = updateDto.OperatingSystem;
        device.OsVersion = updateDto.OsVersion;
        device.Processor = updateDto.Processor;
        device.RamAmount = updateDto.RamAmount;
        device.Description = updateDto.Description;
        device.UpdatedAt = DateTime.UtcNow;

        await _db.SaveChangesAsync();

        await _db.Entry(device).Reference(d => d.AssignedToUser).LoadAsync();
        return MapToDto(device);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var device = await _db.Devices.FindAsync(id);
        if (device == null) return false;

        _db.Devices.Remove(device);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AssignDeviceAsync(int deviceId, int userId)
    {
        var device = await _db.Devices.FindAsync(deviceId);
        if (device == null) return false;

        if (device.AssignedToUserId.HasValue && device.AssignedToUserId != userId)
            return false;

        device.AssignedToUserId = userId;
        device.UpdatedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UnassignDeviceAsync(int deviceId, int userId)
    {
        var device = await _db.Devices.FindAsync(deviceId);
        if (device == null) return false;

        if (device.AssignedToUserId != userId) return false;

        device.AssignedToUserId = null;
        device.UpdatedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(string name, int? excludeId = null)
    {
        return await _db.Devices.AnyAsync(d =>
            d.Name.ToLower() == name.ToLower() &&
            (excludeId == null || d.Id != excludeId));
    }

    public async Task<List<DeviceDto>> SearchAsync(string query)
    {
        var tokens = query
            .ToLower()
            .Split(new char[] { ' ', ',', '.', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);

        var devices = await _db.Devices
            .Include(d => d.AssignedToUser)
            .ToListAsync();

        var scored = devices
            .Select(d => new
            {
                Device = d,
                Score = CalculateScore(d, tokens)
            })
            .Where(x => x.Score > 0)
            .OrderByDescending(x => x.Score)
            .Select(x => MapToDto(x.Device))
            .ToList();

        return scored;
    }

    // Scoring: Name=4pts, Manufacturer=3pts, Processor=2pts, RAM=1pt per token match
    private static int CalculateScore(Device d, string[] tokens)
    {
        int score = 0;
        foreach (var token in tokens)
        {
            if (d.Name.ToLower().Contains(token)) score += 4;
            if (d.Manufacturer.ToLower().Contains(token)) score += 3;
            if (d.Processor.ToLower().Contains(token)) score += 2;
            if (d.RamAmount.ToLower().Contains(token)) score += 1;
        }

        return score;
    }

    private static DeviceDto MapToDto(Device d) => new DeviceDto
    {
        Id = d.Id,
        Name = d.Name,
        Manufacturer = d.Manufacturer,
        Type = d.Type,
        OperatingSystem = d.OperatingSystem,
        OsVersion = d.OsVersion,
        Processor = d.Processor,
        RamAmount = d.RamAmount,
        Description = d.Description,
        AssignedToUserId = d.AssignedToUserId,
        AssignedToUserName = d.AssignedToUser?.Name,
        CreatedAt = d.CreatedAt,
        UpdatedAt = d.UpdatedAt
    };
}