using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Services;
using Xunit;

namespace WebApiText
{
   public class HotelServiceTest
    {
        [Fact]
        public async Task GetHotelData_WithValidHotelIdAndarrivalDate_ShouldReturnHotel()
        {
            //Arrange
            int hotelId = 7294;
            var arrivalDate = Utility.ParseDate("2016-03-15");
            var mockHotels = Utility.LoadTestData();
            var mockRepo = new Mock<IHotelRepository>();

            mockRepo.Setup(r => r.GetHotelsAsync()).Returns(Task.FromResult(mockHotels));
            var sut = new HotelDataService(mockRepo.Object);
            //Act
            var result = await sut.GetHotelDataAsync(hotelId, arrivalDate.Value);

            //Assert			
        
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetHotelData_WithInvalidHotelId_ShouldReturnEmptyHotel()
        {
            //Arrange
            int hotelId = 67763;
            var arrivalDate = Utility.ParseDate("2016-03-15");

            var mockHotels = Utility.LoadTestData();

            var mockRepo = new Mock<IHotelRepository>();
            mockRepo.Setup(r => r.GetHotelsAsync()).Returns(Task.FromResult(mockHotels));

            var sut = new HotelDataService(mockRepo.Object);
            //Act
            var result = await sut.GetHotelDataAsync(hotelId, arrivalDate.Value);

            //Assert		
            Assert.Null(result);
        }
    }
}