using Microsoft.Extensions.DependencyInjection;
using RailWayApp.Utility;
using RailWayAppLibrary.Utility;
using RailWayInfrastructureLibrary.Repository.Command;
using RailWayInfrastructureLibrary.Repository.Query;
using RailWayInfrastructureLibrary.Utility;
using RailWayModelLibrary.Repositories.Command;
using RailWayModelLibrary.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayInfrastructureLibrary.Dependency
{
    public static class DLLDependency
    {
        public static IServiceCollection Dependency(this IServiceCollection services)
        {
            services.AddScoped<IBookedTripCommandRepo, BookedTripCommandRepo>();
            services.AddScoped<IPassengerCommandRepo, PassengerCommandRepo>();
            services.AddScoped<IPaymentCommandRepo, PaymenCommandRepo>();
            services.AddScoped<IStaffCommandRepo, StaffCommandRepo>();
            services.AddScoped<IStationCommandRepo, StationCommandRepo>();
            services.AddScoped<ITrackCommandRepo, TrackCommandRepo>();
            services.AddScoped<ITrainCommandRepo,TrainCommandRepo>();

            services.AddScoped<IBookedTripQueryRepo, BookedTripQueryRepo>();
            services.AddScoped<IPassengerQueryRepo, PassengerQueryRepo > ();
            services.AddScoped<IPaymentQueryRepo, PaymentQueryRepo>();
            services.AddScoped<IStaffQueryRepo, StaffQueryRepo>();
            services.AddScoped<IStationQueryRepo, StationQueryRepo>();
            services.AddScoped<ITrackQueryRepo, TrackQueryRepo>();
            services.AddScoped<ITrainQueryRepo, TrainQueryRepo>();
            services.AddScoped< IEscription, Encription>();
            return services;
        }
    }
}
