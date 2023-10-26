using Flight_planner.Validations;
using FlightPlanner.Core.Interfaces;

namespace Flight_planner.Extensions
{
    public static class ValidationCollectionExtensions
    {
        public static void RegisterValidations(this IServiceCollection services)
        {
            services.AddTransient<IValidate, FlightValuesValidator>();
            services.AddTransient<IValidate, AirportValuesValidator>();
            services.AddTransient<IValidate, IncorrectFlightDateValidator>();
            services.AddTransient<IValidate, SameAirportValidator>();
            services.AddTransient<ISearchValidate, SearchAirportsValidator>();
            services.AddTransient<ISearchValidate, SearchValuesValidator>();
        }
    }
}