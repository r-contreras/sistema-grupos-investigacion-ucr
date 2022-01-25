using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using ResearchRepository.Domain.Core.Helpers;
using ResearchRepository.Domain.Core.ValueObjects;
using ResearchRepository.Domain.People.Entities;
using ResearchRepository.Domain.People.Repositories;
using FluentAssertions;
using WebApplication_ResearchRepository;
using IntegrationTests.Infrastructure.People;

namespace IntegrationTests.Infrastructure.People.Repositories
{
    //ID: ST-PA-3.4, ST-PA-3.5, ST-PA-3.6
    //Tareas: Crear entidades, mapeos y servicios
    //Participantes: Andrea Alvarado y Sebastián Montero
    public class PersonIntegrationTestClass :
    IClassFixture<PersonFactory<Startup>>
    {
        private readonly PersonFactory<Startup> _factory;
        public PersonIntegrationTestClass(PersonFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAllInvestigators()
        {
            int total = 3;
            var repository = _factory.Server.Services.GetRequiredService<IPersonRepository>();
            var investigators = await repository.GetAsyncInvestigator();
            investigators.Count().Equals(total);
        }

        [Fact]
        public async Task GetAllCollaborators()
        {
            int total = 3;
            var repository = _factory.Server.Services.GetRequiredService<IPersonRepository>();
            var collaborators = await repository.GetAsyncCollaborator();
            collaborators.Count().Equals(total);
        }

        [Fact]
        public async Task GetAllCollaboratorsFromGroup()
        {
            int total = 2;
            int groupId = 1;
            var repository = _factory.Server.Services.GetRequiredService<IPersonRepository>();
            var collabPartOfGroup = await repository.GetAsyncCollaboratorPartOfGroupFromId(groupId);
            collabPartOfGroup.Count().Equals(total);
        }

        [Fact]
        public async Task GetAllInvestigatorsFromGroup()
        {
            int total = 3;
            int groupId = 1;
            var repository = _factory.Server.Services.GetRequiredService<IPersonRepository>();
            var investigatorPartOfGroup = await repository.GetAsyncInvestigatorsFromGroup(groupId);
            investigatorPartOfGroup.Count().Equals(total);
        }

        [Fact]
        public async Task DeleteCollaboratorFromGroup()
        {
            int groupId = 1;
            string collaboratorEmail = "andrea.alvaradoacon@ucr.ac.cr";
            var repository = _factory.Server.Services.GetRequiredService<IPersonRepository>();
            await repository.DeleteCollaboratorPartOfGroup(collaboratorEmail, groupId);

            int peopleInGroup = 1;
            var collabPartOfGroup = await repository.GetAsyncCollaboratorPartOfGroupFromId(groupId);
            collabPartOfGroup.Count().Equals(peopleInGroup);
        }


        [Fact]
        public async Task GetCollaboratorNotInGroup()
        {
            int groupId = 1;
            int notInGroup1 = 1;
            var repository = _factory.Server.Services.GetRequiredService<IPersonRepository>();
            var collaboratorsInGroup = await repository.GetCollaboratorsNotInGroup(groupId);
            collaboratorsInGroup.Count().Should().Equals(notInGroup1);
        }

        [Fact]
        public async Task GetCollaborationsFromEmail()
        {
            int collaborationsAmount = 2;
            string collaboratorEmail = "andrea.alvaradoacon@ucr.ac.cr";
            var repository = _factory.Server.Services.GetRequiredService<IPersonRepository>();
            var collaborations = await repository.GetCollaborationsFromEmail(collaboratorEmail);
            collaborations.Count().Should().Equals(collaborationsAmount);
        }

        [Fact]
        public async Task GetAllPersons()
        {
            int total = 3;
            var repository = _factory.Server.Services.GetRequiredService<IPersonRepository>();
            var persons = await repository.GetAsyncPerson();
            persons.Count().Equals(total);
        }
        [Fact]
        public async Task GetAllStudents()
        {
            int total = 3;
            var repository = _factory.Server.Services.GetRequiredService<IPersonRepository>();
            var students = await repository.GetAsyncStudent();
            students.Count().Equals(total);
        }

        public async Task GetAsyncInvestigatorManagesGroupTest()
        {
            int total = 3;
            var repository = _factory.Server.Services.GetRequiredService<IPersonRepository>();
            var invest = await repository.GetAsyncInvestigatorManagesGroup();
            invest.Count().Equals(total);
        }

        [Fact]
        public async Task GetCollaboratorPartOfGroupFromEmailTest()
        {
            var email = "andrea.alvaradoacon@ucr.ac.cr";
            var group = 1;
            var repository = _factory.Server.Services.GetRequiredService<IPersonRepository>();
            var collaborator = await repository.GetCollaboratorPartOfGroupFromEmail(email, group);
            collaborator.CollaboratorEmail.Equals(email);
        }


        [Fact]
        public async Task GetCollaboratorsInGroupByNameTest()
        {
            var search = "Andrea";
            var group = 1;
            int total = 1;
            var repository = _factory.Server.Services.GetRequiredService<IPersonRepository>();
            var collaborator = await repository.GetCollaboratorsInGroupByName(search, group);
            collaborator.Count().Equals(total);
        }


        [Fact]
        public async Task GetAllStudentsByNameTest()
        {
            int total = 0;
            string search = "erika";
            int groupId = 1;
            var repository = _factory.Server.Services.GetRequiredService<IPersonRepository>();
            var students = await repository.GetAsyncStudent(search, groupId);
            students.Count().Equals(total);
        }

        [Fact]
        public async Task GetAsyncStudentsFromGroupTest()
        {
            int total = 0;
            int groupId = 1;
            var repository = _factory.Server.Services.GetRequiredService<IPersonRepository>();
            var students = await repository.GetAsyncStudentsFromGroup(groupId);
            students.Count().Equals(total);
        }



    }
}
