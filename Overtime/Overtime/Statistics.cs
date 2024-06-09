using System.Diagnostics;

namespace Overtime
{
    public class Statistics
    {
        public float Sum { get; private set; }

        public float Count { get; private set; }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
        }

        public void AddHours(float hours)
        {
            this.Count++;
            this.Sum += hours;
        }
    }
}
