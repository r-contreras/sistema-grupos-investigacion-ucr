using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ResearchRepository.Domain.Authentication.ValueObjects;
using FluentAssertions;
using ResearchRepository.Domain.People;


namespace UnitTests.Domain.Authentication
{
    public class RegisterTests
    {
        private static string Email = "email@ucr.ac.cr";
        private static string FirstName = "Nombre";
        private static string FirstLastName = "Apellido1";
        private static string SecondLastName = "Apellido2";
        private static string Country = "Pais";
        private static string Password = "Contrasena12.";
        private static string ConfirmedPassword = "Contrasena12.";
        private static string University = "Universidad de Costa Rica";
        private static string AcademicUnit = "Unidad Academica 1";
        private static string? Degree = "Doctorado";
        private static string? Title = "Doctor";
        private static string? Biography = "Bio";

        [Fact] 
        public void RegisterContructorsTest()
        {//arrange
            Register newUser = new Register(Email,Password);
            Register newUser2 = new Register(Email, Password, ConfirmedPassword);
            Register newUser3 = new Register(FirstName, FirstLastName, SecondLastName, Email, Password, ConfirmedPassword, University, AcademicUnit, Degree, Title, Biography, Country);
            //act 
            newUser.ConfirmedPassword = ConfirmedPassword;
            //assert
            newUser.Email.Should().Be(newUser2.Email).And.Equals(newUser3.Email);
            newUser.Password.Should().Be(newUser2.Password).And.Equals(newUser3.Password);
            newUser.ConfirmedPassword.Should().Be(newUser2.ConfirmedPassword).And.Equals(newUser3.ConfirmedPassword);

        }


        [Fact]
        public void DegreeNullReturnNull()
        {
            //arrange
            string input = null;

            //act
            var result = new Register(FirstName,FirstLastName,SecondLastName,Email,Password,ConfirmedPassword,University,AcademicUnit,
                input,Title,Biography,Country);

            //assert
            result.Degree.Should().Be(null);
        }

        [Fact]
        public void SamePasswordConfirmation()
        {
            string input = "Contrasena12";

            //act
            var result = new Register(FirstName, FirstLastName, SecondLastName, Email, Password, input, University, AcademicUnit,
                Degree, Title, Biography, Country);

            //assert
            result.sameConfirmedPass().Should().Be(false);
        }

        [Fact]
        public void BiographyEmptyReturnEmpty()
        {
            //arrange
            var input = string.Empty;

            //act
            var result = new Register(FirstName, FirstLastName, SecondLastName, Email, Password, ConfirmedPassword, University, AcademicUnit,
                Degree, Title, input, Country);

            //assert
            result.Biography.Should().Be(string.Empty);
        }



    }
}
