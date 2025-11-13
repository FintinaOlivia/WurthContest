namespace SoftwarePirates.Models
{
    public class ModifierCardModel : IModifierCardModel
    {
        public string Title { get; set; } = string.Empty;
        public string? SubTitle { get; set; }
        public IEnumerable<string> Effects { get; set; } = [];
    }
}
