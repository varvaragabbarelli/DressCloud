﻿using Xunit;
using MetaWeatherAPI;
using BusinessLogic.Forecast;
using BusinessLogic.Http;
using Moq;

namespace Tests.MetaWeatherAPI
{
    public class MetaWeatherAPITest
    {

      const string MOCK_API_RESPONSE = "{\"consolidated_weather\":[{\"id\":5708699624538112,\"weather_state_name\":\"Light Cloud\",\"weather_state_abbr\":\"lc\",\"wind_direction_compass\":\"W\",\"created\":\"2018-03-26T17:33:02.380950Z\",\"applicable_date\":\"2018-03-26\",\"min_temp\":5.5,\"max_temp\":12.054,\"the_temp\":11.98,\"wind_speed\":4.9854458455086297,\"wind_direction\":269.9395315351901,\"air_pressure\":1020.9400000000001,\"humidity\":61,\"visibility\":10.610534478644714,\"predictability\":70},{\"id\":6314184786575360,\"weather_state_name\":\"Light Rain\",\"weather_state_abbr\":\"lr\",\"wind_direction_compass\":\"WSW\",\"created\":\"2018-03-26T17:33:03.524530Z\",\"applicable_date\":\"2018-03-27\",\"min_temp\":5.9859999999999998,\"max_temp\":12.122,\"the_temp\":12.135,\"wind_speed\":9.3485856730692767,\"wind_direction\":247.59585584855844,\"air_pressure\":1005.4400000000001,\"humidity\":86,\"visibility\":8.0548347649725596,\"predictability\":75},{\"id\":4827697746280448,\"weather_state_name\":\"Light Rain\",\"weather_state_abbr\":\"lr\",\"wind_direction_compass\":\"WNW\",\"created\":\"2018-03-26T17:33:03.721260Z\",\"applicable_date\":\"2018-03-28\",\"min_temp\":3.7299999999999995,\"max_temp\":9.2240000000000002,\"the_temp\":7.6749999999999998,\"wind_speed\":10.386097205767916,\"wind_direction\":289.3326216095569,\"air_pressure\":1003.8,\"humidity\":77,\"visibility\":5.7657032927702216,\"predictability\":75},{\"id\":6390936925896704,\"weather_state_name\":\"Showers\",\"weather_state_abbr\":\"s\",\"wind_direction_compass\":\"SSW\",\"created\":\"2018-03-26T17:33:03.822090Z\",\"applicable_date\":\"2018-03-29\",\"min_temp\":2.8339999999999996,\"max_temp\":9.8919999999999995,\"the_temp\":9.2349999999999994,\"wind_speed\":8.5589101216272976,\"wind_direction\":200.57523698432979,\"air_pressure\":1006.225,\"humidity\":70,\"visibility\":12.486454108009227,\"predictability\":73},{\"id\":4664590927396864,\"weather_state_name\":\"Light Rain\",\"weather_state_abbr\":\"lr\",\"wind_direction_compass\":\"SSE\",\"created\":\"2018-03-26T17:33:02.659830Z\",\"applicable_date\":\"2018-03-30\",\"min_temp\":4.2000000000000002,\"max_temp\":9.370000000000001,\"the_temp\":8.8249999999999993,\"wind_speed\":9.4719952618865815,\"wind_direction\":159.74166064798547,\"air_pressure\":997.41499999999996,\"humidity\":77,\"visibility\":9.7033325379782074,\"predictability\":75},{\"id\":4791920601595904,\"weather_state_name\":\"Light Rain\",\"weather_state_abbr\":\"lr\",\"wind_direction_compass\":\"SSW\",\"created\":\"2018-03-26T17:33:05.662350Z\",\"applicable_date\":\"2018-03-31\",\"min_temp\":3.9939999999999998,\"max_temp\":9.7039999999999988,\"the_temp\":8.9800000000000004,\"wind_speed\":7.6084357353058136,\"wind_direction\":191.48262059936562,\"air_pressure\":1001.01,\"humidity\":82,\"visibility\":9.3205678835600096,\"predictability\":75}],\"time\":\"2018-03-26T20:59:39.555600+01:00\",\"sun_rise\":\"2018-03-26T06:49:51.386832+01:00\",\"sun_set\":\"2018-03-26T19:23:34.502762+01:00\",\"timezone_name\":\"LMT\",\"parent\":{\"title\":\"England\",\"location_type\":\"Region / State / Province\",\"woeid\":24554868,\"latt_long\":\"52.883560,-1.974060\"},\"sources\":[{\"title\":\"BBC\",\"slug\":\"bbc\",\"url\":\"http://www.bbc.co.uk/weather/\",\"crawl_rate\":180},{\"title\":\"Forecast.io\",\"slug\":\"forecast-io\",\"url\":\"http://forecast.io/\",\"crawl_rate\":480},{\"title\":\"HAMweather\",\"slug\":\"hamweather\",\"url\":\"http://www.hamweather.com/\",\"crawl_rate\":360},{\"title\":\"Met Office\",\"slug\":\"met-office\",\"url\":\"http://www.metoffice.gov.uk/\",\"crawl_rate\":180},{\"title\":\"OpenWeatherMap\",\"slug\":\"openweathermap\",\"url\":\"http://openweathermap.org/\",\"crawl_rate\":360},{\"title\":\"Weather Underground\",\"slug\":\"wunderground\",\"url\":\"https://www.wunderground.com/?apiref=fc30dc3cd224e19b\",\"crawl_rate\":720},{\"title\":\"World Weather Online\",\"slug\":\"world-weather-online\",\"url\":\"http://www.worldweatheronline.com/\",\"crawl_rate\":360},{\"title\":\"Yahoo\",\"slug\":\"yahoo\",\"url\":\"http://weather.yahoo.com/\",\"crawl_rate\":180}],\"title\":\"London\",\"location_type\":\"City\",\"woeid\":44418,\"latt_long\":\"51.506321,-0.12714\",\"timezone\":\"Europe/London\"}";
      [Fact]  
      public void GetWeatherForecastInPrague()
      {
            Mock<IHttpClient> mockClient = new Mock<IHttpClient>();
            mockClient.Setup(m => m.GetStringAsync("https://www.metaweather.com/api/location/search/?query=prague")).Returns("[{\"title\":\"Prague\",\"location_type\":\"City\",\"woeid\":796597,\"latt_long\":\"50.079079, 14.433220\"}]");
            mockClient.Setup(m => m.GetStringAsync("https://www.metaweather.com/api/location/796597")).Returns(MOCK_API_RESPONSE);
            MetaWeatherForecast sut = new MetaWeatherForecast(mockClient.Object);
            Forecast forecast;
            forecast = sut.GetWeatherForecast("prague");
            Assert.Equal("Light Cloud", forecast.Condition);
            Assert.Equal(11.98, forecast.Temperature);



      }
    }
}
