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

API Call example with 50 dates

```
http://localhost:51446/api/v1/rates?dates=2018-02-01,2018-09-15,2018-03-16,2018-03-11,2018-10-15,2018-03-15,2019-05-21,2018-11-15,2018-03-14,2018-07-01,2018-12-15,2018-03-13,2018-08-01,2019-01-15,2018-03-12,2018-09-01,2019-02-15,2018-03-11,2018-10-01,2019-03-15,2018-03-10,2018-11-01,2019-04-15,2018-03-09,2018-12-01,2019-05-15,2018-03-08,2019-06-02,2019-06-15,2019-03-07,2019-07-03,2019-07-15,2019-03-06,2019-08-04,2019-08-15,2019-03-05,2019-09-05,2019-09-15,2019-03-04,2019-10-06,2019-10-15,2019-03-03,2019-11-07,2019-11-15,2019-03-02,2019-12-08,2019-12-15,2020-02-01,2020-03-01,2020-03-15&base=SEK&target=NOK
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


