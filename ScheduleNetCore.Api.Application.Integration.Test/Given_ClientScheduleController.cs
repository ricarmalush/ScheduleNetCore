using FluentAssertions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.Application.Integration.Test
{
    [TestClass]
    public class Given_ClientScheduleController
    {
        //Propiedad para levantar nuestro servidor de prueba.
        private readonly TestServer _server;

        //Hacer llamadas y peticiones como si fuera un cliente externo.
        private readonly HttpClient _client;
        public Given_ClientScheduleController()
        {
            //Creamos un nuevo test server.
            _server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>());

            //Creamos nuestro cliente.
            _client = _server.CreateClient();
        }

        [TestMethod]
        public async Task Given_Id_Expect_Client_name_should_not_null()
        {
            //Arrange
            var response = await _client.GetAsync("/api/ClientSchedule/GetAll");

            //FluentAssertions
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
