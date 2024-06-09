namespace Overtime
{
    public abstract class EmployeeBase : IEmployee
    {
        public delegate void HoursAddedDelegate(object sender, EventArgs args);

        public abstract event HoursAddedDelegate HoursAdded;

        public EmployeeBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public abstract void AddHours(string hours);

        public abstract void AddHours(float hours);

        public abstract void AddHours(double hours);

        public abstract void AddHours(int hours);

        public abstract void AddHours(char hours);

        public abstract Statistics GetStatistics();

    }
}
