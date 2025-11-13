using SoftwarePirates.Alerts;

namespace SoftwarePirates.Domain.TestProject1
{
    public class Set1FleetBuilderEngineTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void FleetBuilderEngine_FleetBudget_CorrectValue()
        {
            // assemble
            AlertEngine alertEngine = new();
            FleetBuilderEngine fleetBuilderEngine = new(alertEngine);
            const int expected = 10000;

            // act

            // assert
            Assert.That(fleetBuilderEngine.FleetBudget, Is.EqualTo(expected));
        }

        [Test]
        public void FleetBuilderEngine_FleetName_SetProperly()
        {
            // assemble
            AlertEngine alertEngine = new();
            FleetBuilderEngine fleetBuilderEngine = new(alertEngine);
            const string expected = "Barrett’s Privateers";

            // act
            fleetBuilderEngine.FleetName = expected;

            // assert
            Assert.That(fleetBuilderEngine.FleetName, Is.EqualTo(expected));
        }

        [Test]
        public void FleetBuilderEngine_ImportText_SetProperly()
        {
            // assemble
            AlertEngine alertEngine = new();
            FleetBuilderEngine fleetBuilderEngine = new(alertEngine);
            const string expected = "Barrett’s Privateers";

            // act
            fleetBuilderEngine.ImportText = expected;

            // assert
            Assert.That(fleetBuilderEngine.ImportText, Is.EqualTo(expected));
        }

