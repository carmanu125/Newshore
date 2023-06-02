using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewshoreBusiness.Services;
using NewshoreDataAccess.Data;
using NewshoreDataAccess.Models;

namespace NewshoreApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {

        [HttpGet(Name = "GetRoutes")]
        public Journey Get(string origin, string destination)
        {

            DataBase db = new DataBase();
            Journey journey = new Journey();


            //Confirma si hay datos almacenados para esa ruta
            journey = db.GetRoute();
            //if (journey == null)
            //{
                //No se encontraro rutas, se procede a calcularla


                RecruitingApi recruitingApi = new RecruitingApi();

                List<Flight> flights = recruitingApi.GetRoutes();
                List<Flight> flights_route = new List<Flight>();


                flights_route = flights.Where(flight => flight.Origin == origin && flight.Destination == destination).ToList();

                if (flights_route.Count < 1)
                {

                    List<Flight> flights_origin = flights.Where(flight => flight.Origin == origin).ToList();
                    List<Flight> flights_destination = flights.Where(flight => flight.Destination == destination).ToList();



                    bool found = false;

                    double price = 0;

                    // una parada en la ruta
                    foreach (Flight flight in flights_origin)
                    {

                        foreach (Flight flight_destination in flights_destination)
                        {
                            if (flight.Destination == flight_destination.Origin)
                            {
                                flights_route.Add(flight);
                                flights_route.Add(flight_destination);
                                found = true;

                                price = flight.Price + flight_destination.Price;

                                break;
                            }
                        }

                        //List<Flight> next_flights = flights.Where(flight => flight.Origin == origin).ToList();
                    }

                    // dos parada en la ruta

                    if (flights_route.Count < 1)
                    {
                        foreach (Flight flight1 in flights_origin)
                        {
                            List<Flight> next_flight = flights.Where(flight => flight.Origin == flight1.Destination).ToList();
                            foreach (Flight flight_next in next_flight)
                            {
                                foreach (Flight flight_destination in flights_destination)
                                {
                                    if (flight_next.Destination == flight_destination.Origin)
                                    {
                                        flights_route.Add(flight1);
                                        flights_route.Add(flight_next);
                                        flights_route.Add(flight_destination);
                                        found = true;

                                        price = flight1.Price + flight_destination.Price + flight_next.Price;

                                        break;
                                    }
                                }
                            }
                        }
                    }


                    journey.Origin = origin;
                    journey.Destination = destination;
                    journey.Flights = flights_route;
                    journey.Price = price;

                }
                else
                {
                    journey.Origin = origin;
                    journey.Destination = destination;
                    journey.Flights = flights_route;
                    journey.Price = flights_route[0].Price;
                }
            //}



            //Envia los datos para confirmar en la DB si es un dato nuevo y proceder a almacenarlos
            //db.SaveRoute(journey);



            return journey;
        }
    }
}
