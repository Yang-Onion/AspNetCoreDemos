using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;

public class InMemoryConfiguration
{
  public static IConfiguration Configuration{get;set;}

  public static IEnumerable<ApiResource> GetApiResources()
  {
      return new[]
      {
          new ApiResource("clientservice","Client Service"),
          new ApiResource("productservice","Product Service"),
          new ApiResource("orderservice","Order Service")
      };
  }

  public static IEnumerable<Client> GetClients()
  {
      return new []
      {
         new Client
         {
             ClientId="client.api.service",
             ClientSecrets=new []{new Secret("clientsecret".Sha256())},
             AllowedGrantTypes=GrantTypes.ResourceOwnerPasswordAndClientCredentials,
             AllowedScopes=new []{"clientservice"}
         },
         new Client{
             ClientId="product.api.service",
             ClientSecrets=new []{new Secret("productsecret".Sha256())},
             AllowedGrantTypes=GrantTypes.ResourceOwnerPasswordAndClientCredentials,
             AllowedScopes=new []{"productservice","orderservice"}
         },
         new Client{
             ClientId="order.api.service",
             ClientSecrets=new []{new Secret("ordersecret".Sha256())},
             AllowedGrantTypes=GrantTypes.ResourceOwnerPasswordAndClientCredentials,
             AllowedScopes=new []{"orderservice"}
         }   
      };
  }

  public static IEnumerable<TestUser> GetUsers(){
    return new []{
        new TestUser{SubjectId="110",Username="policeman@110.com",Password="policeman"},
        new TestUser{SubjectId="119",Username="fireman@119.com",Password="fireman"},
        new TestUser{SubjectId="120",Username="doctor@120.com",Password="doctor"}
    };
  }
}

