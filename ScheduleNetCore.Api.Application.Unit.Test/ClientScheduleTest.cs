using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ScheduleNetCore.Api.Application.Contracts.Services;
using ScheduleNetCore.Api.Application.Services;
using ScheduleNetCore.Api.Application.Unit.Test.MockRepository;
using ScheduleNetCore.Api.Application.Unit.Test.Stubs;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.Application.Unit.Test
{
    [TestClass]
    public class ClientScheduleTest
    {
        private static IClientScheduleService _clientScheduleService;

        [ClassInitialize()]
        public static void Setup(TestContext testContext)
        {
            Mock<IClientScheduleRepository> _clientScheduleRepository = new ClientScheduleRepositoryMock()._clientScheduleRepository;

            _clientScheduleService = new ClientScheduleService(_clientScheduleRepository.Object);
        }

        [TestMethod]
        public async Task dado_un_id_devuelve_un_admin_ok()
        {
            //Arrange


            //Act
            var result = await _clientScheduleService.GetById(1);

            //Assert
            result.ClientName.Should().NotBeNullOrEmpty();

        }

        [TestMethod]
        public async Task devuelve_un_listado_de_clientes()
        {
            //Arrange


            //Act
            var result = await _clientScheduleService.GetAll();

            //Assert
            result.Should().NotBeNullOrEmpty();//Lista no vac�a
            result.Should().HaveCountGreaterOrEqualTo(1);//debe tener al menos un elemento.

        }

        [TestMethod]
        public async Task dado_una_entidad_devuelve_un_guarda_un_ClientScheduleEntity()
        {
            //Arrange


            //Act
            var result = await _clientScheduleService.Add(ClientScheduleStub.clientScheduleEntity1);

            //Assert
            result.Should().Equals(true);

        }

        [TestMethod]
        public async Task dado_una_entidad_devuelve_un_actualiza_un_ClientScheduleEntity()
        {
            //Arrange


            //Act
            var result = await _clientScheduleService.UpdateAsync(ClientScheduleStub.clientScheduleEntity1);

            //Assert
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task dado_un_numero_elimina_un_ClientScheduleEntity()
        {
            //Arrange


            //Act
            var result = await _clientScheduleService.DeleteAsync(1);

            //Assert
            result.ClientScheduleId.Should().Equals(1);
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task dado_un_numero_activa_un_ClientScheduleEntity()
        {
            //Arrange


            //Act
            var result = await _clientScheduleService.UpdateActive(1);

            //Assert
            result.ClientScheduleId.Should().Equals(1);
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task dado_un_numero_desactiva_un_ClientScheduleEntity()
        {
            //Arrange


            //Act
            var result = await _clientScheduleService.UpdateDesactive(1);

            //Assert
            result.ClientScheduleId.Should().Equals(1);
            result.Should().Equals(true);
        }


    }
}
