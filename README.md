GeoCodeLamda
In this assignment:
a simple solution using C# .NET Core, solution 
is issuing a GET request to Google Geocode API and using an AWS Lambda Function and store its 
results in AWS DynamoDB database as cache for 30-days, such that subsequent requests are not 
routed through Google API but rather fetched from this cache.  

1. Google Cloud, specifically activate the geocoding service. 
2. AWS, specifically lambda and DynamoDB
   
Functional Requirements:
1. lambda function utilizing a GET function with US address parameters and outputs the 
google full response, not just the geocode. For example:
 https://my-lambda-function-on/aws/Geocode?address=70 Vanderbilt Ave, New York, NY 10017, United States 
2. lambda function checks whether the response is cache and if so, fetch it from the 
dynamo db catch for up to 30 days. After 30 days it sends the request to google 
regardless of cache.  
