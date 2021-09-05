using IdentityServer4.Models;
using System.Collections.Generic;

namespace ScheduleNetCore.Web
{
    public static class Config
    {
        //Devuelve una lista de clientes
        public static IEnumerable<Client> GetClient()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="Client1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets=
                    {
                        //Esto es lo que tenemos que darle al cliente para que se conecte a nuestra API
                        new Secret("Secreto".Sha256())
                    },
                    AllowedScopes={ "resourceApi1" }
                },
                new Client
                {
                    ClientId="Client2",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets=
                    {
                        //Esto es lo que tenemos que darle al cliente para que se conecte a nuestra API
                        new Secret("Secreto2".Sha256())
                    },
                    AllowedScopes={ "resourceApi1" }
                },
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("resourceApi1","Mi recurso")
            };
        }
    }
}
