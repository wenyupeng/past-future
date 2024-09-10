# Analysis artefacts
Documentation produced during the development of a software system serves to maintain verifiability and traceability of functional requirements.

There are many forms of documentation that are produced during the development of a software system.

The forms of documentation may vary in some ways to accommodate the chosen Software Development Lifecycle (SDLC) but, essentially, the methodology and reasoning behind producing such documents remains the same:

to maintain verifiability of functional requirements
to maintain traceability of functional requirements.
Much documentation is authored during the analysis phase, including:

use cases
user stories
usage scenarios
requirements specification.
Because the integrity and correctness of these documents is pivotal to a system’s design and implementation, it must be possible to maintain the documents and make any changes visible to individuals for whom the changes are relevant.

## Document management
There are some points that require consideration when contemplating a process for document management and they include:

### Access
Access to documents needs to be provided to the individuals whose work depends on those documents and for these people, gaining access should be painless.

As an example, the system’s architect should be able to easily access all documents they require to complete their design and implementation tasks.

Access may enforce restrictions on who may view certain documents.

### Version control
Documents can and do change over the course of a software project. As requirements change documentation changes, so there must be some form of version control in place that keeps track off all changes made to a document.

Version control is an incredibly useful tool for understanding how and why a software system changes over time, which is critical to understanding how requirements evolved and, in some cases, what went wrong.

### Visibility
Any changes to a document should be visible and project team members should be able to easily identify when a document has changed. This can be achieved by notifying team members whose work depends on a changed document and/or using a document management system that can notify people associated with the document.

Other visibility factors include who the document author is and whether related documentation is affected by changes.

## Document management tools
There are many tools that provide centralised document management and they are essential in regards to maintaining and distributing documentation as required.

One such system for tracking documents and handling version control is GitHub. By making use of such a system, all team members are able to access a centralised repository which houses all required artefacts. A tool like GitHub offers essential traceability in regards to how documents change over time, including who made which changes.

# Software requirements specification

A systems requirements specification (SRS) is a clear and complete description of a system’s requirements that is produced before the system is developed.

The SRS defines how the system will function by outlining all requirements and any supporting information and rationale.

Every software system has a customer who originally found need for a software system to solve some form of problem, so it is essential that the SRS captures all of the functional and non-functional requirements of the software system required to address that problem.

There are a number of qualities that an SRS must exhibit to be useful:

## Correct
The SRS must accurately capture the details of the system’s functional and non-functional requirements.

It is important that the SRS is free from error as it explicitly defines a system that is ready to be developed.

## Clear and complete
The details the SRS defines in relation to system requirements must be clear and complete. Put clearly, each requirement specified by the SRS can not be open to more than one interpretation.

Any ambiguity surrounding any functional requirements can lead to erroneous implementation or unintentional scope creep.

## Consistent
All details within an SRS must be self-consistent and not contradict each other. Essentially, an SRS must reflect the collective outcomes of analysis activities.

The requirements it contains must exactly match the requirements identified by the systems analyst and any details captured in use cases and other supporting documentation.

## Prioritised
The SRS should clearly define the priority for each of the requirements that the system must implement in order to ensure that the development efforts are focused upon delivering a system that fullfills the most important needs of the customer.

## Verifiable
The SRS must define requirements that are verifiable by some form of activity or test so that the system can be validated against the specification.

This issue is related to the clarity and completeness of an SRS, since a test defines an objective end point for a requirement, preventing scope creep.

## Modifiable
As the customer’s needs change, so do the requirements of the system.

The SRS must be easy to modify so that the rest of the project team can react to changes in the system’s requirements specification as soon as possible.

## Traceable
All requirements and materials contained in the SRS must be clearly identified and should be indexed for easy lookup.

As related documents and materials are produced over the course of the project, it is critical that they are able to refer to the specific details in the SRS to indicate why the work was performed.

# Documentation and development methodologies
Documenting requirements is essential, whether a project team decides to document anything else or not.

