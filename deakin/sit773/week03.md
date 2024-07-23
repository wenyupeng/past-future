# information system boundaries
The inputs and outputs of the system indicate that data is passing from the environment to the system, crossing the boundary between them.

An important aspect of defining and understanding systems, including information systems, is to understand the boundaries between them and the rest of the world.

This includes understanding what is ‘inside’ of a system and what is ‘outside’, as well as what system interactions require participation from users of the system.

## The system environment
All information systems are embedded into a target real-word environment and are subject to 
the constraints of that environment. The actions of the system must adhere to those constraints.
The environment includes details such as the physical environment in which the system will be deployed and the local 
laws that apply to the behaviour of the system, such as tax laws and safety laws.

## the manual aspect of information systems
Many of the actions supported by information systems require input from users in order to be performed.

The set of interactions in the information system that require input to function defines the manual part of the system.

## the automated aspect of information systems
By building systems using hardware and software, many data storage and transformation actions can be automated.

The automated aspect of an information system is the set of actions that the system is able to perform without the participation of users.

# identifying boundaries
Defining system boundaries is related to the technical activity of scoping, whereby you explicitly define what is within the extent, or range, of the system; that is, what the system encompasses.

# Functional requirements
The functional requirements of a system are the set of actions that the system must be able to perform to fulfil its intended role.

Think of them as the functions that the system is required to perform. Each function of the system consists of three aspects:
- a set of inputs, which define the data the function requires to perform its behaviour
- a behaviour, which defines what the function does
- an output, which specifies what data is returned by the function.

Functional requirements are shaped by the kind of work that a system needs to do or assist its users to do. This means there is much variety in the kinds of functional requirements typically encountered in requirements analysis.

## identifying functional requirements

## understanding business processes
Businesses define processes for how they respond to events that occur in the environment;
## discussions with users
Functional requirements are behaviour-driven, they arise from behaviour that the system’s expected users need or wish the system to perform.

Users of systems that a new system is intended to replace, can provide valuable insight into the behaviours of the current system, which can inform the discovery of functions required in the replacement.

Such needs and wishes can be identified by talking to the expected users of the system, whether informally, in an interview context or by applying a questionnaire.
## modelling activities
Insights into the needs of future users of a system can be understood by modelling its users and how they interact with the system.

In fact, new functional requirements can be identified as hypothetical users encounter missing functionality of the hypothetical system.

# quality requirements
Quality requirements include accessibility, availability, efficiency, privacy, reliability, scalability and usability.

Quality requirements, also referred to as non-functional requirements, are a set of qualities that must be exhibited by the system, such as performance and efficiency.

Often quality requirements specify the characteristics a behaviour of the system must have in order for that behaviour to be useful. The effectiveness of many systems depends not only on what they can do, but also how they operate.

For example, consider a level crossing system that activates traffic signals and drops a boom gate when it detects the arrival of a train. The behaviours of the system include:

detecting trains
activating traffic signals
operating the boom gates.

However, the system must be able to consistently and quickly perform these actions to prevent accidents. Thus, to fulfil its intended role, the example system must exhibit the qualities of:

performance
reliability.

## common quality requirements
There are many qualities a system may require to address a particular problem. Some examples are:
- performance
- security
- fault tolerance
- availability
- reliability
- extensibility
- maintainability
- robustness
- usability.

## identifying quality requirements
Quality requirements are identified by:

interviewing users, either future users of the system or users of an existing system that the new system will replace
studying business processes
performing modelling activities.

Understanding the domain and the client business’ processes can provide substantial insight into the system’s quality requirements. Often the processes of a business are shaped by the domain in which it operates.

Sustainable: 可持续的

# Business requirements
Business requirements can be identified by interviewing the executives of the business.

Business requirements are system requirements that are related to the high-level operation and objectives of the business.

Consider the following:

Business processes: What are the processes to be automated? Note that the business requirement identifies which processes the system will automate, not what the system will do to automate them (the latter are functional requirements).
Expected outcomes: What is the business intending to achieve with the system? For example, if the expected solution is a specific type of system from many available types, then this must be reflected in the system requirements. For example, if the business expects an email-based system and not just any type of communication system.
Business objectives: What are the business objectives for the system? If the business is trying to promote a specific technology, for example, then a business requirement of the system may be to use that technology.

## identifying business requirements
Often such high-level requirements are identified early in the analysis process as the business explains its rationale for seeking a new system.

Business requirements can also be identified by interviewing the executives of the business to obtain more information.

Time constraints, economic constraints and technical constraints can also influence the way in which requirements analysis is performed and which requirements are identified as necessary for the system.

# documenting requirements
Vague requirements can cause much wasted effort if they are misinterpreted.

Requirements must be clearly documented by the system analyst so the rest of the team can interpret them correctly.

Vague requirements can cause much wasted effort as they are misinterpreted throughout successive phases of the project, resulting in features, or even complete systems, that fail to address the actual problem.

## phrasing requirements
The language used to describe requirements determines how these will be understood, therefore analysts must be very careful with their use of language in requirements documentation.

Requirements are generally described using the following format:

