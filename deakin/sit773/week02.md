- In the context of software development, requirements are:
  an account of the many details of the problem domain and a description of the key features of the software system.

- Context diagrams are used to show:
  all the external stakeholders, who supply or receive data from the target software system.

- A domain model for a software system is used to capture:
  the varying entities that make up a real-world system and how those entities are related to each other.

- Feasibility analysis is performed to ensure that:
  the varying requirements that have been identified based upon the business problem will ensure a feasible approach to resolving the varying aspects that make up the business problem.

- Project scoping is important because:
  a well-defined project scope helps to ensure that the efforts of the development team are focussed on achieving the set objectives of a project.

---
# Context diagrams
context diagrams show the boundary between the software system and its environment and define the scope of the proposed software system.

proposed 建议的

A context diagram presents an abstract view of a software system showing all the external stakeholders, who supply or receive data from the target software system.

~~~
How do you create a context diagram?
A context diagram is created using a simple block diagram to conceptually demonstrate the proposed software, external stakeholders and other systems that the software interacts with.
~~~
- The proposed software system is represented using a named circle or rounded-rectangle sysmbol; often known as a process symbol, wich represents all functionalities of the proposed software system.
- Each external stakeholder or system that provides data or receives data from the proposed software system is represented using a nameed rectangle.
- The association between the proposed software system and external stakeholders and other system are shown using named arrow lines. Names of the lines show the name of the data that flow into and out of the proposed software.

Everything inside the process symbol is known as the scope of the proposed software system.
External stakeholders and other systems that supply or receive data from the proposed software system are outside the scope of the proposed software.

# creating a domain model
A domain model diagram, also known as a class diagram, is a model of a real-world system. It captures all entities in the domain and how they relate to each other.

Domain model diagrams are used for later reference as well as to communicate the problem domain to the broader project team.

The elements of a domain model are:
- classes
  -  real world entities, which represent physical and non-physical things in the domain; eg customer, booking, account
  -  represented by rectangles, the name at the top of the rectangle is the classes’ name.
- attributes
  -  data associated with entities; eg customer name, booking number.
  -  listed below class names - only the attributes relevant to the business problem are included in a domain model diagram.
- relationships
  - associations between classes, always expressed using verbs; e.g., ‘Customer (class) has Booking (class)’ - in this case the association is ownership (‘has’)
  - represented by lines that connect any two classes and have a label indicating the association.
- cardinality
  - information added to relationships that indicate how many of each entity can be associated with each other, for example, in the relationship ‘Customer has Booking’, a Customer must have at least one Booking and a Booking can only be associated with one Customer
  - indicated in the diagram by annotating the relationship line with a number or range of numbers that specifies this relationship.
- generalisation
  - classes can be specialisations of more general classes, in which case the relationship between them is a generalisation. In the example diagram we can see one generalisation between each of the specialisations, Walk-in and Reservation and the generalisation Booking
  - represented by a relationship line in which the end connecting to the general class is an unfilled triangle.
- constraints
  - indicate conditions that affect entities but cannot be expressed using the graphical elements used in domain model diagrams
  - are textual notes that are associated by entities using dashed lines.
---

# Feasibility analysis
Feasibility analysis is performed to identify potential risks before the project starts and to identify constraints and restrictions on how a problem can be solved.

In fact, constraints are as important as requirements, as they dictate what the system should not do and what the system should not be.

There are several types of feasibility analysis that need to be undertaken, each providing insights into the overall feasibility of the solution. These are:
- economic (financial)
- technical
- operational
- scheduling (resources)
- legal and contractual
- political.


ramifications 后果
## Economic feasibility
Economic feasibility analysis considers the cost and benefit of the proposed system.

Both costs and benefits can be tangible and intangible:

Tangible costs: are direct expenditures by the business that can be measured; eg the purchase of hardware and resources
Intangible costs: are known to negatively affect the business’ finances but cannot be quantified; eg the time and effort involved in training users of the system
Tangible benefits: are measurable and positive financial impacts of the system on the business; eg reduced operational costs, new paid services
Intangible benefits: improve the finances of the business but not in measurable ways; eg improved customer service.

## Break-even analysis
A break-even analysis is performed to estimate whether, and to what extent, a system will provide value to the business when all costs and benefits are considered.

# project scope and requirements
A well-defined project scope determines the objectives of the project and informs the project team of what is included in the project and what is excluded.

Project scope is a statement of everything that will be involved in a specific project. This includes:

the resources involved in the project
the information that will be accumulated during the project
the artifacts the project will deliver
all planned work activities.

The scope of a project is extractable from the requirements of the system, since those requirements ultimately define what the system should be and determine the amount of effort required to produce the system

Because project scope is related to system requirements, project scoping is normally not possible in the planning phase of the project and instead occurs during the early or middle stages of the analysis phase.

# Vision statements
The vision statement captures the essence of the system and acts as a guide to those working on it.

Vision statements need to be brief; they’re meant to explain a potentially complex, multifaceted product from a high level, without getting into details.

a simple technique is presented that can be used to help you write a vision statement. First, define the following about the system:
For (target customer)
Who (statement of need)
The (product name) is a (product category) that (key benefit)
Unlike (primary alternative)
Our product (statement of differentiation)
~~~
For business e-mail users who want to better manage the increasing number of messages they receive when out of the office, the BlackBerry is a mobile e-mail solution that provides a real-time link to their desktop e-mail for sending, reading and responding to important messages. Unlike other mobile e-mail solutions, BlackBerry is wearable, secure, and always connected.
~~~

# pain points

# Problem statement
Using the pain points information the following statement was formulated:

The problem of limited parking spots within the Metro CBD area affects residents and visitors, the result of which is the unavailability of parking spots and the time and effort required for finding available spots. The benefits of the proposed solution is the ability of drivers to reserve parking spots for their vehicles before arriving at the location, eliminating the time it takes to find parking.

# domain 
## Creating the Domain Model
1. determining the data each entity contains
2. analysing the relationships between entities
3. investigating how many entities can be related to each other (cardinality)

The Software Development Lifecycle (SDLC) is composed of a series of phases, each with its own objectives and outcomes. The main route of the SDLC includes planning, analysis, design, implementation, and maintenance.
When in the planning phase,


