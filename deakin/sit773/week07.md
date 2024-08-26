
# Software development lifecycles
## Predictive lifecycles
Predictive lifecycles are designed to follow a series of steps, or phases, where each phase, upon completion, provides the prerequisites for the next phase of the system’s development.

As an example, in a predictive lifecycle, the design and implementation of system functionality do not begin until the requirements have been identified and documented.

## Adaptive lifecycles
Adaptive lifecycles generally do not have a rigid set of steps or phases that need to be completed in sequence for a project to progress.

Due to the less rigid nature of adaptive SDLCs, some requirements are not well defined until late in the project.
Care needs to be taken to identify all high-level requirements at the start of the project, so that requirements discovered late in the project do not substantially alter the project’s direction at great cost.

### waterfall model
In the waterfall model, the SDLC phases are completed in sequence to progress toward a complete system.
It is considered the traditional methodology due to its position as an early academic model of software system creation.

#### Risks in the waterfall model
If some of the activities that make up a phase in the waterfall model have not been completed, or have failed to deliver their expected outcomes — risks will be introduced to a software system’s success that can be severe.

The worst case scenario is not recognising issues which will have repercussions later on in the development cycle.

## Parallel development
The concept behind parallel development is to break a project down into smaller sub-projects, which can all be developed concurrently, or in parallel.

These sub-projects each make up a specific section of the main project and contribute to the system’s overall function.

For example, you may have a sub-project focused on data storage and processing — and another sub-project focused on user interface. When both sub-projects are complete, they are integrated to produce the complete system.
~~~
Advantages
- Development progresses on a number of key system components simultaneously
- Development efforts are not centred around completing the system as a whole, but rather, implementing the system as a number of isolated modules
- The set of requirements of a sub-project are specific to the functionality that the sub-project aims to implement
- The scope of deliverables for each sub-project is smaller because each is independently developed
- Once a sub-project is complete, the aspect of the system that it represents can be signed off as complete.
Disadvantages
- Sub-projects eventually need to be integrated together to create the software system
- Integration of sub-projects may require additional development to ensure that they function together correctly
- A sub-project may depend on another sub-project, which could limit the value provided by the parallel development lifecycle
- Establishing project scope can be complicated and drawn out since the scope and requirements for each sub-project need to be identified before work begins.
~~~

## An ideal approach
Both predictive and adaptive lifecycles have strengths and weaknesses. Ultimately, the success of a project is determined by being able to visualise and understand clear outcomes and deliverables for the project, which reflect the domain and business problem for which the system is being designed.

## Iterative lifecycles
The iterative approach seeks to implement a software system in a number of incremental steps, where each iteration builds upon the software system by adding some form of functionality.

The idea is to develop and build incrementally, with each build representing a new major feature set of the system.
It is typical to start off with some form of functioning base level system, which each iteration builds upon.
As an example, a web community software system may start off with a platform that enables authenticated users to post messages in forums. Each iteration will add further functionality such as user profile pages, photo galleries and more.

Note that requirements analysis occurs before any iterations start, as it is still necessary to understand what system is to be constructed. The systems analyst also has to prioritise the requirements so that they can be allocated to a specific iteration of the system’s construction.

This is extremely important, since prioritising the wrong requirements can cause the customer to have to wait through one or more iterations before they can observe and interact with the features they consider crucial.

The analyst also has to be careful to ensure that the requirements implemented in each iteration result in a system that can be considered, in some respect, complete. At the end of each iteration, the system should be in a state in which it is usable and existing features don’t depend on planned features.

The advantage of the iterative lifecycle for the analyst is that the customer can provide feedback after interacting with the system at the end of each iteration. This enables them to adjust the requirements of the project to meet the customer’s needs without much impact on other phases, as opposed to what can occur in the waterfall model.

~~~
Advantages
- Every incremental build produces a functioning software system.
- Development progress can be observed by the customer as soon as the first iteration is completed.
- Can be used for adding additional functionality to an existing system.
- Can incorporate parallel development, allowing multiple features to be developed concurrently.
- Testing features is simplified because tests can be designed for single iterations.
Disadvantages
- The systems analyst must be careful when incorporating the feedback of the customer into the existing requirements, especially if that feedback contradicts existing requirements implemented in earlier iterations.
- Project teams may choose to start an iteration before requirements analysis is completed, which may save time but may result in the first iteration addressing incorrect or low priority requirements.
- Generally there is no concrete end date for the project as the system is being implemented iteratively over an extended period of time.
- Scope creep can occur if the project team is not disciplined in setting the scope for each iteration.
~~~

## Prototyping lifecycles
Prototyping lifecycles iterate on an aspect of the system, with the intention of quickly and inexpensively finding an approximate solution — which can then be refined into the complete system.

This is in contrast to the iterative lifecycles discussed in the previous steps, in which the project team iteratively extends the functionality of the system, ideally getting it closer and closer to the optimal software solution for solving the customer’s problem.

Prototyping lifecycles provide the following advantages to project teams:

- customers can be involved in the system’s design and provide early feedback
- implementations capture requirements in concrete form
- required changes to the system are identified early.

In the evolutionary prototyping lifecycle, the solution that is iterated on by the project team, is the system itself.

A series of iterations involving analysis, design and implementation are performed. The result is a simple version of the system that contains some core functionality that can be demonstrated to the customer.

The customer then provides feedback as to how effective they believe a refined version of the current system might be.

If the customer rejects the prototype, then the project team simply incorporates the customer’s feedback into the next prototype.

If the customer accepts the prototype, then the prototype is expanded and refined, or evolves, until it has reached the quality expected by the customer.

A rejected prototype is an unfortunate loss in terms of project time and resources, but it is much less expensive to identify errors early in the project.













