# SS_Net_Exercises

## Introduction
This repository is for testing developers' knowledge on C# .NET and MVC.

This application uses the CQRS pattern (commands, validators, queries on a pipeline) and a generic repository pattern:
  - Project Structure
    - __Api__: 
      Is the main project that runs as a web application, it has the configurations, registration of dependencies and controllers implementation.
    - __Application__:
      It covers the CQRS pattern and is where the business logic resides.
    - __Common__: 
      It has the interfaces, base clases and groundwork for the configurations and arquitecture. Normally this is left untouched.
    - __Domain__: 
      Contains the entities definition and other models (or enums) that are used across the different layers.
    - __Persistance__: 
      Holds the entities configurations/mappings and the db context, migrations and seeder.
