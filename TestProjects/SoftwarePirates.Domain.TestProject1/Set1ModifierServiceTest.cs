namespace SoftwarePirates.Domain.TestProject1
{
    public class Set1ModifierServiceTest
    {
        private ModifierService _modifierService = new();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ModifierService_Reinforced_CorrectValues()
        {
            // assemble
            const string expectedTitle = "Reinforced";
            const string expectedSubTitle = "Increase the durability of the ship";
            const string expectedEffects1 = "Increase the Durability of the ship by one category.";
            const string expectedEffects2 = "Increase the price of the ship by 10% of the Sale Price (rounded up).";

            // act
            var modifier = _modifierService.GetCards().First(m => m.Title == expectedTitle);
            var effects = modifier.Effects.ToList();

            // assert
            Assert.That(modifier.Title, Is.EqualTo(expectedTitle));
            Assert.That(modifier.SubTitle, Is.EqualTo(expectedSubTitle));
            Assert.That(effects[0], Is.EqualTo(expectedEffects1));
            Assert.That(effects[1], Is.EqualTo(expectedEffects2));
        }

        [Test]
        public void ModifierService_BigGuns_CorrectValues()
        {
            // assemble
            const string expectedTitle = "Big Guns";
            const string expectedSubTitle = "Increase the damage output of the cannons";
            const string expectedEffects1 = "Increase the cannon damage by one category.";
            const string expectedEffects2 = "Increase the price of the cannons by 10 per cannon.";

            // act
            var modifier = _modifierService.GetCards().First(m => m.Title == expectedTitle);
            var effects = modifier.Effects.ToList();

            // assert
            Assert.That(modifier.Title, Is.EqualTo(expectedTitle));
            Assert.That(modifier.SubTitle, Is.EqualTo(expectedSubTitle));
            Assert.That(effects[0], Is.EqualTo(expectedEffects1));
            Assert.That(effects[1], Is.EqualTo(expectedEffects2));
        }

        [Test]
        public void ModifierService_Elite_CorrectValues()
        {
            // assemble
            const string expectedTitle = "Elite";
            const string expectedSubTitle = "Increase the damage output of the pirates on the ship";
            const string expectedEffects1 = "Increase the pirate damage by one category.";
            const string expectedEffects2 = "Increase the price of the crew by 5 per crew.";

            // act
            var modifier = _modifierService.GetCards().First(m => m.Title == expectedTitle);
            var effects = modifier.Effects.ToList();

            // assert
            Assert.That(modifier.Title, Is.EqualTo(expectedTitle));
            Assert.That(modifier.SubTitle, Is.EqualTo(expectedSubTitle));
            Assert.That(effects[0], Is.EqualTo(expectedEffects1));
            Assert.That(effects[1], Is.EqualTo(expectedEffects2));
        }
    }
}