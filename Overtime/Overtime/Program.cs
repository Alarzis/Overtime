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
    Console.Clear();
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

    string input = Console.ReadLine();
    Console.Clear();
    if (input == "Q" || input == "q")
    {
        break;
    }
    switch (input)
    {
        case "1":
            employee1.AddHours(input);
            break;
        case "2":
            employee2.AddHours(input);
            break;
        case "3":
            employee3.AddHours(input);
            break;
        case "4":
            var statistics1 = employee1.GetStatistics();
            var statistics2 = employee2.GetStatistics();
            var statistics3 = employee3.GetStatistics();
            float totalhours = 0;
            int count = 0;

            if (File.Exists("Statistics_Total_Sum.txt"))
            {

                using (var reader = File.OpenText("Statistics_Total_Sum.txt"))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        var number = float.Parse(line);
                        totalhours += number;
                        count++;
                        line = reader.ReadLine();
                    }
                }
            }
            
            float averagehours = totalhours / 3;

            Console.Clear();
            Console.WriteLine("Here are the overhours of our employees:");
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
            Console.WriteLine($"In total hours were added {count} times.");
            Console.WriteLine($"With average overhours: {averagehours}");
            Console.WriteLine();
            Console.WriteLine("Press enter to go back to previous Menu");
            Console.ReadLine();
            Console.Clear();
            break;
        default:
            Console.Clear();
            Console.WriteLine($"Exception catched: {input} is not good choice. Please try again.");
            Console.WriteLine();
            break;
    }
}

