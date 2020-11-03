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
        public void GivenWeekendAndWeekdayRatesReturnWeekendRate()
        {
            hotelSystem.AddHotel(new Hotel("Lakewood", 10000, 11000));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 5000, 6000));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 20000, 21000));
            Assert.AreEqual(11000, hotelSystem.hotelList[0].weekendRatesForRegularCustomer);
        }
        [TestMethod]
        public void GivenWeekendAndWeekdayRateReturnCheapestHotel()
        {
            hotelSystem.AddHotel(new Hotel("Lakewood", 10000, 11000));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 5000, 6000));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 20000, 21000));
            string[] dates = "10Dec2020,11Dec2020".Split(",");
            DateTime[] date = new DateTime[2];
            date[0] = DateTime.Parse(dates[0]);
            date[1] = DateTime.Parse(dates[1]);
            Hotel cheapestHotel = hotelSystem.GetCheapestHotel(date);
            Assert.AreEqual("Bridgewood", cheapestHotel.name);
        }
        [TestMethod]
        public void GivenRatingReturnRequiredRating()
        {
            hotelSystem.AddHotel(new Hotel("Lakewood",5, 10000, 11000));
            hotelSystem.AddHotel(new Hotel("Bridgewood",4, 5000, 6000));
            hotelSystem.AddHotel(new Hotel("Ridgewood",3, 20000, 21000));
            Assert.AreEqual(5, hotelSystem.hotelList[0].rating);
        }
    }
}
