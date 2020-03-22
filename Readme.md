# Exchange rate REST API

Rest API to query exchange rate history

## Getting Started

### Prerequisites

In order for app to work on your local machine, ASP.NET Core Runtime should be installed

```
https://dotnet.microsoft.com/download/dotnet-core/2.1
```
### Calling webservie

Endpoint URL and sample call is given below:

```
http://localhost:51446/api/v1/rates?dates=2018-02-01,2018-02-15,2018-03-01&base=SEK&target=NOK
```

All filtering parameters are passed through the query string.

## Authors

* **Fikret Pašović** - [Phikret](https://github.com/Phikret)

##Sample API JSON response

```
{
    "min": {
        "date": "2018-03-01T00:00:00",
        "rates": {
            "NOK": 0.95468694
        },
        "base": "SEK"
    },
    "max": {
        "date": "2018-02-15T00:00:00",
        "rates": {
            "NOK": 0.9815487
        },
        "base": "SEK"
    },
    "avg": 0.97083950042724609,
    "error": ""
}
```
