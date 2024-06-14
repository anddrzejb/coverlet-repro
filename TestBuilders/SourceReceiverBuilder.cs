namespace ReproPartialCoverage.TestBuilders;

public class SourceReceiverBuilder
{
    private string? _firstName = "DefaultFirstName";
    private string? _lastName = "DefaultLastName";
    private string? _callSign = "DefaultCallSign";
    private int _age = 30;

    public SourceReceiverBuilder WithFirstName(string? firstName)
    {
        _firstName = firstName;
        return this;
    }

    public SourceReceiverBuilder WithLastName(string? lastName)
    {
        _lastName = lastName;
        return this;
    }

    public SourceReceiverBuilder WithCallSign(string? callSign)
    {
        _callSign = callSign;
        return this;
    }

    public SourceReceiverBuilder WithAge(int age)
    {
        _age = age;
        return this;
    }

    public SourceReceiver Build()
    {
        return new SourceReceiver
        {
            FirstName = _firstName,
            LastName = _lastName,
            CallSign = _callSign,
            Age = _age
        };
    }
}