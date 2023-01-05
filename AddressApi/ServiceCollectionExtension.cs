using System.Reflection;
using AutoMapper;
using AddressApi.BLL;
using AddressApi.BLL.Adapters;
using AddressApi.BLL.Adapters.Interfaces;
using AddressApi.BLL.Interfaces;
using AddressApi.BLL.Strategies;
using AddressApi.BLL.Strategies.Interfaces;
using AddressApi.DAL;
using AddressApi.DAL.Interfaces;
using AddressApi.DAL.Repositories;
using AddressApi.DAL.Repositories.Interfaces;
using AddressApi.IL;
using AddressApi.IL.Interfaces;
using AddressApi.IL.Clients;
using AddressApi.IL.Clients.Interfaces;

namespace AddressApi
{
    public static class ServiceCollectionExtension
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            /* BLLs */
            services.AddTransient<IAddressBLL, AddressBLL>();

            /* Adapters */
            services.AddTransient<IAddressAdapter, ViaCepAdapter>();

            /* Strategies */
            services.AddTransient<IAddressStrategy, AddressStrategy>();

            /* DALs */
            services.AddTransient<IAddressDAL, AddressDAL>();

            /* Repositories */
            services.AddTransient<IAddressRepository, AddressRepository>();

            /* Integrations */
            services.AddTransient<IViaCepIL, ViaCepIL>();

            /* Clients */
            services.AddTransient<IViaCepClient, ViaCepClient>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config => config.AddMaps(Assembly.GetEntryAssembly()));

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton<IMapper>(mapper);
        }
    }
}