using System.Xml.Linq;

namespace Overtime.Tests
{

    // All tests save data in file at Overtime.Tests location.
    // You have to delete the file after each test.
    public class Tests
    {
        [Test]
        public void WhenThreeHoursAreAdded_ShouldReturnSum()
        {
            // arrange
            var employee = new Employee("Bartek", "Kolos");
            employee.AddHours(1);
            employee.AddHours(2);
            employee.AddHours(2);


            // act
            var statistics = employee.GetStatistics();

            // assert
            Assert.AreEqual(5, statistics.Sum);
        }

        [Test]
        public void WhenNegativeValueIsAdded_ShouldReturnCorrectSum()
        {
            // arrange
            var employee = new Employee("Zuzia", "Kredka");
            employee.AddHours(-1);
            employee.AddHours(-2);
            employee.AddHours(2);
            employee.AddHours(2);

            // act
            var statistics = employee.GetStatistics();

            // assert
            Assert.AreEqual(1, statistics.Sum);
        }

        [Test]
        public void WhenTwoEmployeesCollectHours_ShouldReturnTotalSum()
        {
            // arrange
            var employee1 = new Employee("Szymon", "Kufel");
            var employee2 = new Employee("Stefan", "Bombel");
            employee1.AddHours(1);
            employee1.AddHours(2);
            employee2.AddHours(2);
            employee2.AddHours(2);

            // act
            var statistics1 = employee1.GetStatistics();
            var statistics2 = employee2.GetStatistics();
            var totalsum = statistics1.Sum + statistics2.Sum;


            // assert
            Assert.AreEqual(7, totalsum);
        }
    }
}