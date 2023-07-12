using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRooms.Consumer.Adapters.Database;
using MyRooms.Consumer.UseCase.CreateHotel;
using MySqlConnector;

namespace MyRooms.Consumer.Bootstrapper
{
    public static class IoC
    {
        public static IServiceCollection AddConsumer(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetSection("ConsumerConnectionString").Get<ConsumerConnectionString>();

            if (connection is not null)
                services.AddTransient(x => new MySqlConnection(connection.Database));
            
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<ICreateHotelUseCase, CreateHotelUseCase>();
            
            return services;
        }
    }
}
