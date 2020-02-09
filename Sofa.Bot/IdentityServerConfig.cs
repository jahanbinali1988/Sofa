using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Sofa.Teacher
{
    public class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api",new List<string>{"userTitle" })
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "WebClient",
                    ClientName = "Web Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"api", IdentityServerConstants.StandardScopes.OfflineAccess},
                    AlwaysSendClientClaims=true,
                    AlwaysIncludeUserClaimsInIdToken=true,
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = 5184000
                },
                new Client
                {
                    ClientId = "AndroidClient",
                    ClientName = "Android Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"api", IdentityServerConstants.StandardScopes.OfflineAccess},
                    AlwaysSendClientClaims=true,
                    AlwaysIncludeUserClaimsInIdToken=true,
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = 5184000

                },
                new Client
                {
                    ClientId = "IOSClient",
                    ClientName = "IOS Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"api", IdentityServerConstants.StandardScopes.OfflineAccess},
                    AlwaysSendClientClaims=true,
                    AlwaysIncludeUserClaimsInIdToken=true,
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = 5184000
                }
            };
        }

    }
}
