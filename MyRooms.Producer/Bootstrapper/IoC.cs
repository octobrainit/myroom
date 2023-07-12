using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRooms.Producer.Adapters.Database;
using MyRooms.Producer.UseCase.GetHotelDetails;
using MyRooms.Producer.UseCase.GetHotels;
using MySqlConnector;

namespace MyRooms.Producer.Bootstrapper
{
    public static class IoC
    {
        public static IServiceCollection AddProducer(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetSection("ConsumerConnectionString").Get<ProducerConnectionString>();

            if (connection is not null)
                services.AddTransient(x => new MySqlConnection(connection.Database));

            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IGetHotelsUseCase, GetHotelsUseCase>(); 
            services.AddTransient<IGetHotelDetailsUseCase, GetHotelDetailsUseCase>();

            return services;
        }
    }
}
