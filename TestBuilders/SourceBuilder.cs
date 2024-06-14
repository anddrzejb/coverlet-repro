namespace ReproPartialCoverage.TestBuilders;

public class SourceBuilder
{
    private Guid _id = Guid.NewGuid();
    private SourceReceiver? _sourceReceiver = new SourceReceiverBuilder().Build();
    private DateTime? _onDate = DateTime.UtcNow;
    private Metadata? _metadata = new MetadataBuilder().Build();

    public SourceBuilder WithId(Guid id)
    {
        _id = id;
        return this;
    }

    public SourceBuilder WithSourceReceiver(SourceReceiver? sourceReceiver)
    {
        _sourceReceiver = sourceReceiver;
        return this;
    }

    public SourceBuilder WithOnDate(DateTime? onDate)
    {
        _onDate = onDate;
        return this;
    }

    public SourceBuilder WithMetadata(Metadata? metadata)
    {
        _metadata = metadata;
        return this;
    }

    public Source Build()
    {
        return new Source
        {
            Id = _id,
            SourceReceiver = _sourceReceiver,
            OnDate = _onDate,
            Metadata = _metadata
        };
    }
}