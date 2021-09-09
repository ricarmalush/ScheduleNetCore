using Moq;
using ScheduleNetCore.Api.Application.Unit.Test.Stubs;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;

namespace ScheduleNetCore.Api.Application.Unit.Test.MockRepository
{
    public class TownRepositoryMock
    {
        public Mock<ITownRepository> _townRepository { get; set; }

        public TownRepositoryMock()
        {
            _townRepository = new Mock<ITownRepository>();
            Setup();
        }

        //Creamos un método privado para setear lo que ya tenemos
        private void Setup()
        {
            _townRepository.Setup((x) => x.Add(It.IsAny<TownEntity>())).ReturnsAsync(TownStub.townEntity1);
            _townRepository.Setup((x) => x.DeleteAsync(It.Is<int>(p => p.Equals(1)))).ReturnsAsync(TownStub.townEntity1);
            _townRepository.Setup((x) => x.Exist(It.IsAny<int>())).ReturnsAsync(true);
            _townRepository.Setup((x) => x.GetByName(It.IsAny<TownEntity>())).ReturnsAsync(true);
            _townRepository.Setup((x) => x.GetById(It.IsAny<int>())).ReturnsAsync(TownStub.townEntity1);
            _townRepository.Setup((x) => x.GetAll()).ReturnsAsync(TownStub.townList);
            _townRepository.Setup((x) => x.UpdateAsync(It.IsAny<TownEntity>())).ReturnsAsync(TownStub.townEntity1);
            _townRepository.Setup((x) => x.UpdateActive(It.IsAny<int>())).ReturnsAsync(TownStub.townEntity1);
            _townRepository.Setup((x) => x.UpdateDesactive(It.IsAny<int>())).ReturnsAsync(TownStub.townEntity1);
        }
    }
}
