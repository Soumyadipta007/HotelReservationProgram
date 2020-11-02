using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationProgram
{
    public class HotelSystem
    {
        public List<Hotel> hotelList;
        public HotelSystem()
        {
            hotelList = new List<Hotel>();
        }
        public void AddHotel(Hotel hotel)
        {
            hotelList.Add(hotel);
        }
    }
}
