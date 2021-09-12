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
    public class CenterTest
    {
        private static ICenterService _centerService;

        [ClassInitialize()]
        public static void Setup(TestContext testContext)
        {
            Mock<ICenterRepository> _centerRepository = new CenterRepositoryMock()._centerRepository;

            _centerService = new CenterService(_centerRepository.Object);
        }

        [TestMethod]
        public async Task Dado_una_entidad_devuelve_un_guarda_un_CenterEntity()
        {
            //Arrange


            //Act
            var existe = await _centerService.GetByName(CenterStub.centerEntity1);
            var result = await _centerService.Add(CenterStub.centerEntity1);

            //Assert
            existe.Should().BeTrue();
            result.CenterName.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task Dado_un_numero_elimina_un_CenterEntity()
        {
            //Arrange


            //Act
            var result = await _centerService.DeleteAsync(1);

            //Assert
            result.ClientScheduleId.Should().Equals(1);
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_id_devuelve_un_center_ok()
        {
            //Arrange


            //Act
            var result = await _centerService.GetById(1);

            //Assert
            result.CenterName.Should().NotBeNullOrEmpty();

        }

        [TestMethod]
        public async Task Dado_un_id_devuelve_un_center_true()
        {
            //Arrange


            //Act
            var result = await _centerService.Exist(1);

            //Assert
            result.Should().BeTrue();

        }

        [TestMethod]
        public async Task Dado_un_nombre_devuelve_un_boleano()
        {
            //Arrange


            //Act
            var result = await _centerService.GetByName(CenterStub.centerEntity1);

            //Assert
            result.Should().Equals(true);

        }

        [TestMethod]
        public async Task Devuelve_un_listado_de_centers()
        {
            //Arrange


            //Act
            var result = await _centerService.GetAll();

            //Assert
            result.Should().NotBeNullOrEmpty();//Lista no vacía
            result.Should().HaveCountGreaterOrEqualTo(1);//debe tener al menos un elemento.

        }

        [TestMethod]
        public async Task Dado_una_entidad_devuelve_un_actualiza_un_CenterEntity()
        {
            //Arrange


            //Act
            var result = await _centerService.UpdateAsync(CenterStub.centerEntity1);

            //Assert
            result.Should().NotBeNull();
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_numero_activa_un_CenterEntity()
        {
            //Arrange


            //Act
            var result = await _centerService.UpdateActive(1);

            //Assert
            result.ClientScheduleId.Should().Equals(1);
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_numero_desactiva_un_CenterEntity()
        {
            //Arrange

            //Act
            var result = await _centerService.UpdateDesactive(1);

            //Assert
            result.ClientScheduleId.Should().Equals(1);
            result.Should().Equals(true);
        }


    }
}
