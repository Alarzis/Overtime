using static Overtime.EmployeeBase;

namespace Overtime
{
    public interface IEmployee
    {
        string Name { get; }

        string Surname { get; }

        void AddHours(string hours);

        void AddHours(float hours);

        void AddHours(double hours);

        void AddHours(int hours);

        void AddHours(char hours);

        event HoursAddedDelegate HoursAdded;

        Statistics GetStatistics();
    }
}
