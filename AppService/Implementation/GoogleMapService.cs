using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.AddressValidation.Request;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using GoogleApi.Entities.Maps.Routes.Common;
using GoogleApi.Entities.Maps.Routes.Directions.Request;
using GoogleApi.Entities.Maps.Routes.Matrix.Request;
using GoogleApi.Entities.Search.Common;
using Microsoft.Extensions.Options;
using Models.ConfigModels;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace AppService.Implementation
{
    public class GoogleMapService : IGoogleMapService
    {
        private readonly GoogleMaps.Routes.RoutesDirectionsApi _routesApi;
        private readonly GoogleMaps.Geocode.AddressGeocodeApi _addressGeocodeApi;
        private readonly GoogleConfig _googleConfig;
        private readonly CenterGeocode _centerGeocode;
        public GoogleMapService(GoogleMaps.Routes.RoutesDirectionsApi routesApi, GoogleMaps.Geocode.AddressGeocodeApi addressGeocodeApi, GoogleMaps.AddressValidationApi addressValidationApi, IOptions<GoogleConfig> googleConfig, IOptions<CenterGeocode> centerGeocode)
        {
            _routesApi = routesApi;
            _addressGeocodeApi = addressGeocodeApi;
            _googleConfig = googleConfig.Value;
            _centerGeocode = centerGeocode.Value;

        }
        private async Task<Geometry> TestAddressGeoCode(string address)
        {
            var request = new AddressGeocodeRequest()
            {
                Address = address,
                Key = _googleConfig.API_KEY,
            };
            var response = await _addressGeocodeApi.QueryAsync(request);
            var geometry = response.Results.First().Geometry;
            return geometry;
        }
        private RouteWayPoint GetRouteWaypoint(double latitude, double longitude)
        {
            return new GoogleApi.Entities.Maps.Routes.Common.RouteWayPoint()
            {
                Location = new GoogleApi.Entities.Maps.Routes.Common.RouteLocation()
                {
                    LatLng = new GoogleApi.Entities.Maps.Common.LatLng()
                    {
                        Latitude = latitude,
                        Longitude = longitude
                    },
                },
            };
        }
        public async Task<float> CalculateDistance(string destination)
        {
            try
            {
                var dest_geometry = await TestAddressGeoCode(destination);
                var origin = GetRouteWaypoint(_centerGeocode.Latitude, _centerGeocode.Longitude);
                var waypoint = GetRouteWaypoint(dest_geometry.Location.Latitude, dest_geometry.Location.Longitude);
                RoutesDirectionsRequest request = new RoutesDirectionsRequest()
                {
                    Units = GoogleApi.Entities.Maps.Common.Enums.Units.Imperial,
                    Destination = waypoint,
                    Origin = origin,
                    TravelMode = GoogleApi.Entities.Maps.Routes.Common.Enums.RouteTravelMode.TwoWheeler,
                    RoutingPreference = GoogleApi.Entities.Maps.Routes.Common.Enums.RoutingPreference.TrafficAware,
                    Key = _googleConfig.API_KEY,
                };
                var response = await _routesApi.QueryAsync(request);
                var route = response.Routes.FirstOrDefault();
                if(route == null)
                {
                    throw new Exception("Provided address location is invalid!");
                } else
                {
                    var meters = route.DistanceMeters;
                    
                    float kilometers = (float)meters / 1000.0f;
                    return kilometers;
                }
                
            } catch {
                throw;
            }
            
        }
    }
}
