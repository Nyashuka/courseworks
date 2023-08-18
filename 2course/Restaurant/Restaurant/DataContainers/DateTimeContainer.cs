using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class DateTimeContainer : IEquatable<DateTimeContainer>
    {
        public DateTime DateTime { get; private set; }

        public DateTimeContainer()
        {
            DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public DateTimeContainer(int day, int mounth, int year)
        {
            DateTime = new DateTime(year, mounth, day);
        }

        public bool Equals(DateTimeContainer? other)
        {
            if(other == null)
                return false;

            return this.DateTime.Day.Equals(other.DateTime.Day) &&
                   this.DateTime.Month.Equals(other.DateTime.Month) &&
                   this.DateTime.Year.Equals(other.DateTime.Year);
        }

        public override int GetHashCode()
        {
            return this.DateTime.GetHashCode();
        }

        public override string ToString()
        {
            return DateTime.ToString("dd.MM.yyyy");
        }
    }
}
