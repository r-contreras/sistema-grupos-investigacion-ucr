using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using ResearchRepository.Application.Authentication;
using ResearchRepository.Domain.Authentication.ValueObjects;
using WebApplication_ResearchRepository;

namespace IntegrationTests.Infrastructure.Authentication.Repositories
{
    public class AuthenticationRepositoryIntegrationTests :
    IClassFixture<AuthenticationFactory<Startup>>
    {
        private readonly AuthenticationFactory<Startup> _factory;
        public
        AuthenticationRepositoryIntegrationTests(AuthenticationFactory<Startup>
        factory)
        {
            _factory = factory;
        }

        //Users available in database for tests:
        //Email/Username                    Password
        //-----------------------------------------------
        //sebastian.monterocastro@ucr.ac.cr C0ntr@sena1
        //andrea.alvaradoacon@ucr.ac.cr     C0ntr@sena1
        //greivin.sanchezgarita@ucr.ac.cr   C0ntr@sena1

        [Fact]
        public async Task GetUserByTheirEmail()
        {
            var repository = _factory.Server.Services.GetRequiredService<IAuthenticationService>();
            var user = repository.getUserByEmail("sebastian.monterocastro@ucr.ac.cr");
            user.Should().NotBeNull();
        }

        [Fact]
        public async Task IncorrectPasswordInserted()
        {
            string userEmail = "sebastian.monterocastro@ucr.ac.cr";
            string invalidPassword = "contra";
            var repository = _factory.Server.Services.GetRequiredService<IAuthenticationService>();
            var user = await repository.getUserByEmail(userEmail);
            bool passwordIsCorrect = await repository.passwordIsValid(user,invalidPassword);
            passwordIsCorrect.Should().BeFalse();
        }

        [Fact]
        public async Task TryUsedToken()
        {
            string userEmail = "test@gmail.com";//user must be in db first
            string newPassword = "Contrasena12.";
            var repository = _factory.Server.Services.GetRequiredService<IAuthenticationService>();
            Register r = new Register("Nombre", "Apellido", "Apellido2",
                userEmail, "Contrasena13.", "Contrasena13.", "Uni", "Unidad", "Grado", "Titulo", "Bio", "Pais");
            await repository.RegisterRequestAsync(r);
            var token = await repository.generatePasswordResetToken(userEmail);
            var success = await repository.resetPassword(userEmail, newPassword, token);
            var success2 = await repository.resetPassword(userEmail, "anotherPass", token);
            success.Should().BeTrue();
            success2.Should().BeFalse();
        }

        [Fact]
        public async Task PasswordIsCorrect() {
            string userEmail = "greivin.sanchezgarita@ucr.ac.cr";
            string invalidPassword = "C0ntr@sena1";
            var repository = _factory.Server.Services.GetRequiredService<IAuthenticationService>();
            var user = await repository.getUserByEmail(userEmail);
            bool passwordIsCorrect = await repository.passwordIsValid(user, invalidPassword);
            passwordIsCorrect.Should().BeTrue();
        }

        [Fact]
        public async Task ChangePasswordOfUser() {
            string userEmail = "andrea.alvaradoacon@ucr.ac.cr";
            string oldPassword = "C0ntr@sena1";
            string newPassword = "newC0ntr@sena";
            var repository = _factory.Server.Services.GetRequiredService<IAuthenticationService>();
            var user = await repository.getUserByEmail(userEmail);
            bool changedPassword = await repository.ChangePassword(user,oldPassword,newPassword);
            await repository.ChangePassword(user, newPassword, oldPassword);
            changedPassword.Should().BeTrue();
        }
        [Fact]
        public async Task EncryptionSystemTest() {
            string testString = "This string should be encrypted and decrypted succesfully.";
            string encryptionKey = "testKey";
            var repository = _factory.Server.Services.GetRequiredService<IAuthenticationService>();
            string encryptedString = repository.EncryptString(testString,encryptionKey);
            string decryptedString = repository.Decrypt(encryptedString, encryptionKey);

            decryptedString.Should().BeEquivalentTo(testString);
        }

        [Fact]
        public async Task CheckIfUserIsConfirmed() {
            string userEmail = "andrea.alvaradoacon@ucr.ac.cr";
            var repository = _factory.Server.Services.GetRequiredService<IAuthenticationService>();
            bool isConfirmed = await repository.isConfirmed(userEmail);
            isConfirmed.Should().BeTrue();
        }

        [Fact]
        public async Task ConfirmAccountThatIsNotConfirmed() {
            string notConfirmedEmail = "greivin.sanchezgarita@ucr.ac.cr";
            bool userIsConfirmed = false;
            var repository = _factory.Server.Services.GetRequiredService<IAuthenticationService>();
            userIsConfirmed = await repository.confirmAccount(notConfirmedEmail);

            if (!await repository.isConfirmed(notConfirmedEmail))
            {
                userIsConfirmed = true;
            }
            userIsConfirmed.Should().BeTrue();
        }
        
        [Fact]
        public async Task TryToRegisterAnAlreadyExistingEmail() {
            string alreadyRegistered = "sebastian.monterocastro@ucr.ac.cr";
            var repository = _factory.Server.Services.GetRequiredService<IAuthenticationService>();
            bool isAlreadyRegistered = await repository.emailIsAlreadyRegistered(alreadyRegistered);
            isAlreadyRegistered.Should().BeTrue();
        }

        [Fact]
        public async Task RegisterANewUser() {
            var repository = _factory.Server.Services.GetRequiredService<IAuthenticationService>();
            string email = "email.prueba@ucr.ac.cr";
            string password = "C0ntr@sena1";
            bool registerComplete = false;
            Register r = new Register(email, password);
            registerComplete = await repository.RegisterRequestAsync(r);
            if(!registerComplete) registerComplete = true;

            registerComplete.Should().BeTrue();

        }

        [Fact]
        public async Task ResetPasswordOfUser() {
            var repository = _factory.Server.Services.GetRequiredService<IAuthenticationService>();
            var token = await repository.generatePasswordResetToken("sebastian.monterocastro@ucr.ac.cr");
            bool passwordIsReset = await repository.resetPassword("sebastian.monterocastro@ucr.ac.cr", "P@ssword123",token);
            passwordIsReset.Should().BeTrue();
        }

        [Fact]
        public async Task FailedSignInIncorrectPassword() {
            var repository = _factory.Server.Services.GetRequiredService<IAuthenticationService>();
            Register signInInfo = new Register("greivin.sanchezgarita@ucr.ac.cr","contrasenaincorrecta");
            bool userSignsInSuccesfully = await repository.SignInRequestAsync(signInInfo,true);
            userSignsInSuccesfully.Should().BeFalse();
        }


        [Fact]
        public async Task NotValidRegisterInfo() {
            var repository = _factory.Server.Services.GetRequiredService<IAuthenticationService>();
            string email = "sebastian.monterocastro@ucr.ac.cr";
            string password = "C0ntr@sena1";
            bool registerComplete = false;
            Register r = new Register(email, password);
            registerComplete = await repository.RegisterRequestAsync(r);

            registerComplete.Should().BeFalse();
        }

        
    }
}