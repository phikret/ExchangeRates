# Exchange rate REST API

Rest API to query exchange rate history

## Getting Started

### Prerequisites

In order for app to work on your local machine, ASP.NET Core Runtime should be installed

```
https://dotnet.microsoft.com/download/dotnet-core/2.1
```
### Calling webservice

Endpoint URL and sample call is given below:

```
http://localhost:51446/api/v1/rates?dates=2018-02-01,2018-02-15,2018-03-01&base=SEK&target=NOK
```

All filtering parameters are passed through the query string.

## Sample API JSON response

```
{
    "min": {
        "date": "2019-05-21",
        "currency": "NOK",
        "rate": 0.908764362
    },
    "max": {
        "date": "2018-02-01",
        "currency": "NOK",
        "rate": 0.9762828
    },
    "avg": 0.93211507797241211,
    "error": ""
}
```

## Authors

* **Fikret Pašović** - [Phikret](https://github.com/Phikret)