Documenting requirements allows the team and the customer to have a record of what they intend the system to be, which the system can then be validated against (both to guide the team’s efforts and to gain acceptance of the work from the customer).

Waterfall model: The SRS document is simplest to maintain when a project follows the waterfall model: the SRS is created at the conclusion of the analysis phase, never updated, and serves as an oracle of truth for all subsequent tasks.

Adaptive lifecycles: Maintaining an SRS is more difficult in the adaptive lifecycles, but still relatively simple since each lifecycle has well-defined analysis phases.

Agile Development: In Agile Development, as there is no discrete requirements analysis phase, creating and maintaining an SRS can be difficult. Furthermore, many proponents of agile share the perspective that documentation is a risk, since it requires time to create and maintain and errors can misinform individuals. Generally, documentation in agile projects occurs on an as-needed basis.

# Getting ready for handoff
The efforts of the systems analyst are useless if they are not able to communicate the outcomes of the analysis to the project team.

Documenting requirements is one aspect of this task, but there are a number of other factors which affect whether the project team has the same understanding of what the system needs to be as the analyst.

## Handoff Considerations
There are a number of considerations to make to ensure that the project team is ready to commence work after the analysis phase:

1. The project team should at this stage be familiar with the software system’s vision statement. The vision statement 
is essential in capturing the essence of a software system, so it is ideal for creating a shared understanding of what the system is going to be.
2. The project team needs to be briefed with the high-level requirements of the system in order to develop an 
   understanding of the problem domain and the customer’s need, as well as how the system will deliver on the vision statement.
3. Any plans for the development of the system must make reference to and communicate how the plans accommodate for 
   the system’s requirements. As an example, there may be a technology gap in the way of satisfying a key requirement, therefore time and budget for research and training is required to fill that gap. Such activities need to be referenced in all relevant planning documents.
W4. here necessary, the systems analyst should meet with the customer, project manager and solution architect to 
   discuss the priorities of requirements. The reason for involving different members of the project team in this process is so that considerations that the systems analyst is less aware of (e.g. the scale of technical work needed for certain requirements) can be factored in (e.g. input from the solution architect). The customer is involved because they best understand their own priorities. The project team can also present prioritisation options to the customer.
5. The deliverables that constitute the final handoff need to be clearly communicated to the project team so that it 
   is clear what the customer is expecting and what must be delivered. As an example, the system may need to be delivered with a full suite of technical documentation that describes the interactions that can take place within the system. The team needs to be aware of this so that they can create that documentation.
## Agile projects
Since agile projects lack discrete analysis phases, the handoff considerations are a constant consideration until the project is completed.

# Building the solution: design and implementation
As we’ve previously observed, after analysis follows design and then implementation.

Although the order of phases across the development lifecycles differs, and all formal distinction between the phases falls away in Agile Development, the fact remains that there needs to be a clear understanding in regards to what is to be built before it can be designed and implemented.

## Design activities
Design involves a wide range of tasks. Two of the most important categories of design tasks are software design and user interface design.

### Software design
Software design includes everything from determining the high-level structure of the system to (nearly) specifying the exact actions the software system must perform. It includes considerations such as:
- Architecture
What are the components of the system and how will they interact?
- Component design
How will each component of the system function?
- Logic
What exact steps must the code that makes up each component perform?
- Hardware
What computational resources are required to run the system?
- Organisation
What configuration of machines will the system be deployed on?
- Scale
What extent of storage and processing is the system expected to perform?
- Qualities
How can the system be designed to meet its quality requirements?
  It is important that the solutions architect is experienced and knowledgeable so that they can effectively design around these considerations, or at least navigate the project to an appropriate design even if there are unknowns. We will look at how a domain model can be transformed into a technical design model in the next step

## User interface design
User interface design is concerned with how users directly interact with the system and tries to ensure that users have specific experiences as they do so, catered to the tasks that they perform by using the system. This may include:

- designing a website so that it is engaging to visitors and maximises their enjoyment
- designing the control panel of a safety-critical system so that it focuses users’ attention on the most important 
  details
