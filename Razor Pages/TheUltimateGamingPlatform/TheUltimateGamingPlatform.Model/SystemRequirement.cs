namespace TheUltimateGamingPlatform.Model;

public class SystemRequirement
{
    public int Id { get; set; }
    public required string OS { get; set; }
    public required string Processor { get; set; }
    public required string Memory { get; set; }
    public required string HardDrive { get; set; }
    public required string? VideoCard { get; set; }
    public required string? DirectX { get; set; }
    public required string? VR { get; set; }
    public required string? Additionally { get; set; }
    public required string? Network { get; set; }
    public required string? SoundCard { get; set; }
}