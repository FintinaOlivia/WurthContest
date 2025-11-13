using SoftwarePirates.Models;

namespace SoftwarePirates.Domain
{
    public class ModifierService : IModifierService
    {
        private readonly List<IModifierCardModel> _modifiers = new List<IModifierCardModel> 
        {
            new ModifierCardModel 
            {
                Title = "Reinforced",
                SubTitle = "Increase the durability of the ship",
                Effects = new List<string>
                {
                    "Increase the Durability of the ship by one category.",
                    "Increase the price of the ship by 10% of the Sale Price (rounded up)."
                }
            },
            new ModifierCardModel
            {
                Title = "Big Guns",
                SubTitle = "Increase the damage output of the cannons",
                Effects = new List<string>
                {
                    "Increase the cannon damage by one category.",
                    "Increase the price of the cannons by 10 per cannon."
                }
            },
            new ModifierCardModel
            {
                Title = "Elite",
                SubTitle = "Increase the damage output of the pirates on the ship",
                Effects = new List<string>
                {
                    "Increase the pirate damage by one category.",
                    "Increase the price of the crew by 5 per crew."
                }
            },
        };

        public IEnumerable<IModifierCardModel> GetCards()
        {
            return _modifiers;
        }
    }
}
