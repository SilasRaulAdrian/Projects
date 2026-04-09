using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Api.Models;

public class Device
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Manufacturer { get; set; } = string.Empty;

    [Required, MaxLength(20)]
    public string Type { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string OperatingSystem { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string OsVersion { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Processor { get; set; } = string.Empty;

    [Required, MaxLength(20)]
    public string RamAmount { get; set; } = string.Empty;

    [MaxLength(256)]
    public string? Description { get; set; }

    public int? AssignedToUserId { get; set; }

    [ForeignKey(nameof(AssignedToUserId))]
    public User? AssignedToUser { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}