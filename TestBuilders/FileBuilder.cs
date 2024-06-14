namespace ReproPartialCoverage.TestBuilders;

public class FileBuilder
{
    private string _name = "DefaultFileName";
    private int _sizeInBytes = 1024;

    public FileBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public FileBuilder WithSizeInBytes(int sizeInBytes)
    {
        _sizeInBytes = sizeInBytes;
        return this;
    }

    public File Build()
    {
        return new File
        {
            Name = _name,
            SizeInBytes = _sizeInBytes
        };
    }
}