namespace ReproPartialCoverage;

public class Mapper
{
    public static Destination? MapConcise(Source? source) =>
        source is not null
            ? new Destination()
            {
                Id = source.Id,
                Receiver = source.SourceReceiver is null or SourceReceiver
                {
                    FirstName: null, LastName: null, CallSign: null, Age: 0
                }
                    ? default
                    : new Receiver
                    {
                        Name = $"{source.SourceReceiver.FirstName} {source.SourceReceiver.LastName}",
                        OtherName = source.SourceReceiver.CallSign
                    },
                OnDate = source.OnDate ?? default,
                No = source.Metadata?.No,
                IsOn = source.Metadata?.Type is not (Type.One or Type.Three),
                Attachment = source.Metadata?.Files?.Select(
                    x => new Attachment() { FileName = x.Name, Size = x.SizeInBytes })
            }
            : null;

    public static Destination? MapVerbose(Source? source)
    {
        if (source is null)
        {
            return null;
        }

        var isReceiverNull = source.SourceReceiver is null;

        var isReceiverEmpty = source.SourceReceiver is SourceReceiver
        {
            FirstName: null, LastName: null, CallSign: null, Age: 0
        };
        
        
        Receiver receiver;
        if (isReceiverNull || isReceiverEmpty)
        {
            receiver = default;
        }
        else
        {
            receiver = new Receiver
            {
                Name = $"{source.SourceReceiver.FirstName} {source.SourceReceiver.LastName}",
                OtherName = source.SourceReceiver.CallSign
            };
        }

        string? no = null;
        bool isOn = true;
        IEnumerable<Attachment>? attachment = null;
        if (source.Metadata is not null)
        {
            no = source.Metadata.No;
            isOn = source.Metadata.Type is not (Type.One or Type.Three);
            if (source.Metadata.Files is not null)
            {
                attachment = source.Metadata.Files.Select(
                    x => new Attachment() { FileName = x.Name, Size = x.SizeInBytes });
            }
        }
        
        return new Destination
        {
            Id = source.Id,
            Receiver = receiver,
            OnDate = source.OnDate ?? default,
            No = no,
            IsOn = isOn,
            Attachment = attachment 
        };
    }    
}