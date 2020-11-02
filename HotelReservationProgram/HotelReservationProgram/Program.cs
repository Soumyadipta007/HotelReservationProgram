using System;

namespace HotelReservationProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Hotel Reservation System");
            HotelSystem hotelSystem = new HotelSystem();
            hotelSystem.AddHotel(new Hotel("Lakewood", 110));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220));
        }
    }
}
