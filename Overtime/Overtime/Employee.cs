namespace Overtime
{
    public class Employee : EmployeeBase
    {
        public override event HoursAddedDelegate HoursAdded;

        private string fileName = null;

        public Employee(string name, string surname)
            :base(name, surname)
        {
            fileName = $"{name}_{surname}_overhours.txt";
        }
        
        public override void AddHours(float hours)
        {
            if (hours <= 2 && hours >=-2)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(hours);
                }

                if (HoursAdded != null)
                {
                    HoursAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception($"This {hours} is not not good amount");
            }
        }

        public override void AddHours(string hours)
        {
            if (float.TryParse(hours, out float result))
            {
                AddHours(result);
            }
            else if (char.TryParse(hours, out char result2))
            {
                AddHours(result2);
            }
            else
            {
                throw new Exception($"String {hours} is not float");
            }

        }
        public override void AddHours(double hours)
        {
            var valueinfloat = (float)hours;
            AddHours(valueinfloat);
        }

        public override void AddHours(int hours)
        {
            var valueinfloat = (float)hours;
            AddHours(valueinfloat);
        }

        public override void AddHours(char hours)
        {
            var valueinfloat = (float)hours;
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
