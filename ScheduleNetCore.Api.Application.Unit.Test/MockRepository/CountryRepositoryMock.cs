using Moq;
using ScheduleNetCore.Api.Application.Unit.Test.Stubs;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.Application.Unit.Test.MockRepository
{
    public class CountryRepositoryMock
    {
        public Mock<ICountryRepository> _countryRepository { get; set; }

        public CountryRepositoryMock()
        {
            _countryRepository = new Mock<ICountryRepository>();
            Setup();
        }

        //Creamos un método privado para setear lo que ya tenemos
        private void Setup()
        {
            _countryRepository.Setup((x) => x.Add(It.IsAny<CountryEntity>())).ReturnsAsync(CountryStub.countryEntity1);
            _countryRepository.Setup((x) => x.DeleteAsync(It.Is<int>(p => p.Equals(1)))).ReturnsAsync(CountryStub.countryEntity1);
            _countryRepository.Setup((x) => x.Exist(It.IsAny<int>())).ReturnsAsync(true);
            _countryRepository.Setup((x) => x.GetByName(It.IsAny<CountryEntity>())).ReturnsAsync(true);
            _countryRepository.Setup((x) => x.GetById(It.IsAny<int>())).ReturnsAsync(CountryStub.countryEntity1);
            _countryRepository.Setup((x) => x.GetAll()).ReturnsAsync(CountryStub.clientScheduleList);
            _countryRepository.Setup((x) => x.UpdateAsync(It.IsAny<CountryEntity>())).ReturnsAsync(CountryStub.countryEntity1);
            _countryRepository.Setup((x) => x.UpdateActive(It.IsAny<int>())).ReturnsAsync(CountryStub.countryEntity1);
            _countryRepository.Setup((x) => x.UpdateDesactive(It.IsAny<int>())).ReturnsAsync(CountryStub.countryEntity1);
        }
    }
}
