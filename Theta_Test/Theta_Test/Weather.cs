using System;
namespace Theta_Test
{
	public class Weather
	{
        public Weather(int date, int tempDiff)
        {
            this.date = date;
            this.tempDiff = tempDiff;
        }

        public int date { get; set; }
        public int tempDiff { get; set; }
    }
}

