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
    public class CompanyTest
    {
        private static ICompanyService _companyService;

        [ClassInitialize()]
        public static void Setup(TestContext testContext)
        {
            Mock<ICompanyRepository> _companyRepository = new CompanyRepositoryMock()._companyRepository;

            _companyService = new CompanyService(_companyRepository.Object);
        }

        [TestMethod]
        public async Task Dado_una_entidad_devuelve_un_guarda_un_CompanyEntity()
        {
            //Arrange

            //Act
            var existe = await _companyService.GetByName(CompanyStub.companyEntity1);
            var result = await _companyService.Add(CompanyStub.companyEntity1);

            //Assert
            existe.Should().BeTrue();
            result.CompanyName.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task Dado_un_numero_elimina_un_CompanyEntity()
        {
            //Arrange

            //Act
            var result = await _companyService.DeleteAsync(1);

            //Assert
            result.TownId.Should().Equals(1);
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_id_devuelve_un_company_ok()
        {
            //Arrange

            //Act
            var result = await _companyService.GetById(1);

            //Assert
            result.CompanyName.Should().NotBeNullOrEmpty();

        }

        [TestMethod]
        public async Task Dado_un_id_devuelve_un__company_true()
        {
            //Arrange


            //Act
            var result = await _companyService.Exist(1);

            //Assert
            result.Should().BeTrue();

        }

        [TestMethod]
        public async Task Dado_un_nombre_devuelve_un_bolleano()
        {
            //Arrange


            //Act
            var result = await _companyService.GetByName(CompanyStub.companyEntity1);

            //Assert
            result.Should().Equals(true);

        }

        [TestMethod]
        public async Task Devuelve_un_listado_de_company()
        {
            //Arrange

            //Act
            var result = await _companyService.GetAll();

            //Assert
            result.Should().NotBeNullOrEmpty();//Lista no vacía
            result.Should().HaveCountGreaterOrEqualTo(1);//debe tener al menos un elemento.

        }

        [TestMethod]
        public async Task Dado_una_entidad_devuelve_un_actualiza_un_CompanyEntity()
        {
            //Arrange

            //Act
            var result = await _companyService.UpdateAsync(CompanyStub.companyEntity1);

            //Assert
            result.Should().NotBeNull();
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_numero_activa_un_CompanyEntity()
        {
            //Arrange

            //Act
            var result = await _companyService.UpdateActive(1);

            //Assert
            result.TownId.Should().Equals(1);
            result.Should().Equals(true);
        }

        [TestMethod]
        public async Task Dado_un_numero_desactiva_un_CompanyEntity()
        {
            //Arrange

            //Act
            var result = await _companyService.UpdateDesactive(1);

            //Assert
            result.TownId.Should().Equals(1);
            result.Should().Equals(true);
        }


    }
}
