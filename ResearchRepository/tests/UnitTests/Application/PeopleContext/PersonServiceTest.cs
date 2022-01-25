using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResearchRepository.Domain.Core.Helpers;
using ResearchRepository.Domain.Core.ValueObjects;
using ResearchRepository.Domain.People.Entities;
using ResearchRepository.Domain.ResearchGroups.Entities;
using ResearchRepository.Domain.People.Repositories;
using ResearchRepository.Domain.ResearchGroups.Repositories;
using ResearchRepository.Application.People.Implementations;
using Moq;
using Xunit;
using FluentAssertions;


namespace UnitTests.Application.PeopleContext
{
    public class PersonServiceTest
    {

        private static string Email = "email@ucr.ac.cr";

        private static string FirstName = "Nombre";

        private static string FirstLastName = "Apellido1";

        private static string SecondLastName = "Apellido2";

        private static string Country = "Pais";

        private static int GroupId = 1;

        private static int thesisId = 1;

        private static int projectId = 1;

        private static string role = "role";


        private static readonly ResearchCenter Center = new ResearchCenter(RequiredString.TryCreate("Center Name").Success(), null, null, null);
        private static readonly ResearchGroup Group = new ResearchGroup(1, RequiredString.TryCreate("Group Name").Success(), "Group Description", null, DateTime.Now, Center);



        private static IList<Person> CreatePersonList()
        {
            List<Person> list = new List<Person>();
            for (int i = 1; i< 3; i++)
            {
                Person entity = new Person(Email, FirstName, FirstLastName, SecondLastName, Country);
                list.Add(entity);
            }
            return list;
        }

        private static IList<Collaborator> CreateCollaboratorList()
        {
            List<Collaborator> list = new List<Collaborator>();
            for (int i = 1; i < 3; i++)
            {
                Collaborator entity = new Collaborator();
                list.Add(entity);
            }
            return list;
        }


        private static IList<Student> CreateStudentList()
        {
            List<Student> list = new List<Student>();
            for (int i = 1; i < 3; i++)
            {
                Student entity = new Student(Email, FirstName, FirstLastName, SecondLastName, Country);
                list.Add(entity);
            }
            return list;
        }

        private static IList<Investigator> CreateInvestigatorList()
        {
            List<Investigator> list = new List<Investigator>();
            for (int i = 1; i < 3; i++)
            {
                Investigator entity = new Investigator(Email, FirstName, FirstLastName, SecondLastName, Country);
                list.Add(entity);
            }
            return list;
        }
        private static IList<InvestigatorManagesGroup> CreateInvestigatorManagesGroupList()
        {
            List<InvestigatorManagesGroup> list = new List<InvestigatorManagesGroup>();
            for (int i = 1; i < 3; i++)
            {
                InvestigatorManagesGroup entity = new InvestigatorManagesGroup(Email, GroupId);
                list.Add(entity);
            }
            return list;
        }

        private static IList<CollaboratorPartOfGroup> CreateGetCollaborationsList()
        {
            List<CollaboratorPartOfGroup> list = new List<CollaboratorPartOfGroup>();
            for (int i = 1; i < 3; i++)
            {
                CollaboratorPartOfGroup entity = new CollaboratorPartOfGroup(Email, GroupId);
                list.Add(entity);
            }
            return list;
        }


        [Fact]
        public async Task GetAsyncPersonTest()
        {
            var list = CreatePersonList();
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetAsyncPerson()).ReturnsAsync(list);
            
            //Act
            var persons = await personService.GetAsyncPerson();

            // assert
            persons.Should().BeEquivalentTo(list);

        }

        [Fact]
        public async Task GetAsyncCollaboratorTest()
        {
            var list = CreateCollaboratorList();
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetAsyncCollaborator()).ReturnsAsync(list);

            //Act
            var cols = await personService.GetAsyncCollaborator();

