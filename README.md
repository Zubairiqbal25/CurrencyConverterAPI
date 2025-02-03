# Currency Exchange API

This API provides currency conversion and exchange rate information using the Frankfurter API.

## How to Run
1. Clone the repository.
2. Navigate to the project directory: `cd CurrencyExchangeAPI`.
3. Run the API: `dotnet run`.
4. Access the API at `http://localhost:7124`.

## Endpoints
- `GET /api/Currency/rates/{baseCurrency}`: Get latest exchange rates.
- `POST /api/Currency/convert`: Convert amounts between currencies (excludes  "TRY", "PLN", "THB", "MXN", "AED", "PKR").
- `GET /api/Currency/history`: Get historical rates with pagination.

## Assumptions
- The Frankfurter API is used as the data source.
- Pagination is implemented for historical rates.

## Enhancements
- Add caching to reduce API calls.
- Implement rate limiting to handle large requests.