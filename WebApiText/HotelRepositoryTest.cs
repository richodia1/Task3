using Microsoft.AspNetCore.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repositories;
using Xunit;

namespace WebApiText
{
   public class HotelRepositoryTest
    {
        [Fact]
        public async Task GetHotelsAsync_ShouldReturnHotels()
        {
            //Arrange
            var mockHost = new Mock<IHostingEnvironment>();
            mockHost.SetupGet(h => h.ContentRootPath).Returns(Directory.GetCurrentDirectory());
            var sut = new HotelRepository(mockHost.Object);

            //Act
            var result = await sut.GetHotelsAsync();

            //Assert
            Assert.True(result.Any(), "No Hotels were Returned");
        }

        [Fact]
        public async Task GetHotelsAsync_WithInvalidEnvPath_ShouldReturnEmptyHotels()
        {
            //Arrange
            var mockHost = new Mock<IHostingEnvironment>();
            mockHost.SetupGet(h => h.ContentRootPath).Returns("invalid_path");
            var sut = new HotelRepository(mockHost.Object);

            //Act
            var result = await sut.GetHotelsAsync();

            //Assert
            Assert.False(result.Any(), "Hotels were Returned");
        }
    }
}