# Hotel

## Testing
Rather than sticking to the concept of pure unit tests, I have found it more benifitial to write integration tests with the layer that communicates directly with the database. This allows me to verify the database and corresponding layer is setup correclty. Thus each test project will have two folders for each type of test: Unit and Integration.

