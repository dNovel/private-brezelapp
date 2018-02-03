# Brezelapp API

A private project to test out some web technology. This is mainly written with dotnet core technology and designed to run platform indepentend.

## Description

This is going to be a web-api that is capable of keeping track of very good brezel sellers. Because - who doesn't like a really good Brezel?!

## Functionality

* Post new store to the database
* Update an existing store in the database
* Delete an existing store from the database
* Get a list of stores
* Filter for stores in a specific geolocation area
* Filter for stores with a specific brezel rating
* Filter for stores with a specifc brezel price in their offerings

* Add new brezel to the database
* Update an existing brezel in the database
* Delete an existing brezel from the database

## Design

The api is capable of storing the following models with the corresponding properties to an sql database using entityFramework core:

* Store
    * Name of the store (string)
    * Brezel (List:Brezel)
    * latitude (double)
    * longitude (double)
* Brezel
    * Price (float)
    * Rating (integer between 1 and 5)

## Available endpoints
These endpoints will be available in the api. There will be an api documentation available later.

### Stores
Post a new store to the db
...url/Stores

Put an update to a store
...url/Stores{id}

Get a specific store by id
...url/Stores/{id}

Get a list of stores with the given offset and limit
...url/Stores?offset=0&limit=20

Get a list of stores for a specific geo location including a radius in meter
...url/Stores?lat=0&long=0&radius=1000

Get a list of stores with a minimal brezel rating
...url/Stores?minrating=0&maxrating=5

Delete a store from the database
...url/Stores/{id}

### Brezels
Post a new brezel to the database
...url/Brezels

Put an update to a brezel
...url/Brezels/{id}

Get a brezel by id
...url/Brezels/{id}

Get a list of brezels with the given offset and limit
...url/Brezels?offset=0&limit=20

Delete a brezel from the database
...url/Brezels/{id}