            // assert
            cols.Should().BeEquivalentTo(list);

        }


        [Fact]
        public async Task GetAsyncStudentTest()
        {
            var list = CreateStudentList();
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetAsyncStudent()).ReturnsAsync(list);

            //Act
            var students = await personService.GetAsyncStudent();

            // assert
            students.Should().BeEquivalentTo(list);

        }

        [Fact]
        public async Task GetAsyncInvestigatorTest()
        {
            var list = CreateInvestigatorList();
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetAsyncInvestigator()).ReturnsAsync(list);

            //Act
            var investigators = await personService.GetAsyncInvestigator();

            // assert
            investigators.Should().BeEquivalentTo(list);

        }
        
        [Fact]
        public async Task GetAsyncInvestigatorManagesGroupTest()
        {
            var list = CreateInvestigatorManagesGroupList();
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetAsyncInvestigatorManagesGroup()).ReturnsAsync(list);

            //Act
            var investigatorsManages = await personService.GetAsyncInvestigatorManagesGroup();

            // assert
            investigatorsManages.Should().BeEquivalentTo(list);

        }

        [Fact]
        public async Task GetAsyncInvestigatorManagesGroupFromNameAndIdTest()
        {
            var list = CreateInvestigatorManagesGroupList();
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetAsyncInvestigatorManagesGroup(FirstName,GroupId)).ReturnsAsync(list);

            //Act
            var investigatorsManages = await personService.GetAsyncInvestigatorManagesGroup(FirstName, GroupId);

            // assert
            investigatorsManages.Should().BeEquivalentTo(list);

        }


        [Fact]
        public async Task GetCollaborationsFromEmailTest()
        {
            var list = CreateGetCollaborationsList();
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetCollaborationsFromEmail(Email)).ReturnsAsync(list);

            //Act
            var collaborators = await personService.GetCollaborationsFromEmail(Email);

            // assert
            collaborators.Should().BeEquivalentTo(list);

        }


        [Fact]
        public async Task GetCollaboratorPartOfGroupFromEmailTest()
        {
            var entity = new CollaboratorPartOfGroup(Email, GroupId);
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetCollaboratorPartOfGroupFromEmail(Email,GroupId)).ReturnsAsync(entity);

            //Act
            var collaborators = await personService.GetCollaboratorPartOfGroupFromEmail(Email,GroupId);

            // assert
            collaborators.Should().BeEquivalentTo(entity);

        }


        [Fact]
        public async Task GetCollaboratorsInGroupByNameTest()
        {
            string search = "Nom";
            var list = CreateGetCollaborationsList();
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetCollaboratorsInGroupByName(search,GroupId)).ReturnsAsync(list);

            //Act
            var collaborators = await personService.GetCollaboratorsInGroupByName(search, GroupId);

            // assert
            collaborators.Should().BeEquivalentTo(list);

        }

        [Fact]
        public async Task GetPersonByEmailTest()
        {
            
            var person = new Person(Email, FirstName, FirstLastName, SecondLastName, Country);
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetPersonByEmail(Email)).ReturnsAsync(person);

            //Act
            var persons = await personService.GetPersonByEmail(Email);

            // assert
            persons.Should().BeEquivalentTo(person);

        }

        [Fact]
        public async Task PersonHasNoThesis() {
            var person = new Person(Email, FirstName, FirstLastName, SecondLastName, Country);
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);

            var thesis = await personService.GetThesisIdFromAuthor(Email);
            thesis.Should().BeNull();
        }

        [Fact]
        public async Task PersonHasNoPublications()
        {
            var person = new Person(Email, FirstName, FirstLastName, SecondLastName, Country);
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);

            var publications = await personService.GetPublicationsIdFromAuthor(Email);
            publications.Should().BeNull();
        }

        [Fact]
        public async Task PersonHasNoProjects()
        {
            var person = new Person(Email, FirstName, FirstLastName, SecondLastName, Country);
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);

            var projects = await personService.GetProjectsIdFromAuthor(Email);
            projects.Should().BeNull();
        }

        [Fact]
        public async Task PersonWithNoProfilePicReturnsDefault()
        {
            var person = new Person(Email, FirstName, FirstLastName, SecondLastName, Country);
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetProfilePic(Email)).ReturnsAsync("default.png");

            string defaultPicString = "default.png";
            var profilePicture = await personService.GetProfilePic(Email);
            profilePicture.Should().Be(defaultPicString);
        }

        [Fact]
        public async Task CollaboratorsNotInFirstGroup()
        {
            var person = new Person(Email, FirstName, FirstLastName, SecondLastName, Country);
            int groupId = 1;
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            var collaboratorsNotInGroup = await personService.GetCollaboratorsNotInGroup(groupId);
            collaboratorsNotInGroup.Should().BeNull();
        }

        [Fact]
        public async Task AddAuthorPartThesisTest()
        {

            var author = new AuthorPartOfThesis(Email, thesisId, role);
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);

            //Act
            await personService.SaveAsync(author);

            // assert
            mock.Verify(repo => repo.SaveAsync(author), Times.Once);

        }

        [Fact]
        public async Task DeleteAuthorPartThesisTest()
        {

            var author = new AuthorPartOfThesis(Email, thesisId, role);
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            await personService.SaveAsync(author);
            //Act
            await personService.DeleteAuthorOfThesisAsync(Email);

            // assert
            mock.Verify(repo => repo.DeleteAuthorOfThesisAsync(Email), Times.Once);

        }


        [Fact]
        public async Task GetAuthorThesisByEmailEqualColaboratorTest()
        {
            AuthorPartOfThesis authorPartOfThesis = new AuthorPartOfThesis(Email, thesisId, role);
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetAuthorThesisByEmailEqualColaborator(Email)).ReturnsAsync(authorPartOfThesis);

            //Act
            var result = await personService.GetAuthorThesisByEmailEqualColaborator(Email);

            // assert
            result.Should().BeEquivalentTo(authorPartOfThesis);

        }


        [Fact]
        public async Task GetColaboratorByTermCountAsyncTest()
        {
            var list = CreateCollaboratorList();
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetColaboratorByTermCountAsync(1,"term")).ReturnsAsync(list);

            //Act
            var result = await personService.GetColaboratorByTermCountAsync(1, "term");

            // assert
            result.Should().BeEquivalentTo(list);

        }

        [Fact]
        public async Task SaveCollaboratorPartOfProjectAsyncTest()
        {

            var project = new CollaboratorPartOfProject(Email, thesisId, role);
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);

            //Act
            await personService.SaveCollaboratorPartOfProjectAsync(project);

            // assert
            mock.Verify(repo => repo.SaveCollaboratorPartOfProjectAsync(project), Times.Once);

        }

        [Fact]
        public async Task DeleteCollaboratorOfProjectAsyncTest()
        {

            var project = new CollaboratorPartOfProject(Email, projectId, role);
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            await personService.SaveCollaboratorPartOfProjectAsync(project);
            //Act
            await personService.DeleteCollaboratorOfProjectAsync(Email);

            // assert
            mock.Verify(repo => repo.DeleteCollaboratorOfProjectAsync(Email), Times.Once);

        }


        [Fact]
        public async Task GetAuthorByEmailEqualColaboratorTest()
        {
            CollaboratorIsAuthorOfPublication colab = new CollaboratorIsAuthorOfPublication();
            colab.EmailCollaborator = Email;
            colab.IdPublication = "publication";
            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetAuthorByEmailEqualColaborator(Email)).ReturnsAsync(colab);

            //Act
            var result = await personService.GetAuthorByEmailEqualColaborator(Email);

            // assert
            result.Should().BeEquivalentTo(colab);

        }

        [Fact]
        public async Task GetCollaboratorsofProjectByEmailTest()
        {
            IList<CollaboratorPartOfProject> list = new List<CollaboratorPartOfProject>();

            var mock = new Mock<IPersonRepository>();
            var personService = new PersonService(mock.Object);
            mock.Setup(r => r.GetCollaboratorsofProjectByEmail(list)).ReturnsAsync(list);

            //Act
            var result = await personService.GetCollaboratorsofProjectByEmail(list);

            // assert
            list.Should().BeEquivalentTo(result);

        }


    }

}

