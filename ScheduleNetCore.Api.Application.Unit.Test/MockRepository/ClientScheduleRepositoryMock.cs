using Moq;
using ScheduleNetCore.Api.Application.Unit.Test.Stubs;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.Contracts.Repositories;

namespace ScheduleNetCore.Api.Application.Unit.Test.MockRepository
{
    public class ClientScheduleRepositoryMock
    {
        public Mock<IClientScheduleRepository> _clientScheduleRepository { get; set; }

        public ClientScheduleRepositoryMock()
        {
            _clientScheduleRepository = new Mock<IClientScheduleRepository>();
            Setup();
        }

        //Creamos un método privado para setear lo que ya tenemos
        private void Setup()
        {
            _clientScheduleRepository.Setup((x) => x.Add(It.IsAny<ClientScheduleEntity>())).ReturnsAsync(ClientScheduleStub.clientScheduleEntity1);
            _clientScheduleRepository.Setup((x) => x.DeleteAsync(It.Is<int>(p => p.Equals(1)))).ReturnsAsync(ClientScheduleStub.clientScheduleEntity1);
            _clientScheduleRepository.Setup((x) => x.Exist(It.IsAny<int>())).ReturnsAsync(true);
            _clientScheduleRepository.Setup((x) => x.GetByName(It.IsAny<ClientScheduleEntity>())).ReturnsAsync(true);
            _clientScheduleRepository.Setup((x) => x.GetById(It.IsAny<int>())).ReturnsAsync(ClientScheduleStub.clientScheduleEntity1);
            _clientScheduleRepository.Setup((x) => x.GetAll()).ReturnsAsync(ClientScheduleStub.clientScheduleList);
            _clientScheduleRepository.Setup((x) => x.UpdateAsync(It.IsAny<ClientScheduleEntity>())).ReturnsAsync(ClientScheduleStub.clientScheduleEntity1);
            _clientScheduleRepository.Setup((x) => x.UpdateActive(It.IsAny<int>())).ReturnsAsync(ClientScheduleStub.clientScheduleEntity1);
            _clientScheduleRepository.Setup((x) => x.UpdateDesactive(It.IsAny<int>())).ReturnsAsync(ClientScheduleStub.clientScheduleEntity1);
        }
    }
}