The [system] must/shall [perform behaviour] when/unless/while [condition].

Examples:

The application must store in-progress email messages prepared by the user.
The application shall not discard email messages when they fail to send.
The application must notify the user of received emails when the messages arrive.
Be consistent with the way you use language in requirement descriptions, especially when using imperative terms such as must and shall. Explicitly tell your readers whether some weaker imperatives, such as shall, are binding (the corresponding behaviours must be present in the complete system) or non-binding.

It is also useful to explicitly state what you mean when you use certain words in the requirements’ descriptions, thus avoiding readers interpreting your language differently.

Avoid vague words and use active voice to make your language more direct.

## preparing high-quality documentation
Effective requirements include the following considerations and details:

Audience: When documenting requirements, always consider the stakeholders of the project. Write the requirements in such a way that they can be understood by this audience.
Rationale: Add a rationale to each requirement to communicate to the reader the reason for its existence and its importance. The rationale should be as detailed as necessary for the intended audience.
Neutrality: Be careful to avoid assumptions about how requirements will be implemented in the system when documenting requirements. Focus on the observable behaviour of the system, not its internal mechanisms.
When finalising documentation, be sure to evaluate the complete set of requirements. Search for ambiguities and logical inconsistencies and correct any that you find.

Finally, add a unique identifier to each requirement so that it can be indexed and easily referenced.

~~~
15 Tips for Writing a Good Requirement

1. Define one requirement at a time - each requirement should be atomic. Don’t be tempted to use conjunctions like and,
 or, also, with and the like. This is particularly important because words like these can cause developers and testers to miss out on requirements. One way to achieve this is by splitting complex requirements till each one can be considered a discrete test case.
2. Avoid using let-out clauses like but, except and if necessary.
3. Each requirement must form a complete sentence with no buzzwords or acronyms.
4. Each requirement must contain a subject (user/system) and a predicate (intended result, action or condition).
5. Avoid describing how the system will do something. Only discuss what the system will do. Refrain from system design. Normally, if you catch yourself mentioning field names, programming language and software objects in the Requirements Specification Document, you’re in the wrong zone.  Avoid ambiguity caused by the use of acronyms like etc, approx. and the like.
7. Avoid the use of indefinable terms like user-friendly, versatile, robust, approximately, minimal impact, etc. Such 
terms often mean different things to different people, making it difficult to define their test cases.
8. Avoid rambling, using unnecessarily long sentences or making references to unreachable documents.
9. Do not speculate; avoid drawing up wish lists of features that are impossible to achieve. Saying you want a system 
to handle all unexpected failures is wishful thinking since no system will ever be a 100% what you want it to be.
10. Avoid duplication and contradictory statements.
11. Do not express suggestions or possibilities. You can identify these wherever you see statements with might, may, 
could, ought, etc.
12. Avoid creating a jigsaw puzzle where requirements are distributed across documents, causing you to cross-reference 
documents. This can make your RSD extremely difficult to read.
13. Do not refer to a requirement that is yet to be defined. Again, your objective is to make the document as much of 
an easy read as you can.
14. Use positive statements such as “The system shall…”, instead of “The system shall not…”
15. “Shall“ should be used where requirements are being stated, “Will” should be used to represent statements of facts; 
& “Should” to represent a goal to be achieved.
~~~

## Functional Requirements
Requirement 1
The system must enable users to reserve parking spots.

Rationale: Reserving and managing parking is the primary purpose of the system, and this high-level requirement captures that. This requirement will be followed by many detailed requirements describing exactly what the system must do to support reservations.

Requirement 2
The system must associate reservations with a time and place.

Rationale: To be useful to the user, a parking spot needs to be near a specific location and available at a specific time. Reserving just any spot for a user does not help them achieve their goal, and thus doesn’t actually solve the root problem.

## Quality Requirements
Requirement 3
The system must be fast to ensure that users can find parking spots efficiently.

Rationale: The system is intended to reduce the amount of time required to find a parking spot, so it must be able to quickly identify a spot for a user to save them time. By failing to find spots quickly, the system may also cause spots to be unoccupied for longer periods of time than necessary, causing the resource to be under-utilised.

Requirement 4
The system must be easy to use to avoid causing vehicular accidents.

Rationale: The system could present a safety risk if drivers operate the application while driving. Careful analysis and design is necessary to minimise the need for drivers to use the application after a reservation is made (which can and should occur before the user begins driving).

## Business Requirements
Requirement 5
The system must be operational prior to the beginning of the next major city event.

Rationale: The next major city event is expected to attract a large number of national and international tourists to Metro city and MCC needs the system to be operational by that time to avoid negative publicity and to reform Metro’s image as a liveable city for drivers. Note that this requirement constitutes a project constraint.

# tracing requirements
It is important to establish at what point requirements are complete.

Tracing requirements is following up the tasks involved in building the project to make sure it is becoming what was intended - that is, that it’s meeting the requirements.

Requirements transcend phases; although requirements are identified and documented in the analysis phase of software projects, they actually affect other phases of the project as well, which makes it extremely important to be able to trace requirements throughout the entire project.




