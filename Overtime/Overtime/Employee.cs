namespace Overtime
{
    public class Employee : EmployeeBase
    {
        public override event HoursAddedDelegate HoursAdded;

        public string fileName = null;

        public Employee(string name, string surname)
            :base(name, surname)
        {
            fileName = $"{name}_{surname}_overhours.txt";
        }

        public override void GetHours(string hours)
        {
            while (true)
            {
                Console.WriteLine($"Type in how many hours you want to add for {this.Name} {this.Surname}.");
                Console.WriteLine("You can add from -2 to 2.");
                Console.WriteLine("Or press Q to go back to previous menu.");
                string input = Console.ReadLine();

                if (input == "Q" || input == "q")
                {
                    Console.Clear();
                    break;
                }
                if (float.TryParse(input, out float result))
                {
                    AddHours(result);
                }
                else if (char.TryParse(input, out char result2))
                {
                    AddHours(result2);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"This {input} is not not good amount");
                }
            }
            
        }

        public override void AddHours(float input)
        {
            if (input <= 2 && input >= -2)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(input);
                }

                if (HoursAdded != null)
                {
                    HoursAdded(this, new EventArgs());
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"This {input} is not not good amount");
            }
        }
        
        public override void AddHours(string input)
        {
            if (float.TryParse(input, out float result))
            {
                AddHours(result);
            }
            else if (char.TryParse(input, out char result2))
            {
                AddHours(result2);
            }
            else
            {
                throw new Exception($"String {input} is not float");
            }

        }
        public override void AddHours(double input)
        {
            var valueinfloat = (float)input;
            AddHours(valueinfloat);
        }

        public override void AddHours(int input)
        {
            var valueinfloat = (float)input;
            AddHours(valueinfloat);
        }

        public override void AddHours(char input)
        {
            var valueinfloat = (float)input;
            AddHours(valueinfloat);
        }

        public override Statistics GetStatistics()
        {
            var statisctics = new Statistics();

            if (File.Exists(fileName))
            {
                int count = 0;

                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        var number = float.Parse(line);
                        statisctics.AddHours(number);
                        count++;
                        line = reader.ReadLine();
                    }
                }
            }
            return statisctics;
        }
    }
}
