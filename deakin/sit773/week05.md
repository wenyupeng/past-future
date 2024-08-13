# Use cases
A use case describes a set of possible sequences an actor goes through while interacting with the system to achieve a specific and singular goal.
In contrast to usage scenarios, use cases focus less on the needs and motivations of users and more on how the system will be used.
By refining use cases, the logic of the low-level tasks the system must perform can be determined.

A use case is used to:
- identify functional requirements by describing how an actor will typically interact with the software system
- organise the requirements into a clear format.
An actor is:
- a role that a user plays when interacting with the system
- not necessarily human, may represent an external system or device.
The goal of a use case should always have a significance to the actor, as a use case if generally initiated by an 
  actor and when possible, should only satisfy one functional requirement.

## set of use cases
A software system usually has more than one actor. Defining a set of use cases is important as it:
- helps describe all of the actors and all of their goals
- enables us to capture all of the system’s functional requirements at a high-level.


## hidden requirements
Often the use case modelling technique also exposes ‘hidden’ functional requirements that are not obvious from the user’s goal but become apparent as we create the use case for that goal.

## document use cases
Use cases are documented using:
- use case descriptions
- use case diagrams.

# use case diagrams
Use case diagrams provide an overview of the system’s composition.

A use case diagram is a simple graphical representation of the software system’s various use cases and their relationship to each other and the system’s actors.

A use case diagram is an especially effective tool to provide an overview of the system’s composition to stakeholders, as it doesn’t disclose details about a use case beyond its name and relationships.

## relationship between use cases
The two types of relationships that can exist between use cases are <<include>> or <<extend>>.

In each relationship, there is a ‘base use case’ which the connected use case either ‘includes’ or ‘extends’. E.g., in the above figure the ‘Edit menu’ use case is an extension of the ‘View menu’ use case.

### internal relationship
The purpose of the <<include>> relationship is to show that the behaviour of the included use case is part of the base use case.

### external relationship
The purpose of the <<extend>> relationship is to add more functionality to the base use case.

# use case descriptions
Simple use case descriptions are prepared using use case names, actors and associations.

Typically, use case descriptions are written at three separate levels of detail: simple, expanded, and detailed.

Use case descriptions are a formal approach for documenting use cases. In this step, you will learn about simple use case descriptions. We will explore expanded and detailed use case descriptions in the following steps.

## why are use case description needed
To ensure the client’s needs are satisfied in requirements analysis and modelling, you need to supply details about the system’s behaviour, and how the system responds to requests of its users under various conditions.

Use case diagrams are not detailed enough for this purpose. They are prepared using use case names, actors and associations, and only show system functionality by using the name of the use cases.

A use case description is one of the tools that can be used to provide further details on the interactions between the system and the users, under specific conditions.

## write use case description
A simple use case description is written in an informal tone with a narrative style.

It’s a paragraph that briefly describes the actor’s interactions with the system, capturing what the actor does or intends to do to achieve its goal.

An example:
~~~
Use case: Create an order via online

Actor: Customer

Customer logs on to the shopping web page. Customer selects the purchase menu to go to the new order form. Customer selects a product from the catalogue, specifies quantity and details (brand, size etc). System and customer add items to the shopping cart. Customer provides shipping address and selects their preferred payment method. System verifies the payment, creates the order transaction and finalises the order.
~~~

## when to use use case description
A simple use case description can be used when the target system to be developed is small, and well understood to both stakeholders and the development team.


# detailed use case descriptions
Detailed use case descriptions are necessary when there is a significant number of exception conditions or decision points.

A detailed use case description helps analysts understand a business process thoroughly and define how the system must support that process.

## how to write detailed use case description
A detailed use case description has three main sections.

### Top section
The top section includes following items:

|                   |                                                                                                                                                                                                                                                       |
|-------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Use case name     | The name of use case that corresponds to the use case diagram and represents the goal that client wants to achieve                                                                                                                                    |
| Scenario          | The scenario name related with an actor, a use case can have more than one scenario                                                                                                                                                                   |
| Triggering event  | This is the event that initiated the execution of the use case. This can be an action of an actor or a time point which has been reached.                                                                                                             |
| Brief description | This is a brief description of a use case that was prepared early for a simple use case description and repeated here.                                                                                                                                |
| Primary actor     | This is the primary stakeholder who initiated the use case and gets direct benefits through the execution of the use case.                                                                                                                            |
| Related use cases | This mentions the use cases those are related with this use case and the way they are related e.g. «include», «extend» relationships                                                                                                                  |
| Stakeholders      | These are the people (other than specific actors) who do not invoke the use case. They have interest in results produced through the execution of this use case                                                                                       |
| Precondition      | A set of constraints/ criteria that must be true before this use case can be initiated. This can be another use case that must be previously executed. Or it identifies the state of the system that must exist before this use case can be executed. | 
| Post condition    | A set of constraints/ criteria that must be true upon completion of the execution of this use case can be initiated. Or it identifies the state of the system that must exist after this use case has been successfully executed                      |

### middle section
The middle section includes the typical course of events which is the normal sequence of activities performed by the actor and the system.

This describes the interaction of the actor with the system and corresponding response from the system.

This section is written in a two column format:
- the left side lists the actions of the actor
- the right side lists the responses of the system.

### last section
The last section of a detailed use case description describes exception conditions.

This is similar to exception descriptions in expanded use case descriptions. The number of each step in the exception condition section matches the number of the corresponding step in the main flow of activities in the middle section.

# activity diagram
Activity diagrams are a visual notation for capturing the steps involved in a business or computational process.

