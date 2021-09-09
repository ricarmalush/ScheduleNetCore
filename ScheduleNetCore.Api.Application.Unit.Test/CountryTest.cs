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
    public class CountryTest
    {
        private static ICountryService _countryService;

        [ClassInitialize()]
        public static void Setup(TestContext testContext)
        {
            Mock<ICountryRepository> _countryRepository = new CountryRepositoryMock()._countryRepository;

            _countryService = new CountryService(_countryRepository.Object);
        }

        [TestMethod]
        public async Task Dado_una_entidad_devuelve_un_guarda_un_CountryEntity()
        {
            //Arrange

            //Act
            var result = await _countryService.Add(CountryStub.countryEntity1);

            //Assert
            result.CountryName.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task Dado_un_numero_elimina_un_CountryEntity()
        {
            //Arrange

            //Act
            var result = await _countryService.DeleteAsync(1);

            //Assert
            result.CountryId.Should().Equals(1);
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_id_devuelve_un_country_ok()
        {
            //Arrange

            //Act
            var result = await _countryService.GetById(1);

            //Assert
            result.CountryName.Should().NotBeNullOrEmpty();

        }

        [TestMethod]
        public async Task Dado_un_nombre_devuelve_un_bolleano()
        {
            //Arrange


            //Act
            var result = await _countryService.GetByName(CountryStub.countryEntity1);

            //Assert
            result.Should().Equals(true);

        }

        [TestMethod]
        public async Task Devuelve_un_listado_de_countries()
        {
            //Arrange

            //Act
            var result = await _countryService.GetAll();

            //Assert
            result.Should().NotBeNullOrEmpty();//Lista no vacía
            result.Should().HaveCountGreaterOrEqualTo(1);//debe tener al menos un elemento.

        }

        [TestMethod]
        public async Task Dado_una_entidad_devuelve_un_actualiza_un_CountryEntity()
        {
            //Arrange

            //Act
            var result = await _countryService.UpdateAsync(CountryStub.countryEntity1);

            //Assert
            result.Should().NotBeNull();
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_numero_activa_un_CountryEntity()
        {
            //Arrange

            //Act
            var result = await _countryService.UpdateActive(1);

            //Assert
            result.CountryId.Should().Equals(1);
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_numero_desactiva_un_CountryEntity()
        {
            //Arrange


            //Act
            var result = await _countryService.UpdateDesactive(1);

            //Assert
            result.CountryId.Should().Equals(1);
            result.Should().Equals(true);
        }


    }
}
