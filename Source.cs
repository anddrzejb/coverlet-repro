namespace ReproPartialCoverage;

public class Source
{
    public Guid Id { get; set; }
    public SourceReceiver? SourceReceiver { get; set; }
    public DateTime? OnDate { get; set; }
    public Metadata? Metadata { get; set; }
}

public class SourceReceiver
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? CallSign { get; set; }
    public int Age { get; set; }
}

public class Metadata
{
    public string No { get; set; }
    public Type Type { get; set; }
    public IList<File>? Files { get; set; }
    
}

public class File
{
    public string Name { get; set; }
    public int SizeInBytes { get; set; }
}

public enum Type
{
    One,
    Two,
    Three
}