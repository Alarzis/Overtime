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
        
        public override void AddHours(float input)
        {
            while (true)
            {

                wrongamount:
                Console.WriteLine($"Type in how many hours you want to add for {this.Name} {this.Surname}.");
                Console.WriteLine("You can add from -2 to 2.");
                Console.WriteLine("Or press Q to go back to previous menu.");
                string hours = Console.ReadLine();

                if (hours == "Q" || hours == "q")
                {
                    Console.Clear();
                    break;
                }

                if(float.TryParse(hours, out float result))
                {
                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Exception catched: This {hours} is not not good amount");
                    Console.WriteLine();

                    goto wrongamount;
                }


                try
                {
                    if (result <= 2 && result >= -2)
                    {
                        using (var writer = File.AppendText(fileName))
                        {
                            writer.WriteLine(result);
                        }

                        if (HoursAdded != null)
                        {
                            HoursAdded(this, new EventArgs());
                        }
                    }
                    else
                    {
                        throw new Exception($"This {result} is not not good amount");
                    }
                }
                catch (Exception e)
                {
                    
                    Console.Clear();
                    Console.WriteLine($"Exception catched: {e.Message}");
                    Console.WriteLine();
                }
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