- designing an interactive guide in such a way that it is usable by people with physical or mental limitations.
A poor design can undermine the objectives of a system, even if the correct requirements have been identified. Therefore effective user interface design is critical to the success of software projects.


## Implementation activities
Implementation is the phase in which the creation of the software system occurs.

If the design activities were performed thoroughly then implementation should be straightforward. However, surprises in the implementation phase are common due to the difficulty of accounting for all technical details of a system.

For software projects, the implementation phase primarily involves the production of source code - text written using a programming language that is converted into an executable program using software known as a compiler.

Development practices and development tools influence how software architecture work is performed, we will learn more about that this week.

Large amounts of documentation may also be written during this phase. Much of the documentation will describe the precise operation of the system or components thereof to serve as a manual for different users, including technical users that will maintain the system.
 
# Making a design from a domain model

Domain model diagrams can be used as a basis for determining the high-level design of the system by transforming them into design class diagrams, or class diagrams.
Domain model diagrams specify the entities within the problem domain and any relevant data associated with those entities.

The high-level design process involves three main steps:

specify data exactly
add behaviours to classes
add coordinating classes.


## Specify data exactly
In the domain model diagram, data is described using terminology from the domain. This helps both the stakeholders and the system analyst, understand the data.

Design class diagrams annotate the attributes in domain model diagrams with types that indicate the nature of the data. The resultant information is called a field.

## Add behaviours to classes
Entities within a domain normally perform one or more actions. In class diagrams, these actions are listed below the fields on the class that performs them.

This information is referred to as methods. Each method consists of three parts:

Name:
A short identifier for the method that broadly communicates what it does.
Input:
A comma separated list of the annotated data the method expects.
Output:
The type of data that the method returns to whatever invoked it (if any).

## Add coordinating classes
Classes may interact directly with each other, but often a ‘manager’ class is needed.

# Development practices
Technological advancements and changing perspectives have lead to many software project practices.

In some cases, these practices substantially change how the project team works and how they deliver outcomes for the customer. In many cases they also have implications for how the team ensures that it is delivering on a system’s requirements.

The development practices we will explore here are:

Test-Driven Development
Continuous Integration
Continuous Delivery.

## Test-Driven Development
Test-driven development (TDD) outlines a specific process for producing program code. It works as follows:

Write a test that ensures that the code you intend to write performs the action you expect.
Run the test and if the test passes, return to Step 1. In TDD, tests are written and run even before the code they test exists, so it is normal for the test to fail.
Add new code or modify existing code until the test passes, then return to Step 1 until the feature or functionality you are working on is complete.
The objective of TDD is to ensure that every change to the software has an accompanying test and that code is only added to the software as needed for tests to pass. In this way, the tests represent very specific requirements and only code that satisfies those requirements is included in the system.

Unfortunately, just as code can be incorrect, so can any tests written to check code integrity (which are themselves code). TDD can also be very time-consuming to perform.

## Continuous Integration
Integration is the process of making different software components work together to form a system. This is necessary even after components have been created as those components change and are further developed over time.

Generally, integrations should be small to reduce the extent of integration issues.

Compare, for example, integrating many completed components that were developed independently versus integrating those components every time a feature was added to any of them. The former approach introduces the risk that the components just won’t work together or will work in unpredictable ways.

By integrating after every small change, the overall complexity of integration is significantly reduced.

Remember that every integration introduces the risk that parts of the system won’t function, which may prevent the system delivering on one or more of its requirements.

Continuous integration (CI) once referred only to a somewhat extreme perspective that all of the components of a system should be integrated many times every day when the system is under active development. This ensured that errors caused by integration were limited in scope and generally easy to identify and fix. But it also meant that the project team needed to be disciplined to follow this process and had the tooling in place to make integration as quick as possible.

CI has since broadened in meaning to include any regular or semi-frequent practice of integrating components and testing that integration, and has achieved widespread acceptance.

