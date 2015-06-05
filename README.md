# Bike Builder

Bicycle inventory and service records for builders and home mechanics.

Plan your projects, make budgets, and optimize trips to the bike shop.

A multi-platform, multi-tenant SAAS application with REST-ful API. Use of tactical [Domain Driven Design](http://en.wikipedia.org/wiki/Domain-driven_design) techniques ([Evans](http://domainlanguage.com/ddd/), [Vernon](https://vaughnvernon.co/?page_id=168), et al.) to model a single bounded context. Details below in object model section.

Originally built for ASP.NET MVC 6 and AngularJS single page app. Future plans include:
* Refactor Domain Model into its own NuGet package.
* Refactor APIs to standalone Web API in MVC4 so they can run in Linux with mono.
* Access via Xamarin app for mobile devices.
* Integration of other services to get technical information: Shimano, [Velobase](), etc.
* Photo library
* social media sharing



## Domain Model

This is a single bounded context in a [Domain Driven Design](http://en.wikipedia.org/wiki/Domain-driven_design) which is not anemic. Entites and Aggregates have identifiers and life cycles, Aggregates include command methods, Value Objects make up most of the model, and Events allow for addition of middleware and extension into other platforms via loose couplings.


### Aggregates

Both **Bicycle** and **Part** implement a contract for manipulation of subordinate parts. The level of detail is up to you. A wheel could be just a wheel, or it could nest subordinate parts down to the level of the spoke nipple.

The part is an actual physical item. It might have a serial number.

An instance of Bicycle requires just one Part, the frame. BicyleId is optional for parts until they are installed.

#### PartsAggregate

This is an abstract base class for both Bicycle and Part.

##### Properties
* collection of Parts
* collection of Images

#### Command Methods
* Install(Part or PartDescriptionId or PartDescription or PartSpecifications)
* Remove(Part)
* Replace(Part, Part or PartDescriptionId or PartDescription or PartSpecifications)
* Service(Part)
* Dispose()

#### Bicycle

##### Properties
* FrameId

### Part

#### Properties
* BicycleId

### PartDescription
* PartSpecifications
* collection of TechnicalDocuments
* collection of Images


### Entities

* TechnicalDocument
* Image


### Standard Types

These are Entities described as Standard Types, for meta-programming the system as new kinds of bike parts are introduced. We'll start with a hard-coded set, loaded into

* BicycleParts
* BicyclePartSpecifications
* BicyclePartSpecificationValueConstraints
* Units


### Domain Services

#### PartsStock
* Need()
* Acquire()

#### PartsCatalog
* Add(PartDescription)
* Clone(PartDescription)
* Remove(PartDescription)
* Update(PartDescription)
* Update(PartDescriptionId,BicyclePartSpecification,

#### PartsMetaProgramming
* CreateStandardTypeEntities()


### Values

Each PartSpecification value is essentially a key-value pair. The key is a specification such as "frame spacing" and the value may include a "units" component.

The PartType consists of a list of which specifications go together to describe a type of Part.

* PartSpecifications
* PartType
* PartSpecification
* ServiceNote
* Purchase


### Events

* PartAdded
* PartRemoved
* PartDisposed
