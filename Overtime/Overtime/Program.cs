using Overtime;

Console.WriteLine("Welcome in Overhours!");
Console.WriteLine("Here you can add overhours of your employee,");
Console.WriteLine("and check how many they have.");
Console.WriteLine();
Console.WriteLine();


var employee1 = new Employee("Andrzej", "Borkowski");
var employee2 = new Employee("Monika", "Borkowska");
var employee3 = new Employee("Ewa", "Borkowska");
employee1.HoursAdded += EmployeeHoursAdded;
employee2.HoursAdded += EmployeeHoursAdded;
employee3.HoursAdded += EmployeeHoursAdded;

void EmployeeHoursAdded(object sender, EventArgs args)
{
    Console.WriteLine("Hours have been added");
    Console.WriteLine();
}

while (true)
{
    Console.WriteLine("Choose employee:");
    Console.WriteLine("1." + employee1.Name + " " + employee1.Surname);
    Console.WriteLine("2." + employee2.Name + " " + employee2.Surname);
    Console.WriteLine("3." + employee3.Name + " " + employee3.Surname);
    Console.WriteLine("4. Check how many overhours they have");
    Console.WriteLine("or");
    Console.WriteLine("Press Q to quit.");
    Console.WriteLine("Then press enter to confirm.");

    string input1 = Console.ReadLine();
    Console.Clear();
    if (input1 == "Q" || input1 == "q")
    {
        break;
    }
    switch (input1)
    {
        case "1":
            while (true)
            {
                Console.WriteLine("Type in how many hours you want to add for " + employee1.Name + " " + employee1.Surname);
                Console.WriteLine("You can add from -2 to 2.");
                Console.WriteLine("Or press Q to go back to previous menu.");
                string input2 = Console.ReadLine();
                if (input2 == "Q" || input2 == "q")
                {
                    Console.Clear();
                    break;
                }
                try
                {
                    Console.Clear();
                    employee1.AddHours(input2);
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($"Exception catched: {e.Message}");
                }
            }
            break;
        case "2":
            while (true)
            {
                Console.WriteLine("Type in how many hours you want to add for " + employee2.Name + " " + employee2.Surname);
                Console.WriteLine("You can add from -2 to 2.");
                Console.WriteLine("Or press Q to go back to previous menu.");
                string input2 = Console.ReadLine();
                if (input2 == "Q" || input2 == "q")
                {
                    Console.Clear();
                    break;
                }
                try
                {
                    Console.Clear();
                    employee2.AddHours(input2);
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($"Exception catched: {e.Message}");
                }
            }
            break;
        case "3":
            while (true)
            {
                Console.WriteLine("Type in how many hours you want to add for " + employee3.Name + " " + employee3.Surname);
                Console.WriteLine("You can add from -2 to 2.");
                Console.WriteLine("Or press Q to go back to previous menu.");
                string input2 = Console.ReadLine();
                if (input2 == "Q" || input2 == "q")
                {
                    Console.Clear();
                    break;
                }
                try
                {
                    Console.Clear();
                    employee3.AddHours(input2);
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($"Exception catched: {e.Message}");
                }
            }
            break;
        case "4":
            var statistics1 = employee1.GetStatistics();
            var statistics2 = employee2.GetStatistics();
            var statistics3 = employee3.GetStatistics();

            var max = float.MinValue;
            var min = float.MaxValue;
            var totalhours = statistics1.Sum + statistics2.Sum + statistics3.Sum;
            var averagehours = totalhours / 3;

            max = Math.Max(max, statistics1.Sum);
            max = Math.Max(max, statistics2.Sum);
            max = Math.Max(max, statistics3.Sum);

            min = Math.Min(min, statistics1.Sum);
            min = Math.Min(min, statistics2.Sum);
            min = Math.Min(min, statistics3.Sum); 
            
            Console.Clear();
            Console.WriteLine($"Highest overtime hours is {max}.");
            Console.WriteLine($"Lowest overtime hours is {min}.");
            Console.WriteLine();
            Console.WriteLine($"1.{employee1.Name} {employee1.Surname}:");
            Console.WriteLine($"Hours were added {statistics1.Count} times.");
            Console.WriteLine($"Total overhours: {statistics1.Sum}.");
            Console.WriteLine();
            Console.WriteLine($"1.{employee2.Name} {employee2.Surname}:");
            Console.WriteLine($"Hours were added {statistics2.Count} times.");
            Console.WriteLine($"Total overhours: {statistics2.Sum}.");
            Console.WriteLine();
            Console.WriteLine($"1.{employee3.Name} {employee3.Surname}:");
            Console.WriteLine($"Hours were added {statistics3.Count} times.");
            Console.WriteLine($"Total overhours: {statistics3.Sum}.");
            Console.WriteLine();
            Console.WriteLine($"All of our employees have {totalhours} hours.");
            Console.WriteLine($"With average overhours: {averagehours}");
            Console.WriteLine();
            Console.WriteLine("Press enter to go back to previous Menu");
            Console.ReadLine();
            Console.Clear();
            break;
        default:
            Console.Clear();
            Console.WriteLine($"Exception catched: {input1} is not good choice. Please try again.");
            break;
    }
}

