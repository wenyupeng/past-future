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