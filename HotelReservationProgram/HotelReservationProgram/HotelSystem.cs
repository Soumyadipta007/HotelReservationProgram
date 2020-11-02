using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationProgram
{
    public class HotelSystem
    {
        public List<Hotel> hotelList;
        CheckDate checkDate = new CheckDate();
        public HotelSystem()
        {
            hotelList = new List<Hotel>();
        }
        public void AddHotel(Hotel hotel)
        {
            hotelList.Add(hotel);
        }
        public Hotel GetCheapestHotel(string[] dates)
        {
            DateTime[] validatedDates = checkDate.ValidateAndReturnDates(dates);
            hotelList.Sort((e1, e2) => e1.ratesForRegularCustomer.CompareTo(e2.ratesForRegularCustomer));
            return hotelList[0];
        }
        public Hotel GetCheapestHotel(string[] dates,string weekDayOrWeekEnd)
        {
            DateTime[] validatedDates = checkDate.ValidateAndReturnDates(dates);
            if(weekDayOrWeekEnd.Equals("Weekday"))
                hotelList.Sort((e1, e2) => e1.weekdayRatesForRegularCustomer.CompareTo(e2.weekdayRatesForRegularCustomer));
            else
                hotelList.Sort((e1, e2) => e1.weekendRatesForRegularCustomer.CompareTo(e2.weekendRatesForRegularCustomer));
            return hotelList[0];
        }
    }
}
