using NewshoreDataAccess.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace NewshoreBusiness.Services
{
    public class RecruitingApi
    {

        private RestClient _client;

        public RecruitingApi()
        {
            _client = new RestClient("https://recruiting-api.newshore.es/api/flights"); 
        }

        public List<Flight> GetRoutes()
        {
            // send GET request with RestSharp
            
            var request = new RestRequest("1");
            var response = _client.ExecuteGet(request);



            var data = JsonSerializer.Deserialize<List<JsonNode>>(response.Content!)!;

            List<Flight> flights = new List<Flight>();

            data.ForEach(row =>
            {
                Flight flight = new Flight();
                Transport transport = new Transport();

                transport.FlightCarrier = row["flightCarrier"].ToString();
                transport.FlightNumber = row["flightNumber"].ToString();

                flight.Origin = row["departureStation"].ToString();
                flight.Destination = row["arrivalStation"].ToString();
                flight.Price = Convert.ToDouble(row["price"].ToString());

                flight.Transport = transport;

                flights.Add(flight);

            });

            //// deserialize json string response to Product object
            //var options = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //};
            //List<Flight> flight = JsonSerializer.Deserialize<List<Flight>>(response.Content!, options)!;

            return flights;
        }
    }
}
