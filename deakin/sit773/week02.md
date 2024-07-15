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
