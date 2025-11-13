namespace SoftwarePirates.Domain.TestProject1
{
    public class Set1ShipTypeServiceTest
    {
        ShipTypeService shipTypeService = new();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ShipTypeService_Pinnace_CorrectValue()
        {
            // assemble
            const string expectedApIcon = "8";
            const string expectedShipType = "Pinnace";
            const string expectedPhysicalSize = "Very Small";
            const string expectedManueverability = "Very High";
            const string expectedDurability = "Very Low";
            const string expectedComparativeSpeed = "Very High";
            const int expectedMaxCannons = 10;
            const int expectedMaxCrew = 60;
            const int expectedMinCrew = 6;
            const int expectedIdealCrew = 36;
            const int expectedCargoCapacity = 25;
            const int expectedSalePrice = 225;

            // act
            var ship = shipTypeService.GetCards().FirstOrDefault(s => s.TypeName == expectedShipType);

            // assert
            Assert.That(ship, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(ship.ApIcon, Is.EqualTo(expectedApIcon));
                Assert.That(ship.PhysicalSize, Is.EqualTo(expectedPhysicalSize));
                Assert.That(ship.Manueverability, Is.EqualTo(expectedManueverability));
                Assert.That(ship.Durability, Is.EqualTo(expectedDurability));
                Assert.That(ship.ComparativeSpeed, Is.EqualTo(expectedComparativeSpeed));
                Assert.That(ship.MaxCannons, Is.EqualTo(expectedMaxCannons));
                Assert.That(ship.MaxCrew, Is.EqualTo(expectedMaxCrew));
                Assert.That(ship.MinCrew, Is.EqualTo(expectedMinCrew));
                Assert.That(ship.IdealCrew, Is.EqualTo(expectedIdealCrew));
                Assert.That(ship.CargoCapacity, Is.EqualTo(expectedCargoCapacity));
                Assert.That(ship.SalePrice, Is.EqualTo(expectedSalePrice));
            });
        }

        [Test]
        public void ShipTypeService_Sloop_CorrectValue()
        {
            // assemble
            const string expectedApIcon = "Z";
            const string expectedShipType = "Sloop";
            const string expectedPhysicalSize = "Small";
            const string expectedManueverability = "High";
            const string expectedDurability = "Low";
            const string expectedComparativeSpeed = "High";
            const int expectedMaxCannons = 12;
            const int expectedMaxCrew = 75;
            const int expectedMinCrew = 8;
            const int expectedIdealCrew = 44;
            const int expectedCargoCapacity = 40;
            const int expectedSalePrice = 300;

            // act
            var ship = shipTypeService.GetCards().FirstOrDefault(s => s.TypeName == expectedShipType);

            // assert
            Assert.That(ship, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(ship.ApIcon, Is.EqualTo(expectedApIcon));
                Assert.That(ship.PhysicalSize, Is.EqualTo(expectedPhysicalSize));
                Assert.That(ship.Manueverability, Is.EqualTo(expectedManueverability));
                Assert.That(ship.Durability, Is.EqualTo(expectedDurability));
                Assert.That(ship.ComparativeSpeed, Is.EqualTo(expectedComparativeSpeed));
                Assert.That(ship.MaxCannons, Is.EqualTo(expectedMaxCannons));
                Assert.That(ship.MaxCrew, Is.EqualTo(expectedMaxCrew));
                Assert.That(ship.MinCrew, Is.EqualTo(expectedMinCrew));
                Assert.That(ship.IdealCrew, Is.EqualTo(expectedIdealCrew));
                Assert.That(ship.CargoCapacity, Is.EqualTo(expectedCargoCapacity));
                Assert.That(ship.SalePrice, Is.EqualTo(expectedSalePrice));
            });
        }

        [Test]
        public void ShipTypeService_WarGalleon_CorrectValue()
        {
            // assemble
            const string expectedApIcon = "P";
            const string expectedShipType = "War Galleon";
            const string expectedPhysicalSize = "Large";
            const string expectedManueverability = "Low";
            const string expectedDurability = "High";
            const string expectedComparativeSpeed = "Slow High";
            const int expectedMaxCannons = 32;
            const int expectedMaxCrew = 200;
            const int expectedMinCrew = 13;
            const int expectedIdealCrew = 107;
            const int expectedCargoCapacity = 90;
            const int expectedSalePrice = 500;

            // act
            var ship = shipTypeService.GetCards().FirstOrDefault(s => s.TypeName == expectedShipType);

            // assert
            Assert.That(ship, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(ship.ApIcon, Is.EqualTo(expectedApIcon));
                Assert.That(ship.PhysicalSize, Is.EqualTo(expectedPhysicalSize));
                Assert.That(ship.Manueverability, Is.EqualTo(expectedManueverability));
                Assert.That(ship.Durability, Is.EqualTo(expectedDurability));
                Assert.That(ship.ComparativeSpeed, Is.EqualTo(expectedComparativeSpeed));
                Assert.That(ship.MaxCannons, Is.EqualTo(expectedMaxCannons));
                Assert.That(ship.MaxCrew, Is.EqualTo(expectedMaxCrew));
                Assert.That(ship.MinCrew, Is.EqualTo(expectedMinCrew));
                Assert.That(ship.IdealCrew, Is.EqualTo(expectedIdealCrew));
                Assert.That(ship.CargoCapacity, Is.EqualTo(expectedCargoCapacity));
                Assert.That(ship.SalePrice, Is.EqualTo(expectedSalePrice));
            });
        }
    }
}