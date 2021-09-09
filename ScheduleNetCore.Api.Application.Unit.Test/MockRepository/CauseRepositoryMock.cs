using Moq;
using ScheduleNetCore.Api.Application.Unit.Test.Stubs;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;

namespace ScheduleNetCore.Api.Application.Unit.Test.MockRepository
{
    public class CauseRepositoryMock
    {
        public Mock<ICauseRepository> _causeRepository { get; set; }

        public CauseRepositoryMock()
        {
            _causeRepository = new Mock<ICauseRepository>();
            Setup();
        }

        //Creamos un método privado para setear lo que ya tenemos
        private void Setup()
        {
            _causeRepository.Setup((x) => x.Add(It.IsAny<CauseEntity>())).ReturnsAsync(CauseStub.causeEntity1);
            _causeRepository.Setup((x) => x.DeleteAsync(It.Is<int>(p => p.Equals(1)))).ReturnsAsync(CauseStub.causeEntity1);
            _causeRepository.Setup((x) => x.Exist(It.IsAny<int>())).ReturnsAsync(true);
            _causeRepository.Setup((x) => x.GetByName(It.IsAny<CauseEntity>())).ReturnsAsync(true);
            _causeRepository.Setup((x) => x.GetById(It.IsAny<int>())).ReturnsAsync(CauseStub.causeEntity1);
            _causeRepository.Setup((x) => x.GetAll()).ReturnsAsync(CauseStub.causeList);
            _causeRepository.Setup((x) => x.UpdateAsync(It.IsAny<CauseEntity>())).ReturnsAsync(CauseStub.causeEntity1);
            _causeRepository.Setup((x) => x.UpdateActive(It.IsAny<int>())).ReturnsAsync(CauseStub.causeEntity1);
            _causeRepository.Setup((x) => x.UpdateDesactive(It.IsAny<int>())).ReturnsAsync(CauseStub.causeEntity1);
        }
    }
}