## Continuous Delivery
Continuous delivery (CD) is the practice of ensuring that a system could be provided to the customer at any time while under development. Changes to the system, such as adding new code or modifying existing code, undergo a sequence of checks, tests and approvals designed to ensure that only changes that could be included in the delivered system are permitted.

Although the systems produced using CD are in a constant state of readiness for delivery, the project team may choose not to continuously deliver the system depending on the needs of the customer and factors such as market forces and timing. Advocates of CD suggest that simply following CD, whether or not continuous delivery occurs, is beneficial to the quality of systems because of the tests and approvals each change undergoes.

Like CI, CD requires strict discipline from the team and appropriate tooling to be efficient and effective. Efficiency may be reduced if a test or approval requires human input. Furthermore, CD is not appropriate for some domains (e.g. safety critical systems) and may not be preferred by some customers.

# Development tools
Like any profession, software engineers have tools that simplify various aspects of their work such as text editors, source code linters and terminal programs.

Although systems analysts rarely use such tools themselves, it is useful for them to be aware of how engineers in the project team perform their work as they transform the analyst’s requirements into software.
## Text editors
Developing software involves editing the files that contain the source code, or programming language code, that is compiled into the software that defines the system.

Often, build scripts, configuration files, data files and documentation also require creation or editing. Some developers prefer to do all this work using a text editor 

Text editors simplify the task of writing and manipulating large amounts of text. Unlike text processors, they are designed to be used with non-natural language and don’t format material in report or article style.

## Integrated development environments (IDEs)
IDEs contain advanced features for developing software that are often missing in text editors. These features include:

source code navigation
code auto-completion
semi-automated configuration
debuggers, code inspection
code linters (see below)
integrated code documentation.

## Infrastructure
Software needs to be deployed to be made available to end users. Often this requires uploading the system software to a web server on a 3rd party hosting infrastructure.

## Linters
Most of a developer’s time is spent reading source code rather than writing code so it is important that code style guidelines are enforced to assist readability.

Source code linters are tools that automatically check code to ensure that it meets style and formatting rules. Some linters can automatically update a code base to conform to their style and formatting rules.

## Static checkers
Static checkers inspect code and determine, where possible, what the logical outcomes of that code will be.

This provides insight as to whether the code does what was intended by the programmer, which makes them useful for identifying bugs before testing occurs. Static checkers cannot identify all bugs, but they do help.

## Version control
Developers write a lot of code and sometimes they need to review previous revisions of their work.

Version control tools help developers keep track of their changes and review changes others have made. These tools also simplify code review, backing up copies of the work and identifying versions that have been shipped to customers.

## Terminal
Complex tasks can often be accomplished with a few commands executed at the command line.
A terminal is a program that enables developers to use a command-line interface to:

run scripts
search directories
connect to remote servers
find and replace in files
view running processes
and many other tasks.

# Customer sign-off
Sign-off is when the team’s organisation and the customer both agree that the solution produced by the team solves the problem the customer first brought to them.

## Sign-off and its importance
If a project is well-managed, the system is eventually completed and signed-off.

Sign-off is vitally important for the organisation that produced the system because, by signing off, the customer acknowledges that the work was delivered and that the organisation should be paid.

Sign-off also establishes the point at which the system is considered complete, enabling the project team to suspend work on the system. This guards against the issue of scope creep. Without a defined end point, a customer may continue to demand features and tweaks causing the project to be prolonged, costing the organisation time and money.

## What could go wrong?
Although the outcomes of a project team can be substantial, it can be difficult to get a customer to agree to sign-off on the project.

For example:

the system may differ somewhat from the expectations of the client, making them too reluctant to recognise it as a solution to their problem
the requirements, if poorly defined, cannot be validated, enabling the customer to argue that the system doesn’t meet their interpretation of the requirements
there is also the fundamental risk that the problem was poorly understood or the solution was poorly defined.
By having a focused and controlled process for verifying requirements and gaining acceptance of the solution by the client, issues in the requirements can be identified sooner and the solution can be improved.

