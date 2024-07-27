using System.Diagnostics;

namespace Overtime
{
    public class Statistics
    {
        public float Sum { get; private set; }

        public float Count { get; private set; }

        public string FileName { get; private set; }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.FileName = "Statistics_Total_Sum.txt";
        }

        public void AddHours(float hours)
        {
            this.Count++;
            this.Sum += hours;
           
            using (var writer = File.AppendText(FileName))
            {
                writer.WriteLine(hours);
            }
        }
    }
}
