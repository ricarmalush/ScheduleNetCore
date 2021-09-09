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
    public class ProvinceTest
    {
        private static IProvinceService _provinceService;

        [ClassInitialize()]
        public static void Setup(TestContext testContext)
        {
            Mock<IProvinceRepository> _provinceRepository = new ProvinceRepositoryMock()._provinceRepository;

            _provinceService = new ProvinceService(_provinceRepository.Object);
        }

        [TestMethod]
        public async Task Dado_una_entidad_devuelve_un_guarda_un_ProvinceEntity()
        {
            //Arrange

            //Act
            var result = await _provinceService.Add(ProvinceStub.provinceEntity1);

            //Assert
            result.Name.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task Dado_un_numero_elimina_un_ProvinceEntity()
        {
            //Arrange

            //Act
            var result = await _provinceService.DeleteAsync(1);

            //Assert
            result.CountryId.Should().Equals(1);
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_id_devuelve_un_province_ok()
        {
            //Arrange

            //Act
            var result = await _provinceService.GetById(1);

            //Assert
            result.Name.Should().NotBeNullOrEmpty();

        }

        [TestMethod]
        public async Task Dado_un_nombre_devuelve_un_bolleano()
        {
            //Arrange


            //Act
            var result = await _provinceService.GetByName(ProvinceStub.provinceEntity1);

            //Assert
            result.Should().Equals(true);

        }

        [TestMethod]
        public async Task Devuelve_un_listado_de_provinces()
        {
            //Arrange

            //Act
            var result = await _provinceService.GetAll();

            //Assert
            result.Should().NotBeNullOrEmpty();//Lista no vacía
            result.Should().HaveCountGreaterOrEqualTo(1);//debe tener al menos un elemento.

        }

        [TestMethod]
        public async Task Dado_una_entidad_devuelve_un_actualiza_un_ProvinceEntity()
        {
            //Arrange

            //Act
            var result = await _provinceService.UpdateAsync(ProvinceStub.provinceEntity1);

            //Assert
            result.Should().NotBeNull();
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_numero_activa_un_ProvinceEntity()
        {
            //Arrange

            //Act
            var result = await _provinceService.UpdateActive(1);

            //Assert
            result.CountryId.Should().Equals(1);
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_numero_desactiva_un_ProvinceEntity()
        {
            //Arrange

            //Act
            var result = await _provinceService.UpdateDesactive(1);

            //Assert
            result.CountryId.Should().Equals(1);
            result.Should().Equals(true);
        }


    }
}