In the worst case, a customer refuses to pay for the construction of the system. This may result in the organisation that constructed the system absorbing the cost, or legal action being launched to resolve the issue. Both occurrences can be extremely expensive for the organisation.

## Mitigating risks to sign-off
There is no guarantee that a sign-off process will go smoothly, but some strategies can mitigate the risk of disagreement between the developers of the system and the customer:

Shape the customer’s expectations by stating the implications and risks of any input they provide regarding the solution.

For example, if the customer has an expectation at the start of the project that is infeasible, communicate why this is so and suggest alternatives. Don’t hide this from the customer and deliver a partial or different solution.

Get the customer to agree on criteria for accepting deliverables as complete.

The outcomes the customer expects should be agreed and documented before work begins so that both parties understand what is expected to be produced. This must happen before work begins so the project team doesn’t waste time building something the customer might not accept.

Guide the customer through the process by providing them regular updates on progress and keeping them aware of relevant project details and risks.

For example, notify them as major components of the system are completed and indicate what the project team is working on next.
Essentially, be realistic about the customer’s expectations at the start of the project, get them to acknowledge the solution you are proposing, and help them understand how the system is developing.

# What needs sign-off?

At the conclusion of a software project, the organisation that produced the system must get the following signed off:

All agreed deliverables:
These are artefacts (i.e. source code, documentation) that the organisation agreed to develop and provide to the customer. The customer must sign off to acknowledge that they’ve received all of the required deliverables.

User acceptance testing:
The customer must acknowledge that they have tested the system to see if it functions correctly and as agreed. This is called user acceptance testing and by signing off at this stage, the customer confirms that the system is ready for deployment. We will look at this in greater detail in the next step.

## Other considerations

Change requests
If the customer requests a change to the scope of work, the cost and scheduling impact of this change should be determined and the customer should be asked to sign-off on it.

Aside from getting the customer’s agreement to pay for the change, this also ensures that the customer is aware of how the change affects the expected cost and duration of the project.

Support agreements
It is common for software defects to go undetected during testing and only become apparent after the system has been deployed.

Generally, the organisation that produced the system is expected to provide minor support such as fixing post-deployment defects or fixing small features.

The customer must be made to sign-off on the extent of support the organisation will provide after development of the system in order to avoid scope creep during the maintenance phase of the project.

Service-level agreements
A Service Level Agreement (SLA) is an agreement between an organisation and the customer for the organisation to provide specific services to the customer for a defined period of time at an agreed cost.

A project may conclude with an SLA; for example, an organisation may produce a solution for a customer and then perform the service of operating that system for them. The SLA specifies the level of quality of the service.

For projects that end in an SLA, the organisation must get the customer to sign-off on the level of service that will be provided so that both parties are in agreement.

# After sign-off
Obtaining sign-off on the final deliverables of a project and user acceptance testing should be a moment of celebration for the project team. It means that they took on a substantial real-world problem and solved it to the customer’s satisfaction. This is a great achievement, especially considering the success rate of software projects.

After the final sign-off, the project team should review what transpired during the project so that they can learn from the experience to increase the chance of success for subsequent projects.

## Who performs the acceptance testing?
Acceptance testing is performed by the customer of the product, someone who is outside of the organisation that developed the system.

This is to ensure that the requirements as specified by the customer are met and that they are satisfied with the final system. It also ensures that the system can operate in the customer’s target environment.

Internal “acceptance” testing may also be performed by the project team’s organisation to ensure that any obvious omissions to the system can be fixed before the actual user acceptance testing takes place.

It is very important that the system passes the acceptance testing step since this can determine if a customer will pay for the solution, as discussed earlier in this activity. But the importance of acceptance testing goes even beyond that.

Ultimately, software is intended to be used by people to solve a problem that they face. Software should be developed with this focus in mind and be designed to pass the acceptance tests from the start. All other testing techniques and development tasks form around this, ensuring a quality product is produced that satisfies the acceptance tests.

