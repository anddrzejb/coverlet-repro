namespace ReproPartialCoverage;

public record Destination
{
    public Guid Id { get; set; }
    public Receiver Receiver { get; set; }
    public DateTime OnDate { get; set; }
    public string? No { get; set; }
    public bool IsOn { get; set; }
    public IEnumerable<Attachment>? Attachment { get; set; }
    
}

public class Receiver
{
    public string Name { get; set; }
    public string OtherName { get; set; }
}

public class Attachment
{
    public string FileName { get; set; }
    public int Size { get; set; }
}