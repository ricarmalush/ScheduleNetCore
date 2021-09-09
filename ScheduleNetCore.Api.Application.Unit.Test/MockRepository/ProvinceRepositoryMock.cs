using Moq;
using ScheduleNetCore.Api.Application.Unit.Test.Stubs;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;

namespace ScheduleNetCore.Api.Application.Unit.Test.MockRepository
{
    public class ProvinceRepositoryMock
    {
        public Mock<IProvinceRepository> _provinceRepository { get; set; }

        public ProvinceRepositoryMock()
        {
            _provinceRepository = new Mock<IProvinceRepository>();
            Setup();
        }

        //Creamos un método privado para setear lo que ya tenemos
        private void Setup()
        {
            _provinceRepository.Setup((x) => x.Add(It.IsAny<ProvinceEntity>())).ReturnsAsync(ProvinceStub.provinceEntity1);
            _provinceRepository.Setup((x) => x.DeleteAsync(It.Is<int>(p => p.Equals(1)))).ReturnsAsync(ProvinceStub.provinceEntity1);
            _provinceRepository.Setup((x) => x.Exist(It.IsAny<int>())).ReturnsAsync(true);
            _provinceRepository.Setup((x) => x.GetByName(It.IsAny<ProvinceEntity>())).ReturnsAsync(true);
            _provinceRepository.Setup((x) => x.GetById(It.IsAny<int>())).ReturnsAsync(ProvinceStub.provinceEntity1);
            _provinceRepository.Setup((x) => x.GetAll()).ReturnsAsync(ProvinceStub.clientScheduleList);
            _provinceRepository.Setup((x) => x.UpdateAsync(It.IsAny<ProvinceEntity>())).ReturnsAsync(ProvinceStub.provinceEntity1);
            _provinceRepository.Setup((x) => x.UpdateActive(It.IsAny<int>())).ReturnsAsync(ProvinceStub.provinceEntity1);
            _provinceRepository.Setup((x) => x.UpdateDesactive(It.IsAny<int>())).ReturnsAsync(ProvinceStub.provinceEntity1);
        }
    }
}
