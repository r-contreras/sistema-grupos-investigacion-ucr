using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResearchRepository.Domain.Authentication.Repositories;
using ResearchRepository.Application.Authentication.Implementations;
using Moq;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ResearchRepository.Domain.Authentication.ValueObjects;

namespace UnitTests.Application.Authentication
{
    public class AuthenticationTests
    {
        private static string email = "andrea.alvaradoacon@ucr.ac.cr";
        private static string password = "Contrasena12.";

        [Fact]
        public async Task RegisterRequestAsyncTest()
        {
            //Arrange
            Register register = new Register(email,password);
            var mock = new Mock<IAuthenticationRepository>();
            var authenticationService = new AuthenticationService(mock.Object);
            mock.Setup(r => r.RegisterRequestAsync(register)).ReturnsAsync(true);

            //Act
            var result = await authenticationService.RegisterRequestAsync(register);

            // assert
            result.Should().Be(true);
        }

        [Fact]
        public async Task SignInRequestAsyncTest()
        {
            //Arrange
            Register register = new Register(email, password);
            var mock = new Mock<IAuthenticationRepository>();
            var authenticationService = new AuthenticationService(mock.Object);
            mock.Setup(r => r.SignInRequestAsync(register,true)).ReturnsAsync(true);

            //Act
            var result = await authenticationService.SignInRequestAsync(register,true);

            // assert
            result.Should().Be(true);
        }

        [Fact]
        public async Task SignOutTest()
        {
            //Arrange
            var mock = new Mock<IAuthenticationRepository>();
            var authenticationService = new AuthenticationService(mock.Object);

            //Act
            await authenticationService.SignOut();

            // assert
            mock.Verify(repo => repo.SignOut(), Times.Once);


        }


        [Fact]
        public async Task confirmAccountTest()
        {
            //Arrange
            IdentityUser user = new IdentityUser();
            user.Email = email;
            var mock = new Mock<IAuthenticationRepository>();
            var authenticationService = new AuthenticationService(mock.Object);
            mock.Setup(r => r.confirmAccount(email)).ReturnsAsync(true);

            //Act
            var result = await authenticationService.confirmAccount(email);

            // assert
            result.Should().Be(true);
        }


        [Fact]
        public async Task isConfirmedTest()
        {
            //Arrange
            IdentityUser user = new IdentityUser();
            user.Email = email;
            var mock = new Mock<IAuthenticationRepository>();
            var authenticationService = new AuthenticationService(mock.Object);
            mock.Setup(r => r.isConfirmed( email)).ReturnsAsync(true);

            //Act
            var result = await authenticationService.isConfirmed( email);

            // assert
            result.Should().Be(true);
        }

        [Fact]
        public async Task sendConfirmationTest()
        {
            
            IdentityUser user = new IdentityUser();
            user.Email = email;
            var mock = new Mock<IAuthenticationRepository>();
            var authenticationService = new AuthenticationService(mock.Object);
            await authenticationService.sendConfirmation(email);
            mock.Verify(repo => repo.sendConfirmation(email), Times.Once);

        }

    }
}
