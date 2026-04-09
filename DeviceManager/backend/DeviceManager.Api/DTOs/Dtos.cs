using System.ComponentModel.DataAnnotations;

namespace DeviceManager.Api.DTOs;

public class DeviceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string OperatingSystem { get; set; } = string.Empty;
    public string OsVersion { get; set; } = string.Empty;
    public string Processor { get; set; } = string.Empty;
    public string RamAmount { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? AssignedToUserId { get; set; }
    public string? AssignedToUserName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class CreateDeviceDto
{
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public string Manufacturer { get; set; } = string.Empty;
    [Required] public string Type { get; set; } = string.Empty;
    [Required] public string OperatingSystem { get; set; } = string.Empty;
    [Required] public string OsVersion { get; set; } = string.Empty;
    [Required] public string Processor { get; set; } = string.Empty;
    [Required] public string RamAmount { get; set; } = string.Empty;
    public string? Description { get; set; }
}

public class UpdateDeviceDto
{
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public string Manufacturer { get; set; } = string.Empty;
    [Required] public string Type { get; set; } = string.Empty;
    [Required] public string OperatingSystem { get; set; } = string.Empty;
    [Required] public string OsVersion { get; set; } = string.Empty;
    [Required] public string Processor { get; set; } = string.Empty;
    [Required] public string RamAmount { get; set; } = string.Empty;
    public string? Description { get; set; }
}

public class RegisterDto
{
    [Required] public string Name { get; set; } = string.Empty;
    [Required, EmailAddress] public string Email { get; set; } = string.Empty;
    [Required, MinLength(6)] public string Password { get; set; } = string.Empty;
    [Required] public string Role { get; set; } = "Employee";
    [Required] public string Location { get; set; } = string.Empty;
}

public class LoginDto
{
    [Required, EmailAddress] public string Email { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
}

public class AuthResponseDto
{
    public string Token { get; set; } = string.Empty;
    public UserDto User { get; set; } = null!;
}

public class GenerateDescriptionDto
{
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public string Manufacturer { get; set; } = string.Empty;
    [Required] public string Type { get; set; } = string.Empty;
    [Required] public string OperatingSystem { get; set; } = string.Empty;
    [Required] public string OsVersion { get; set; } = string.Empty;
    [Required] public string Processor { get; set; } = string.Empty;
    [Required] public string RamAmount { get; set; } = string.Empty;
}