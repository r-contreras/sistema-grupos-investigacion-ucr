﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResearchRepository.Domain.Authorization.Repositories;
using ResearchRepository.Application.Authorization.Implementations;
using Moq;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;


namespace UnitTests.Application.Authorization
{
    public class AuthorizationServiceTests
    {
        private static string email = "andrea.alvaradoacon@ucr.ac.cr";
        private static string role = "Administrador";
        private static IList<IdentityUser> CreateIdentityUserList()
        {
            var list = new List<IdentityUser>();
            for (int i = 1; i < 3; i++)
            {
                var entity = new IdentityUser();
                entity.Email = i.ToString() + "@gmail.com";
                list.Add(entity);
            }
            return list;

        }

        private static IList<string> CreateRolesList()
        {
            var list = new List<string>();
            list.Add("Administrador");
            list.Add("Administrador de Grupo");
            list.Add("Administrador de Centro");
            list.Add("Colaborador de Grupo");
            list.Add("Colaborador de Centro");

            return list;
        }


        private static List<string> CreateClaimsList()
        {
            List<string> list = new List<string>();
            list.Add("Administrar personas");
            list.Add("Administrar contactos");
            list.Add("Administrar publicaciones");
            list.Add("Administrar tesis");
            list.Add("Administrar proyectos");

            return list;
        }


        [Fact]
        public async Task getUsersTest()
        {
            //Arrange
            var list = CreateIdentityUserList();
            var mock = new Mock<IAuthorizationRepository>();
            var authorizationServices = new AuthorizationServices(mock.Object);
            mock.Setup(r => r.getUsers()).ReturnsAsync(list);

            //Act
            var users = await authorizationServices.getUsers();

            // assert
            users.Should().BeEquivalentTo(list);
        }


        [Fact]
        public async Task getUsersBySearchTest()
        {
            //Arrange
            var list = CreateIdentityUserList();
            var mock = new Mock<IAuthorizationRepository>();
            var authorizationServices = new AuthorizationServices(mock.Object);
            mock.Setup(r => r.getUsersBySearch(email)).ReturnsAsync(list);

            //Act
            var users = await authorizationServices.getUsersBySearch(email);

            // assert
            users.Should().BeEquivalentTo(list);
        }


        [Fact]
        public async Task getRolesTest()
        {
            //Arrange
            var list = CreateRolesList();
            var mock = new Mock<IAuthorizationRepository>();
            var authorizationServices = new AuthorizationServices(mock.Object);
            mock.Setup(r => r.getRoles()).ReturnsAsync(list);

            //Act
            var roles = await authorizationServices.getRoles();

            // assert
            roles.Should().BeEquivalentTo(list);
        }

        [Fact]
        public async Task getUserRolesTest()
        {
            //Arrange
            var list = CreateRolesList();
            var mock = new Mock<IAuthorizationRepository>();
            var authorizationServices = new AuthorizationServices(mock.Object);
            mock.Setup(r => r.getUserRoles(email)).ReturnsAsync(list);

            //Act
            var userRoles = await authorizationServices.getUserRoles(email);

            // assert
            userRoles.Should().BeEquivalentTo(list);
        }

        [Fact]
        public void getAllClaimsTest()
        {
            //Arrange
            var list = CreateClaimsList();
            var mock = new Mock<IAuthorizationRepository>();
            var authorizationServices = new AuthorizationServices(mock.Object);
            mock.Setup(r => r.getAllClaims()).Returns(list);

            //Act
            var claims = authorizationServices.getAllClaims();

            // assert
            claims.Should().BeEquivalentTo(list);
        }

        [Fact]
        public async Task configureRolesTest() {
            //Arrange
            var mock = new Mock<IAuthorizationRepository>();
            var authorizationServices = new AuthorizationServices(mock.Object);

            //act
            await authorizationServices.configureRoles();

            // assert
            mock.Verify(repo => repo.configureRoles(), Times.Once);

        }

        
        [Fact]
        public async Task assignRoleTest()
        {
            //Arrange
            var mock = new Mock<IAuthorizationRepository>();
            var authorizationServices = new AuthorizationServices(mock.Object);

            //act
            await authorizationServices.assignRole(email,role);

            // assert
            mock.Verify(repo => repo.assignRole(email, role), Times.Once);

        }

        [Fact]
        public async Task removeRoleTest()
        {
            //Arrange
            var mock = new Mock<IAuthorizationRepository>();
            var authorizationServices = new AuthorizationServices(mock.Object);

            //act
            await authorizationServices.removeRole(email, role);

            // assert
            mock.Verify(repo => repo.removeRole(email, role), Times.Once);

        }


        [Fact]
        public async Task isPartOfRoleTest()
        {
            //Arrange
            var mock = new Mock<IAuthorizationRepository>();
            var authorizationServices = new AuthorizationServices(mock.Object);
            mock.Setup(r => r.isPartOfRole(email,role)).ReturnsAsync(false);

            //act
            var result = await authorizationServices.isPartOfRole(email, role);

            // assert
           result.Should().Be(false);

        }

        [Fact]
        public async Task switchRoleStateTest()
        {
            //Arrange
            var mock = new Mock<IAuthorizationRepository>();
            var authorizationServices = new AuthorizationServices(mock.Object);

            //act
            await authorizationServices.switchRoleState(email, role,false);

            // assert
            mock.Verify(repo => repo.switchRoleState(email, role,false), Times.Once);

        }

        [Fact]
        public async Task SeedClaimsForSuperAdministratorTest()
        {
            //Arrange
            var mock = new Mock<IAuthorizationRepository>();
            var authorizationServices = new AuthorizationServices(mock.Object);

            //act
            await authorizationServices.SeedClaimsForSuperAdministrator();

            // assert
            mock.Verify(repo => repo.SeedClaimsForSuperAdministrator(), Times.Once);

        }

        [Fact]
        public async Task AddPermissionClaimTest()
        {
            IdentityRole role = new IdentityRole();
            //Arrange
            var mock = new Mock<IAuthorizationRepository>();
            var authorizationServices = new AuthorizationServices(mock.Object);

            //act
            await authorizationServices.AddPermissionClaim(role);

            // assert
            mock.Verify(repo => repo.AddPermissionClaim(role), Times.Once);

        }

        [Fact]
        public async Task UpdateTest()
        {
            List<string> list = new List<string>();


            //Arrange
            var mock = new Mock<IAuthorizationRepository>();
            var authorizationServices = new AuthorizationServices(mock.Object);

            //act
            await authorizationServices.Update(role,list);

            // assert
            mock.Verify(repo => repo.Update(role,list), Times.Once);

        }


    }
}
