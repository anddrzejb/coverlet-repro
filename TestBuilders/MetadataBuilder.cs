namespace ReproPartialCoverage.TestBuilders;

public class MetadataBuilder
{
    private string _no = "DefaultNo";
    private Type _type = Type.One;
    private IList<File>? _files = new List<File> { new FileBuilder().Build() };

    public MetadataBuilder WithNo(string no)
    {
        _no = no;
        return this;
    }

    public MetadataBuilder WithType(Type type)
    {
        _type = type;
        return this;
    }

    public MetadataBuilder WithFiles(IList<File>? files)
    {
        _files = files;
        return this;
    }

    public Metadata Build()
    {
        return new Metadata
        {
            No = _no,
            Type = _type,
            Files = _files
        };
    }
}