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
            RegularCustomer regularCustomer = new RegularCustomer();
            Hotel hotel = new Hotel(hotelName, ratesForRegularCustomer,regularCustomer);
            hotelSystem.AddHotel(hotel);
            Assert.AreEqual("Lakewood", hotelSystem.hotelList[0].name);
        }
        [TestMethod]
        public void GivenHotelOptionsReturnCheapestHotelForRegularCustomer()
        {
            RegularCustomer regularCustomer = new RegularCustomer();
            hotelSystem.AddHotel(new Hotel("Lakewood", 10000, regularCustomer));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 5000, regularCustomer));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 20000, regularCustomer));
            string[] dates = "10Dec2020,11Dec2020".Split(",");
            Hotel cheapestHotel = hotelSystem.GetCheapestHotel(dates);
            Assert.AreEqual("Bridgewood", cheapestHotel.name);
        }
        [TestMethod]
        public void GivenWeekendAndWeekdayRatesReturnWeekendRateForRegularCustomer()
        {
            RegularCustomer regularCustomer = new RegularCustomer();
            hotelSystem.AddHotel(new Hotel("Lakewood", 10000, 11000, regularCustomer));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 5000, 6000, regularCustomer));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 20000, 21000, regularCustomer));
            Assert.AreEqual(11000, hotelSystem.hotelList[0].weekendRatesForCustomer);
        }
        [TestMethod]
        public void GivenWeekendAndWeekdayRateReturnCheapestHotelForRegularCustomer()
        {
            RegularCustomer regularCustomer = new RegularCustomer();
            hotelSystem.AddHotel(new Hotel("Lakewood", 10000, 11000, regularCustomer));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 5000, 6000, regularCustomer));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 20000, 21000, regularCustomer));
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
            RegularCustomer regularCustomer = new RegularCustomer();
            hotelSystem.AddHotel(new Hotel("Lakewood", 5, 10000, 11000, regularCustomer));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 4, 5000, 6000, regularCustomer));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 3, 20000, 21000, regularCustomer));
            Assert.AreEqual(5, hotelSystem.hotelList[0].rating);
        }
        [TestMethod]
        public void GivenWeekendAndWeekdayRateReturnCheapestHotelAlongWithRatingForRegularCustomer()
        {
            RegularCustomer regularCustomer = new RegularCustomer();
            hotelSystem.AddHotel(new Hotel("Lakewood", 4, 10000, 11000, regularCustomer));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 5, 5000, 6000, regularCustomer));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 3, 20000, 21000, regularCustomer));
            string[] dates = "10Dec2020,11Dec2020".Split(",");
            DateTime[] date = new DateTime[2];
            date[0] = DateTime.Parse(dates[0]);
            date[1] = DateTime.Parse(dates[1]);
            Hotel cheapestHotel = hotelSystem.GetCheapestHotelWithBestRating(date);            
            Assert.AreEqual(5, cheapestHotel.rating);
        }
        [TestMethod]
        public void GivenWeekendAndWeekdayRateReturnBestRatedRestaurantForRegularCustomer()
        {
            RegularCustomer regularCustomer = new RegularCustomer();
            hotelSystem.AddHotel(new Hotel("Lakewood", 4, 10000, 11000,regularCustomer));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 5, 5000, 6000,regularCustomer));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 3, 20000, 21000,regularCustomer));
            string[] dates = "10Dec2020,11Dec2020".Split(",");
            DateTime[] date = new DateTime[2];
            date[0] = DateTime.Parse(dates[0]);
            date[1] = DateTime.Parse(dates[1]);
            Hotel cheapestHotel = hotelSystem.GetHotelWithBestRating(date);
            Assert.AreEqual(5, cheapestHotel.rating);
        }
        [TestMethod]
        public void GivenRewardCustomerGetTheirRate()
        {
            RewardCustomer rewardCustomer = new RewardCustomer();
            hotelSystem.AddHotel(new Hotel("Lakewood", 4, 80, 80, rewardCustomer));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 5, 110, 50, rewardCustomer));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 3, 100, 40, rewardCustomer));
            Assert.AreEqual(80, hotelSystem.hotelList[0].weekdayRatesForCustomer);
        }
        [TestMethod]
        public void GivenWeekendAndWeekdayRateReturnBestRatedRestaurantForRewardCustomer()
        {
            RegularCustomer regularCustomer = new RegularCustomer();
            hotelSystem.AddHotel(new Hotel("Lakewood", 4, 80, 80, regularCustomer));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 3, 110, 50, regularCustomer));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 5, 100, 40, regularCustomer));
            string[] dates = "10Dec2020,11Dec2020".Split(",");
            DateTime[] date = new DateTime[2];
            date[0] = DateTime.Parse(dates[0]);
            date[1] = DateTime.Parse(dates[1]);
            Hotel cheapestHotel = hotelSystem.GetCheapestHotelWithBestRating(date);
            Assert.AreEqual("Ridgewood", cheapestHotel.name);
        }
        [TestMethod]
        public void GivenWeekendAndWeekdayRateReturnBestRatedRestaurantForRewardCustomerWithRegexValidation()
        {
            RewardCustomer rewardCustomer = new RewardCustomer();
            hotelSystem.AddHotel(new Hotel("Lakewood", 4, 80, 80, rewardCustomer));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 3, 110, 50, rewardCustomer));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 5, 100, 40, rewardCustomer));
            string[] dates = "10Dec2020,11Dec2020".Split(",");            
            Hotel cheapestHotel=hotelSystem.GivenWeekendAndWeekdayRateReturnBestRatedRestaurantForCustomerWithRegexValidation(dates);
            Assert.AreEqual("Ridgewood", cheapestHotel.name);
        }
        [TestMethod]
        public void GivenWeekendAndWeekdayRateReturnBestRatedRestaurantForRegularCustomerWithRegexValidation()
        {
            RegularCustomer regularCustomer = new RegularCustomer();
            hotelSystem.AddHotel(new Hotel("Lakewood", 4, 80, 80, regularCustomer));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 3, 110, 50, regularCustomer));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 5, 100, 40, regularCustomer));
            string[] dates = "10Dec2020,11Dec2020".Split(",");
            Hotel cheapestHotel = hotelSystem.GivenWeekendAndWeekdayRateReturnBestRatedRestaurantForCustomerWithRegexValidation(dates);
            Assert.AreEqual("Ridgewood", cheapestHotel.name);
        }
    }
}