        [Test]
        public void FleetBuilderEngine_ShipEdit_SetProperly()
        {
            // assemble
            AlertEngine alertEngine = new();
            FleetBuilderEngine fleetBuilderEngine = new(alertEngine);
            const string expectedName = "Revenge";
            const string expectedShipType = "War Galleon";
            const int expectedCannons = 2;
            const int expectedCrew = 10;

            // act
            fleetBuilderEngine.ShipEdit.Name = expectedName;
            fleetBuilderEngine.ShipEdit.ShipType = expectedShipType;
            fleetBuilderEngine.ShipEdit.Crew = expectedCrew;
            fleetBuilderEngine.ShipEdit.Cannons = expectedCannons;

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(fleetBuilderEngine.ShipEdit.Name, Is.EqualTo(expectedName));
                Assert.That(fleetBuilderEngine.ShipEdit.ShipType, Is.EqualTo(expectedShipType));
                Assert.That(fleetBuilderEngine.ShipEdit.Cannons, Is.EqualTo(expectedCannons));
                Assert.That(fleetBuilderEngine.ShipEdit.Crew, Is.EqualTo(expectedCrew));
            });
        }

        [Test]
        public void FleetBuilderEngine_AddShipToFleet_SetProperly()
        {
            // assemble
            AlertEngine alertEngine = new();
            FleetBuilderEngine fleetBuilderEngine = new(alertEngine);
            const string expectedName = "Revenge";
            const string expectedShipType = "War Galleon";
            const int expectedCannons = 2;
            const int expectedCrew = 20;
            const int expectedCost = 740;
            const int expectedRemainingBudget = 9260;

            // act
            fleetBuilderEngine.ShipEdit.Name = expectedName;
            fleetBuilderEngine.ShipEdit.ShipType = expectedShipType;
            fleetBuilderEngine.ShipEdit.Crew = expectedCrew;
            fleetBuilderEngine.ShipEdit.Cannons = expectedCannons;
            fleetBuilderEngine.AddShipToFleet();
            var ship = fleetBuilderEngine.FleetDisplayModels.First();

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(fleetBuilderEngine.ShipEdit.Name, Is.EqualTo(string.Empty));
                Assert.That(fleetBuilderEngine.ShipEdit.ShipType, Is.EqualTo(string.Empty));
                Assert.That(fleetBuilderEngine.ShipEdit.Cannons, Is.EqualTo(0));
                Assert.That(fleetBuilderEngine.ShipEdit.Crew, Is.EqualTo(0));

                Assert.That(ship.Name, Is.EqualTo(expectedName));
                Assert.That(ship.ShipType, Is.EqualTo(expectedShipType));
                Assert.That(ship.Cannons, Is.EqualTo(expectedCannons));
                Assert.That(ship.Crew, Is.EqualTo(expectedCrew));
                Assert.That(ship.Cost, Is.EqualTo(expectedCost));
                Assert.That(fleetBuilderEngine.FleetExpense, Is.EqualTo(expectedCost));
                Assert.That(fleetBuilderEngine.RemainingBudget, Is.EqualTo(expectedRemainingBudget));
            });
        }

        [Test]
        public void FleetBuilderEngine_ImportFleet_RunsProperly()
        {
            // assemble
            AlertEngine alertEngine = new();
            FleetBuilderEngine fleetBuilderEngine = new(alertEngine);
            const string importText = @"Dread Pirate Roberts
Revenge|War Galleon|2|20|";

            const string expectedName = "Revenge";
            const string expectedShipType = "War Galleon";
            const int expectedCannons = 2;
            const int expectedCrew = 20;
            const int expectedCost = 740;
            const int expectedRemainingBudget = 9260;

            // act
            fleetBuilderEngine.ImportText = importText;
            fleetBuilderEngine.ImportFleet();
            var ship = fleetBuilderEngine.FleetBattleModels.First();
            var actualIsOverBudget = fleetBuilderEngine.IsOverBudget();

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(ship.Name, Is.EqualTo(expectedName));
                Assert.That(ship.ShipType, Is.EqualTo(expectedShipType));
                Assert.That(ship.Cannons, Is.EqualTo(expectedCannons));
                Assert.That(ship.Crew, Is.EqualTo(expectedCrew));
                Assert.That(ship.Cost, Is.EqualTo(expectedCost));
                Assert.That(fleetBuilderEngine.FleetExpense, Is.EqualTo(expectedCost));
                Assert.That(fleetBuilderEngine.RemainingBudget, Is.EqualTo(expectedRemainingBudget));
                Assert.That(actualIsOverBudget, Is.False);
            });
        }

        [Test]
        public void FleetBuilderEngine_ExportText_BuildsProperly()
        {
            // assemble
            AlertEngine alertEngine = new();
            FleetBuilderEngine fleetBuilderEngine = new(alertEngine);
            const string expectedText = @"Dread Pirate Roberts
Revenge|War Galleon|2|20|
";

            // act
            fleetBuilderEngine.ImportText = expectedText;
            fleetBuilderEngine.ImportFleet();

            // assert
            Assert.That(fleetBuilderEngine.ExportText, Is.EqualTo(expectedText));
        }

        [Test]
        public void FleetBuilderEngine_AlertEngine_ChecksProperly()
        {
            // assemble
            AlertEngine alertEngine = new();
            FleetBuilderEngine fleetBuilderEngine = new(alertEngine);
            const string expected = "Duplicate ship name specified: Revenge";
            const string expectedText = @"Dread Pirate Roberts
Revenge|War Galleon|32|200|
Revenge|War Galleon|32|200|
";

            // act
            fleetBuilderEngine.ImportText = expectedText;
            fleetBuilderEngine.ImportFleet();
            var actual = alertEngine.AlertMessages.First().Message;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FleetBuilderEngine_ExportText_ChecksProperly()
        {
            // assemble
            AlertEngine alertEngine = new();
            FleetBuilderEngine fleetBuilderEngine = new(alertEngine);
            const string importText = @"Dread Pirate Roberts
Revenge|War Galleon|32|200|
Revenge2|War Galleon|32|200|
Revenge3|War Galleon|32|200|
Revenge4|War Galleon|32|200|
Revenge5|War Galleon|32|200|
";

            // act
            fleetBuilderEngine.ImportText = importText;
            fleetBuilderEngine.ImportFleet();
            var actual = fleetBuilderEngine.IsOverBudget();

            // assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void FleetBuilderEngine_ShipTypeOptions_CorrectValues()
        {
            // assemble
            AlertEngine alertEngine = new();
            FleetBuilderEngine fleetBuilderEngine = new(alertEngine);
            const string expected1 = "Pinnace";
            const string expected2 = "Sloop";
            const string expected3 = "War Galleon";

            // act
            var actual = fleetBuilderEngine.ShipTypeOptions;

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(actual.Count(a => a == expected1), Is.EqualTo(1));
                Assert.That(actual.Count(a => a == expected2), Is.EqualTo(1));
                Assert.That(actual.Count(a => a == expected3), Is.EqualTo(1));
            });
        }

        [Test]
        public void FleetBuilderEngine_AllCards_ChecksProperly()
        {
            // assemble
            const int expected = 3402;
            AlertEngine alertEngine = new();
            FleetBuilderEngine fleetBuilderEngine = new(alertEngine);
            const string importText = @"Dread Pirate Roberts
Revenge|War Galleon|32|200|Elite
Revenge2|Pinnace|10|60|Reinforced
Revenge3|Sloop|12|75|Big guns
";

            // act
            fleetBuilderEngine.ImportText = importText;
            fleetBuilderEngine.ImportFleet();
            var actual = fleetBuilderEngine.RemainingBudget;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        
        [Test]
        public void FleetBuilderEngine_ImportFleet_ApplyElite()
        {
            // assemble
            AlertEngine alertEngine = new();
            FleetBuilderEngine fleetBuilderEngine = new(alertEngine);
            const string importText = @"Dread Pirate Roberts
Revenge|War Galleon|2|20|Elite";

            const string expectedName = "Revenge";
            const string expectedShipType = "War Galleon";
            const string expectedCannonAccuracy = "Medium";
            const string expectedCannonDamage = "High";
            const string expectedPirateDamage = "High";
            const string expectedManueverability = "Low";
            const string expectedComparativeSpeed = "Slow High";
            const string expectedDurability = "High";
            const int expectedCannons = 2;
            const int expectedCrew = 20;
            const int expectedCost = 840;
            const int expectedInoperableShipCrewCounters = 12;
            const int expectedCrippledShipCrewCounters = 8;
            const int expectedRemainingBudget = 9160;

            // act
            fleetBuilderEngine.ImportText = importText;
            fleetBuilderEngine.ImportFleet();
            var ship = fleetBuilderEngine.FleetBattleModels.First();
            var actualIsOverBudget = fleetBuilderEngine.IsOverBudget();

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(ship.Name, Is.EqualTo(expectedName));
                Assert.That(ship.ShipType, Is.EqualTo(expectedShipType));
                Assert.That(ship.CannonAccuracy, Is.EqualTo(expectedCannonAccuracy));
                Assert.That(ship.CannonDamage, Is.EqualTo(expectedCannonDamage));
                Assert.That(ship.Manueverability, Is.EqualTo(expectedManueverability));
                Assert.That(ship.ComparativeSpeed, Is.EqualTo(expectedComparativeSpeed));
                Assert.That(ship.Durability, Is.EqualTo(expectedDurability));
                Assert.That(ship.Cannons, Is.EqualTo(expectedCannons));
                Assert.That(ship.Crew, Is.EqualTo(expectedCrew));
                Assert.That(ship.Cost, Is.EqualTo(expectedCost));
                Assert.That(ship.PirateDamage, Is.EqualTo(expectedPirateDamage));
                Assert.That(fleetBuilderEngine.FleetExpense, Is.EqualTo(expectedCost));
                Assert.That(fleetBuilderEngine.RemainingBudget, Is.EqualTo(expectedRemainingBudget));
                Assert.That(ship.InoperableCrew, Is.EqualTo(expectedInoperableShipCrewCounters));
                Assert.That(ship.CrippledCrew, Is.EqualTo(expectedCrippledShipCrewCounters));
                Assert.That(actualIsOverBudget, Is.False);
            });
        }
    }
}