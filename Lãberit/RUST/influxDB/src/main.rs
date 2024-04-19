use chrono::{DateTime, Utc};
use influxdb::{Client, Error, InfluxDbWriteable, ReadQuery, Timestamp};

#[tokio::main]
// or #[async_std::main] if you prefer
async fn main() -> Result<(), Error> {
    // Connect to db `test` on `http://localhost:8086`
    let client = Client::new("http://localhost:8086", "MACDB");

    #[derive(InfluxDbWriteable)]
    struct WeatherReading {
        time: DateTime<Utc>,
        humidity: i32,
        #[influxdb(tag)]
        wind_direction: String,
    }

    // Let's write some data into a measurement called `weather`
    let weather_readings = vec![
        WeatherReading {
            time: Timestamp::Hours(1).into(),
            humidity: 30,
            wind_direction: String::from("north"),
        }
        .into_query("weather"),
        WeatherReading {
            time: Timestamp::Hours(2).into(),
            humidity: 40,
            wind_direction: String::from("west"),
        }
        .into_query("weather"),
    ];

    client.query(weather_readings).await?;

    // Let's see if the data we wrote is there
    let read_query = ReadQuery::new("SELECT * FROM weather");

    let read_result = client.query(read_query).await?;
    println!("{}", read_result);
    Ok(())
}