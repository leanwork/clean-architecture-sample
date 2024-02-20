namespace CleanArch.Domain.Common;

public record Result
{
    public IEnumerable<string> Errors { get; set; }

    public bool Success => Errors?.Any() == false;
}
