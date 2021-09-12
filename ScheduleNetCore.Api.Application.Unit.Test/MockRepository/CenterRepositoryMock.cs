using Moq;
using ScheduleNetCore.Api.Application.Unit.Test.Stubs;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;

namespace ScheduleNetCore.Api.Application.Unit.Test.MockRepository
{
    public class CenterRepositoryMock
    {
        public Mock<ICenterRepository> _centerRepository { get; set; }

        public CenterRepositoryMock()
        {
            _centerRepository = new Mock<ICenterRepository>();
            Setup();
        }

        //Creamos un método privado para setear lo que ya tenemos
        private void Setup()
        {
            _centerRepository.Setup((x) => x.Add(It.IsAny<CenterEntity>())).ReturnsAsync(CenterStub.centerEntity1);
            _centerRepository.Setup((x) => x.DeleteAsync(It.Is<int>(p => p.Equals(1)))).ReturnsAsync(CenterStub.centerEntity1);
            _centerRepository.Setup((x) => x.Exist(It.IsAny<int>())).ReturnsAsync(true);
            _centerRepository.Setup((x) => x.GetByName(It.IsAny<CenterEntity>())).ReturnsAsync(true);
            _centerRepository.Setup((x) => x.GetById(It.IsAny<int>())).ReturnsAsync(CenterStub.centerEntity1);
            _centerRepository.Setup((x) => x.GetAll()).ReturnsAsync(CenterStub.centerList);
            _centerRepository.Setup((x) => x.UpdateAsync(It.IsAny<CenterEntity>())).ReturnsAsync(CenterStub.centerEntity1);
            _centerRepository.Setup((x) => x.UpdateActive(It.IsAny<int>())).ReturnsAsync(CenterStub.centerEntity1);
            _centerRepository.Setup((x) => x.UpdateDesactive(It.IsAny<int>())).ReturnsAsync(CenterStub.centerEntity1);
        }
    }
}
