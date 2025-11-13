namespace SoftwarePirates
{
    public interface IModifierCardModel
    {
        string Title { get; }
        string? SubTitle { get; }
        IEnumerable<string> Effects { get; }
    }
}
