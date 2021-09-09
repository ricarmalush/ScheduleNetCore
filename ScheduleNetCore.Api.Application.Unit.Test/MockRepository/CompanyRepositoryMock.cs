using Moq;
using ScheduleNetCore.Api.Application.Unit.Test.Stubs;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;

namespace ScheduleNetCore.Api.Application.Unit.Test.MockRepository
{
    public class CompanyRepositoryMock
    {
        public Mock<ICompanyRepository> _companyRepository { get; set; }

        public CompanyRepositoryMock()
        {
            _companyRepository = new Mock<ICompanyRepository>();
            Setup();
        }

        //Creamos un método privado para setear lo que ya tenemos
        private void Setup()
        {
            _companyRepository.Setup((x) => x.Add(It.IsAny<CompanyEntity>())).ReturnsAsync(CompanyStub.companyEntity1);
            _companyRepository.Setup((x) => x.DeleteAsync(It.Is<int>(p => p.Equals(1)))).ReturnsAsync(CompanyStub.companyEntity1);
            _companyRepository.Setup((x) => x.Exist(It.IsAny<int>())).ReturnsAsync(true);
            _companyRepository.Setup((x) => x.GetByName(It.IsAny<CompanyEntity>())).ReturnsAsync(true);
            _companyRepository.Setup((x) => x.GetById(It.IsAny<int>())).ReturnsAsync(CompanyStub.companyEntity1);
            _companyRepository.Setup((x) => x.GetAll()).ReturnsAsync(CompanyStub.companyList);
            _companyRepository.Setup((x) => x.UpdateAsync(It.IsAny<CompanyEntity>())).ReturnsAsync(CompanyStub.companyEntity1);
            _companyRepository.Setup((x) => x.UpdateActive(It.IsAny<int>())).ReturnsAsync(CompanyStub.companyEntity1);
            _companyRepository.Setup((x) => x.UpdateDesactive(It.IsAny<int>())).ReturnsAsync(CompanyStub.companyEntity1);
        }
    }
}
