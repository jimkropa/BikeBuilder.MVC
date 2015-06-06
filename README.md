# Bike Builder

Bicycle inventory and service records for builders and home mechanics.

Plan your projects, make budgets, and optimize trips to the bike shop.

A multi-platform, multi-tenant SAAS application with REST-ful API. Use of tactical [Domain Driven Design](http://en.wikipedia.org/wiki/Domain-driven_design) techniques ([Evans](http://domainlanguage.com/ddd/), [Vernon](https://vaughnvernon.co/?page_id=168), et al.) to model a single bounded context. Details below in object model section.

Originally built for ASP.NET MVC 6 and AngularJS single page app. Future plans include:
* Refactoring the Domain Model into its own NuGet package.
* Refactoring the REST-ful services to standalone Web API in MVC4 so they can run on Linux with [Mono](http://www.mono-project.com/).
* Mobile apps written in [Xamarin](http://xamarin.com).
* Integration of other services to get technical information: Shimano, [VeloBase.com](http://www.velobase.com/), etc.
* Photo library and social media sharing.
* Integration with online commerce for purchases and sales.



## Domain Model

This is a single bounded context in a [Domain Driven Design](http://en.wikipedia.org/wiki/Domain-driven_design) which is robust, the opposite of an "anemic" model:
* Entites and Aggregates have identifiers and life cycles.
* Aggregates include command methods.
* Value Objects make up most of the model.
* Events allow for addition of middleware and extension into other platforms via loose couplings.
* The Application Services mark the boundary of the bounded context, which can be visualized as a hexagonal (a.k.a. "Ports and Adapters") architecture.


### Aggregates

Both **Bicycle** and **Part** implement a contract for manipulation of subordinate parts. The level of detail is up to you. A wheel could be just a wheel, or it could nest subordinate parts such as the hub and the rim, down to the level of the spoke nipple if you're so inclined.

The part is an actual physical item. It might have a serial number.

An instance of Bicycle requires just one Part, the frame. BicyleId is optional for parts until they are installed.


#### PartsAggregate
This is an abstract base class for both Bicycle and Part.

##### Properties
* collection of subordinate Parts
* collection of Images

##### Command Methods
* Install(Part or PartDescriptionId or PartDescription or PartSpecifications)
* Remove(Part)
* Replace(Part, Part or PartDescriptionId or PartDescription or PartSpecifications)
* Service(Part)
* Dispose()


#### Bicycle
Derives from PartsAggregate.

##### Properties
* BicycleId identifier
* FrameId


#### Part

#### Properties
* PartId identifier
* BicycleId

### PartDescription
* PartSpecifications
* collection of TechnicalDocuments
* collection of Images


### Entities

####

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
* OnlineResource
* BicycleCollection (adapted from Tenant in upstream context)
* BicycleServiceTechnician (adapted from User in upstream context)
* 


### Events

* PartAdded
* PartRemoved
* PartDisposed
