# WebTrade
### Mock API

*The API was deployed with `Azure App Services` (F1: Free tier) and `Github Actions` for continuous integration.

I used `GrapqhQL` with `HotChocolate`, which comes with an UI for navigating the schema (https://webtrade.azurewebsites.net/api/1.0/)

For storage I simply saved the values in a static variable. To ensure data integrity, all data that comes in and out of the collections
is cloned with serialization/deserialization. This is not performant, but it was the fastest thing I could come up with. (I tried 
making all properties in entities `init`, but it became awkward to update the data, had to keep instantiating new objects)

To simulate database operations, I added a delay of random timelength in each method of the data repository. 

`GetEntity` method in `WebTradeRepository` was added to eliminate some code duplication but it may looks a bit weird. The point was to
use it multiple times in the same repository method without multiple delays. (why not remove the delays from repository, make it synchronous, 
and add them someplace else? Well, the repository is also decorated with `CacheRepository` which really does have async methods, so I wanted
to keep the signature with Task<...>, since both `CacheRepository` and `WebTradeRepository` implement the same `ICacheRepository` methods)
I also didn't want to spend too much time on this particular problem. If I was using `EntityFramework` for instance I would add generic methods 
for `Get`/`Add`/`Update`/`Delete`.

Lastly, I added jsons for importing in `Postman` (can be done directly in browser https://www.postman.com/) for a `collection` and an `environment`, to 
test the API. It's probably easier with the UI, but I used Postman out of habit.