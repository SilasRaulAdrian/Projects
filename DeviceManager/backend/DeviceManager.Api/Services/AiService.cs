using System.Text;
using System.Text.Json;
using DeviceManager.Api.DTOs;

namespace DeviceManager.Api.Services;

public interface IAiService
{
    Task<string> GenerateDeviceDescriptionAsync(GenerateDescriptionDto dto);
}

public class AiService : IAiService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> GenerateDeviceDescriptionAsync(GenerateDescriptionDto dto)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            var prompt = $"Generate a short, one-sentence device description (max 20 words) for business use. " +
                         $"Device: {dto.Name} by {dto.Manufacturer}, Type: {dto.Type}, " +
                         $"OS: {dto.OperatingSystem} {dto.OsVersion}, " +
                         $"Processor: {dto.Processor}, RAM: {dto.RamAmount}. " +
                         $"Only return the description sentence, nothing else.";

            var requestBody = new
            {
                model = "llama3",
                prompt = prompt,
                stream = false
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:11434/api/generate", content);

            if (!response.IsSuccessStatusCode)
                return GenerateFallbackDescription(dto);

            var responseJson = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseJson);
            var text = doc.RootElement.GetProperty("response").GetString();

            return text?.Trim() ?? GenerateFallbackDescription(dto);
        }
        catch
        {
            return GenerateFallbackDescription(dto);
        }
    }

    private static string GenerateFallbackDescription(GenerateDescriptionDto dto)
    {
        var deviceType = dto.Type == "tablet" ? "tablet" : "smartphone";

        var performance = dto.RamAmount switch
        {
            var r when r.Contains("16") || r.Contains("12") => "high-performance",
            var r when r.Contains("8") => "capable",
            _ => "reliable"
        };

        return $"A {performance} {dto.Manufacturer} {deviceType} running {dto.OperatingSystem}, " +
               $"powered by {dto.Processor} with {dto.RamAmount} RAM, suitable for business use.";
    }
}