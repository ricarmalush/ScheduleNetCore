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
    public class CauseSub
    {
        private static ITownService _townService;

        [ClassInitialize()]
        public static void Setup(TestContext testContext)
        {
            Mock<ITownRepository> _townRepository = new TownRepositoryMock()._townRepository;

            _townService = new TownService(_townRepository.Object);
        }

        [TestMethod]
        public async Task Dado_una_entidad_devuelve_un_guarda_un_TownEntity()
        {
            //Arrange

            //Act
            var result = await _townService.Add(TownStub.townEntity1);

            //Assert
            result.Name.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task Dado_un_numero_elimina_un_TownEntity()
        {
            //Arrange

            //Act
            var result = await _townService.DeleteAsync(1);

            //Assert
            result.TownId.Should().Equals(1);
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_id_devuelve_un_town_ok()
        {
            //Arrange

            //Act
            var result = await _townService.GetById(1);

            //Assert
            result.Name.Should().NotBeNullOrEmpty();

        }

        [TestMethod]
        public async Task Devuelve_un_listado_de_towns()
        {
            //Arrange

            //Act
            var result = await _townService.GetAll();

            //Assert
            result.Should().NotBeNullOrEmpty();//Lista no vacía
            result.Should().HaveCountGreaterOrEqualTo(1);//debe tener al menos un elemento.

        }

        [TestMethod]
        public async Task Dado_una_entidad_devuelve_un_actualiza_un_TownEntity()
        {
            //Arrange

            //Act
            var result = await _townService.UpdateAsync(TownStub.townEntity1);

            //Assert
            result.Should().NotBeNull();
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_numero_activa_un_TownEntity()
        {
            //Arrange

            //Act
            var result = await _townService.UpdateActive(1);

            //Assert
            result.TownId.Should().Equals(1);
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_numero_desactiva_un_TownEntity()
        {
            //Arrange

            //Act
            var result = await _townService.UpdateDesactive(1);

            //Assert
            result.TownId.Should().Equals(1);
            result.Should().Equals(true);
        }


    }
}
