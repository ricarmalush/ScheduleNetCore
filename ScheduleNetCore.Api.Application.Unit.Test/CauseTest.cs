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
    public class CauseTest
    {
        private static ICauseService _causeService;

        [ClassInitialize()]
        public static void Setup(TestContext testContext)
        {
            Mock<ICauseRepository> _causeRepository = new CauseRepositoryMock()._causeRepository;

            _causeService = new CauseService(_causeRepository.Object);
        }

        [TestMethod]
        public async Task Dado_una_entidad_devuelve_un_guarda_un_CauseEntity()
        {
            //Arrange


            //Act
            var existe = await _causeService.GetByName(CauseStub.causeEntity1);
            var result = await _causeService.Add(CauseStub.causeEntity1);

            //Assert
            existe.Should().BeTrue();
            result.CauseName.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task Dado_un_numero_elimina_un_CauseEntity()
        {
            //Arrange


            //Act
            var result = await _causeService.DeleteAsync(1);

            //Assert
            result.ClientScheduleId.Should().Equals(1);
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_id_devuelve_un_cause_ok()
        {
            //Arrange


            //Act
            var result = await _causeService.GetById(1);

            //Assert
            result.CauseName.Should().NotBeNullOrEmpty();

        }

        [TestMethod]
        public async Task Dado_un_id_devuelve_un_cause_true()
        {
            //Arrange


            //Act
            var result = await _causeService.Exist(1);

            //Assert
            result.Should().BeTrue();

        }

        [TestMethod]
        public async Task Dado_un_nombre_devuelve_un_boleano()
        {
            //Arrange


            //Act
            var result = await _causeService.GetByName(CauseStub.causeEntity1);

            //Assert
            result.Should().Equals(true);

        }

        [TestMethod]
        public async Task Devuelve_un_listado_de_causes()
        {
            //Arrange


            //Act
            var result = await _causeService.GetAll();

            //Assert
            result.Should().NotBeNullOrEmpty();//Lista no vacía
            result.Should().HaveCountGreaterOrEqualTo(1);//debe tener al menos un elemento.

        }

        [TestMethod]
        public async Task Dado_una_entidad_devuelve_un_actualiza_un_CauseEntity()
        {
            //Arrange


            //Act
            var result = await _causeService.UpdateAsync(CauseStub.causeEntity1);

            //Assert
            result.Should().NotBeNull();
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_numero_activa_un_CauseEntity()
        {
            //Arrange


            //Act
            var result = await _causeService.UpdateActive(1);

            //Assert
            result.ClientScheduleId.Should().Equals(1);
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_numero_desactiva_un_CauseEntity()
        {
            //Arrange

            //Act
            var result = await _causeService.UpdateDesactive(1);

            //Assert
            result.ClientScheduleId.Should().Equals(1);
            result.Should().Equals(true);
        }


    }
}
