using ReproPartialCoverage.TestBuilders;

namespace ReproPartialCoverage;

public class MapperConciseTests
{
    [Fact]
    public void Map_WhenSourceIsNull()
    {
        var actual = Mapper.MapConcise(null);
        actual.Should().BeNull();
    }    

    [Fact]
    public void Map_WhenSourceReceiverIsNull()
    {
        var source = new SourceBuilder().WithSourceReceiver(null).Build();
        var actual = Mapper.MapConcise(source);
        actual.Receiver.Should().BeNull();
    }
    
    [Fact]
    public void Map_WhenSourceReceiverIsEmpty()
    {
        var source = new SourceBuilder().WithSourceReceiver(new SourceReceiver()).Build();
        var actual = Mapper.MapConcise(source);
        actual.Receiver.Should().BeNull();
    }
    
    [Fact]
    public void Map_WhenSourceReceiverIsValid()
    {
        var source = new SourceBuilder().Build();
        var actual = Mapper.MapConcise(source);
        actual.Receiver.Name.Should().Be($"{source.SourceReceiver!.FirstName} {source.SourceReceiver!.LastName}");
        actual.Receiver.OtherName.Should().Be(source.SourceReceiver!.CallSign);
    }
    
    [Fact]
    public void Map_WhenOnDateIsNull()
    {
        var source = new SourceBuilder().WithOnDate(null).Build();
        var actual = Mapper.MapConcise(source);
        actual.OnDate.Should().Be(default);
    }
    
    [Fact]
    public void Map_WhenOnDateIsValid()
    {
        var source = new SourceBuilder().WithOnDate(null).Build();
        var actual = Mapper.MapConcise(source);
        actual.OnDate.Should().Be(default);
    }

    [Fact]
    public void Map_WhenMetadataIsNull()
    {
        var source = new SourceBuilder().WithMetadata(null).Build();
        var actual = Mapper.MapConcise(source);
        actual.No.Should().BeNull();
        actual.IsOn.Should().BeTrue();
        actual.Attachment.Should().BeNull();
    }
    
    [Fact]
    public void Map_WhenMetadataIsValidWithTypeTwo()
    {
        var source = new SourceBuilder()
            .WithMetadata(new MetadataBuilder()
                .WithType(Type.Two)
                .Build()
            ).Build();
        var actual = Mapper.MapConcise(source);
        actual.No.Should().Be(source.Metadata!.No);
        actual.IsOn.Should().BeTrue();
    }
    
    [Fact]
    public void Map_WhenMetadataIsValidWithTypeOtherThanTwo()
    {
        var source = new SourceBuilder()
            .WithMetadata(new MetadataBuilder()
                .WithType(Type.Three)
                .Build()
            ).Build();
        var actual = Mapper.MapConcise(source);
        actual.IsOn.Should().BeFalse();
    }
    
    [Fact]
    public void Map_WhenMetadataIsValidWithFilesNull()
    {
        var source = new SourceBuilder()
            .WithMetadata(new MetadataBuilder()
                .WithFiles(null)
                .Build()
            ).Build();
        var actual = Mapper.MapConcise(source);
        actual.Attachment.Should().BeNull();
    }
    
    [Fact]
    public void Map_WhenMetadataIsValidWithValidFiles()
    {
        var metadata = new MetadataBuilder().Build();
        var source = new SourceBuilder().WithMetadata(metadata).Build();
        var actual = Mapper.MapConcise(source);
        actual.Attachment.Should().HaveCount(1);
    }    
}