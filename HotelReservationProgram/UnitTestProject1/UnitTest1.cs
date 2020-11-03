using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationProgram;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        HotelSystem hotelSystem = new HotelSystem();
        [TestMethod]
        public void GivenHotelCheckName()
        {
            string hotelName = "Lakewood";
            int ratesForRegularCustomer = 10000;
            Hotel hotel = new Hotel(hotelName, ratesForRegularCustomer);
            hotelSystem.AddHotel(hotel);
            Assert.AreEqual("Lakewood", hotelSystem.hotelList[0].name);
        }
        [TestMethod]
        public void GivenHotelOptionsReturnCheapestHotel()
        {
            hotelSystem.AddHotel(new Hotel("Lakewood", 10000));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 5000));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 20000));
            string[] dates = "10Dec2020,11Dec2020".Split(",");
            Hotel cheapestHotel = hotelSystem.GetCheapestHotel(dates);
            Assert.AreEqual("Bridgewood", cheapestHotel.name);
        }
        [TestMethod]
        public void GivenWeekendAndWeekdayRatesReturnCheapestHotel()
        {
            hotelSystem.AddHotel(new Hotel("Lakewood", 10000, 11000));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 5000, 6000));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 20000, 21000));
            Assert.AreEqual(11000, hotelSystem.hotelList[0].weekendRatesForRegularCustomer);
        }        
    }
}
