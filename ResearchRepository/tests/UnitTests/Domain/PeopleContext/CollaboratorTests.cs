using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ResearchRepository.Domain.People.Entities;
using FluentAssertions;
using ResearchRepository.Domain.People;


namespace UnitTests.Domain.PeopleContext
{
    public class CollaboratorTests
    {
        private static string Email = "email@ucr.ac.cr";

        private static string FirstName = "Nombre";

        private static string FirstLastName = "Apellido1";

        private static string SecondLastName = "Apellido2";

        private static string Country = "Pais";

        [Fact]
        public void CollaboratorIsPartOfOneGroup()
        {
            var collaborator = new Collaborator()
            {
                Email = Email,
                FirstName = FirstName,
                FirstLastName = FirstLastName,
                SecondLastName = SecondLastName,
                Country = Country
            };
            var groupCollab = new CollaboratorPartOfGroup()
            {
                Collaborator = collaborator,
                CollaboratorEmail = Email
            };
            collaborator.CollaboratorPartOfGroups = new List<CollaboratorPartOfGroup>();
            collaborator.CollaboratorPartOfGroups.Add(groupCollab);

            var collaborationsWithGroups = collaborator.CollaboratorPartOfGroups;
            collaborationsWithGroups.Count().Should().Be(1);
        }

        [Fact]
        public void collaboratorHasNoCollaborations()
        {
            var collaborator = new Collaborator()
            {
                Email = Email,
                FirstName = FirstName,
                FirstLastName = FirstLastName,
                SecondLastName = SecondLastName,
                Country = Country
            };
            collaborator.CollaboratorPartOfGroups.Should().BeNull();
            collaborator.CollaboratorPartOProject.Should().BeNull();
            collaborator.CollaboratorIsAuthorOfPublication.Should().BeNull();
            collaborator.AuthorPartOfThesis.Should().BeNull();
        }

        [Fact]
        public void CollaboratorIsPartOfOnePublication()
        {
            var collaborator = new Collaborator()
            {
                Email = Email,
                FirstName = FirstName,
                FirstLastName = FirstLastName,
                SecondLastName = SecondLastName,
                Country = Country
            };
            var projectCollab = new CollaboratorPartOfProject()
            {
                Collaborator = collaborator,
                CollaboratorEmail = Email
            };
            var projectAuthor = new CollaboratorIsAuthorOfPublication()
            {
                Collaborator = collaborator,
                IdPublication = "1"
            };
            collaborator.CollaboratorPartOProject = new List<CollaboratorPartOfProject>();
            collaborator.CollaboratorIsAuthorOfPublication = new List<CollaboratorIsAuthorOfPublication>();
            collaborator.CollaboratorPartOProject.Add(projectCollab);
            collaborator.CollaboratorIsAuthorOfPublication.Add(projectAuthor);

            var collaborationsWithProjects = collaborator.CollaboratorPartOProject;
            var authorOfProject = collaborator.CollaboratorIsAuthorOfPublication;
            collaborationsWithProjects.Count().Should().Be(1);
            authorOfProject.Count().Should().Be(1);
        }

        [Fact]
        public void CollaboratorIsPartOfOneThesis()
        {
            var collaborator = new Collaborator()
            {
                Email = Email,
                FirstName = FirstName,
                FirstLastName = FirstLastName,
                SecondLastName = SecondLastName,
                Country = Country
            };
            var thesisCollab = new AuthorPartOfThesis(Email,1,"Lider")
            {
                Collaborator = collaborator,
            };
            var collab = thesisCollab.Collaborator;
            var role = thesisCollab.Role;
            var thesisId = thesisCollab.ThesisId;

            collaborator.AuthorPartOfThesis = new List<AuthorPartOfThesis>();
            collaborator.AuthorPartOfThesis.Add(thesisCollab);

            var collaborationsWithThesis = collaborator.AuthorPartOfThesis;
            collaborationsWithThesis.Count().Should().Be(1);
            collab.Should().NotBeNull();
            role.Should().Be("Lider");
            thesisId.Should().Be(1);
        }


        [Fact]
        public void CollaboratorHasARole()
        {
            var collaborator = new Collaborator()
            {
                Email = Email,
                FirstName = FirstName,
                FirstLastName = FirstLastName,
                SecondLastName = SecondLastName,
                Country = Country
            };
            string role = "Rol de Prueba";
            collaborator.Role = role;
            collaborator.Role.Should().Be(role);
        }

        [Fact]
        public void CollaboratorIsStudent() {
            var studentCollaborator = new Student(Email, FirstName, FirstLastName, SecondLastName, Country);
            string carnet = "B95016";
            studentCollaborator.StudentId = carnet;
            studentCollaborator.StudentId.Should().Be(carnet);
        }

        [Fact]
        public void CollaboratorIsInvestigatorAndManagesAGroup()
        {
            var investigatorManager = new Investigator(Email, FirstName, FirstLastName, SecondLastName, Country);
            var managesGroup = new InvestigatorManagesGroup(Email, 1);
            investigatorManager.InvestigatorManagesGroups = new List<InvestigatorManagesGroup>();
            investigatorManager.InvestigatorManagesGroups.Add(managesGroup);

            var groupsManagedByInvestigator = investigatorManager.InvestigatorManagesGroups;
            groupsManagedByInvestigator.Count().Should().Be(1);
        }
    }
}

