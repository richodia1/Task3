using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Interfaces;
using WebApi.Models;
using Xunit;

namespace WebApiText
{
   
    public class HotelControllerTest
    {

       
        [Fact]
        public async Task GetHotel_WitValidData_ShouldReturnHotelData()
        {
            //Arrange
            int hotelId = 7294;
            var arrivalDate = Utility.ParseDate("2016-03-15");

            var mockservice = new Mock<IHotelDataService>();

            var mockHotels = Utility.LoadTestData();
            var mockHotel = mockHotels.Where(m => m.Hotel.HotelID == hotelId).FirstOrDefault();

            mockservice
                .Setup(s => s.GetHotelDataAsync(hotelId, arrivalDate.Value))
                .Returns(Task.FromResult(mockHotel));

            var sut = new HotelController(mockservice.Object);
            //Act
            var response = await sut.Get(hotelId, arrivalDate.Value);

            // Assert
          
            var okResult = response.Result as OkObjectResult;
            Assert.Equal(okResult.Value, mockHotel);
        }
    }
}