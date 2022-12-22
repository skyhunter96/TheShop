# TheShop

- Shop.WebApi – for displaying and buying articles
- Vendor.WebApi – acts like third party provider mock

In order to simulate shop & vendor API as "third party", run the solution in two different VS instances, with one using Shop.WebApi & another one using Vendor.WebApi. 
Then try to get article through shop api, if not found it will try to fetch from vendor.
