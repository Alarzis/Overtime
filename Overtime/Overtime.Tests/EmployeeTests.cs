namespace Overtime.Tests
{

    public class Tests
    {
        [Test]
        public void WhenThreeHoursAreAdded_ShouldReturnSum()
        {

            string fileName = "Bartek_Kolos_overhours.txt";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // arrange
            var employee = new EmployeeTest("Bartek", "Kolos");
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

            string fileName = "Zuzia_Kredka_overhours.txt";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            //arrange
           var employee = new EmployeeTest("Zuzia", "Kredka");
            employee.AddHours(-1);
            employee.AddHours(-2);
            employee.AddHours(2);
            employee.AddHours(2);

            //act
           var statistics = employee.GetStatistics();

            //assert
            Assert.AreEqual(1, statistics.Sum);
        }

        [Test]
        public void WhenTwoEmployeesCollectHours_ShouldReturnTotalSum()
        {

            string fileName1 = "Szymon_Kufel_overhours.txt";

            if (File.Exists(fileName1))
            {
                File.Delete(fileName1);
            }

            string fileName2 = "Stefan_Bombel_overhours.txt";

            if (File.Exists(fileName2))
            {
                File.Delete(fileName2);
            }

            string fileName3 = "Statistics_Total_Sum.txt";

            if (File.Exists(fileName3))
            {
                File.Delete(fileName3);
            }

            // arrange
            var employee1 = new EmployeeTest("Szymon", "Kufel");
            var employee2 = new EmployeeTest("Stefan", "Bombel");
            employee1.AddHours(1);
            employee1.AddHours(2);
            employee2.AddHours(2);
            employee2.AddHours(2);

            // act
            var statistics1 = employee1.GetStatistics();
            var statistics2 = employee2.GetStatistics();
            var totalsum = statistics1.Sum + statistics2.Sum;
            float totalhours = 0;

            if (File.Exists("Statistics_Total_Sum.txt"))
            {

                using (var reader = File.OpenText("Statistics_Total_Sum.txt"))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        var number = float.Parse(line);
                        totalhours += number;
                        line = reader.ReadLine();
                    }
                }
            }


            // assert
            Assert.AreEqual(totalhours, totalsum);
        }
    }
}