﻿using Flight_planner.Models;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Services
{
    public interface IFlightService : IEntityService<Flight>
    {
        Flight? GetFullFlightById(int id);

        bool Exists(Flight flight);

        PageResult? SearchFlights(Search search);
    }
}