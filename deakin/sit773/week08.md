Leckie’s Choice (LC) began as a small business 20 years ago and has grown to have multiple store
locations throughout Victoria. Currently, LC is a distributor, wholesaler and retailer of residential and industrial electrical equipment, supplies and services. The company also provides installation and services in areas such as energy
management, solar systems, home automation, surveillance systems and data and communication
equipment. LC has well trained, knowledgeable staff that understand their customers, through which the business
builds and maintains strong, professional relationships. The company has an informative web site, however, customer orders are mainly dealt with over the phone and e-mail at local branches as the
business website does not support ordering. The owners of the business are transitioning into retirement, leaving their son and daughter, John and
Ruby, in charge. John and Ruby are concerned that the business is not keeping up with the times as
the market is becoming more and more competitive. This is creating a new challenge for the business. Both of them have observed that total quarterly sales have declined. In addition, customer queries have
recently doubled, increasing the workload for LC’s sales staff. Some customers have commented that ordering and delivery take too long and consequently, they’ve
proceeded to purchase products directly from other wholesalers. Customers have also reported that
they are receiving more attractive promotions and loyalty rewards from other wholesalers. John has identified that the current marketing and product promotion policies of LC do not reflect their
customers’ expectations. A new marketing manager has been appointed who is sorting through
feedback left by customers in order to develop plausible promotion policies and customer loyalty
rewards programs. While the new marketing manager is working hard to try and develop these
programs, John understands that the result does not guarantee an increase in customer traffic or
loyalty.

Ruby shares a common view with John. Both of them believe that for the company to remain
competitive, it needs to use technology to its advantage but they are both unsure about how to do this. John and Ruby have approached you, a software engineer, to identify problem areas, make
recommendations and propose solutions that will help to ensure the company stays economically
viable in the future.

# Scope-cost-time triangle
Building software based on specific requirements involves understanding the invisible forces that can impact software projects: scope, cost and time.

As effective as the project team can be, there are forces beyond the team that can require aspects of the solution they are building to be cut, or produced at lower quality than the team is capable of. This can be frustrating for the team when they know they can do better, especially for the systems analyst who worked hard to identify the right solution — but sometimes this cannot be helped.

The universality and enormity of these forces can substantially alter the system that is constructed, which makes awareness of them critical for systems analysts.

## Scope
The Scope of a project is based on the requirements that are agreed upon with the client. This defines what will be included in the project, including the necessary functional and non-functional requirements.

Ideally, the scope should be locked down during the early phases of the software development lifecycle, before development has commenced.

However, in practice clients often do not know what they want until they see something that is not what they want. As a consequence, the scope of a project can easily change and when this continues without check it is referred to as scope cree

## Cost
Cost refers to the budget required for completing the work defined by the scope of the project.

Typically, the cost of a project is fixed and development ceases once the client has run out of money to pay the developers.

Poor upfront requirements analysis can lead to a blow out in costs, for example, additional technical challenges are uncovered that were not budgeted for.

## Time 
Time-to-market is an important concept in software development as it can be the deciding factor as to whether the product is a success or a failure.

Project teams are often under time constraints to meet deadlines imposed by the commercial reality. Common reasons for time pressure include:
Common reasons for time pressure include:
- new features that must be ready for marketing purposes
- the requirements change and ‘lost’ time needs to be recovered
- the project team is downsized or needs to upskill
- poor estimations of the time it takes to complete the work

## Quality
Software quality is difficult to achieve, and understanding the quality requirements for a system requires thorough analysis.

A common challenge to achieving quality is that the quality requirements are often implied, ie everyone expects a mobile app to be fast — but the client may not specify that as a requirement.

It takes significant effort to build quality into a product and often early design decisions influence the final quality.

# Tradeoff strategies
Dealing with competing forces requires developers and product managers to make tradeoffs.

The type of tradeoff that needs to be made is dependent on the circumstances of the individual project.

Two common strategies are:
- to cut quality
- to cut scope

## Cut Quality
Often the quality of a project is compromised — as this is the simpler approach and often has no immediate impact, especially since quality issues may only surface after the system is delivered.

When cutting quality, the expected features of the system are delivered but the functionality that supports them may not operate in an ideal way. Such issues may not be externally visible, enabling the project team to deliver on the expectations of the customer, but risks to the continued operation of the features may have been introduced.

To mitigate these risks, the project team must document decisions made with respect to quality and anticipate the implications of those decisions.

## Cut Scope
Cutting the project scope can be a good first approach. This is ideal as many users do not use all of the features implemented in a software product.

To achieve this strategy, strong negotiation skills are required with the client to decide upon which features will not be implemented in this version and which features are essential.

This strategy is not always possible because some features may be announced through various marketing strategies, which makes them ineligible to be cut.

# Project Roadmap
A project plan focuses on the execution of a project and is a way to communicate the project status and direction to all key stakeholders.

After the requirements have been identified and locked down, a project plan is needed to:
- specify what will get developed
- for effective resource scheduling
- to help expose potential project risks ahead of time
- to keep the project on track (if kept up-to-date).
As you can see, planning is a crucial step in the software development process.

## Roadmap
A project plan consists of a roadmap that captures the priorities of the project. A roadmap includes the key goals that need to be achieved and the order in which they should be completed.

Project plans are evolving documents that change as new information about the project comes to light and as such, should be treated as a guideline.

For the project plan to continue to be useful, multiple stages of planning are needed; it is not a once off process. As nobody can predict the future — detailed planning up to six weeks in advance is usually sufficient for the average project.

## Outcome-focused planning
It is important that a roadmap focuses on what is delivered to the customer, ie the outcomes or deliverables that they require and not the activities that produce them. This is because customers pay for outcomes (eg finished components of the system), not for development activities (eg researching the solution to a problem).

Focusing on outcomes rather than activities provides customers with a tangible benefit and can help boost the motivation of the project team as they can clearly visualise progress.

Examples of outcome-focused work include:
- writing code
- producing design artefacts
- writing handover documentation
- creating UI design documents.

# Planning to meet requirements
Detailed planning is key to successfully meeting all of your requirements within a project.

## Task breakdown
After requirements have been identified and established, they need to be broken down into manageable tasks for the project team.

Breaking down a requirement may require discussion between multiple roles within the team, such as designers and engineers. Often there is a need to author a technical specification document that includes the breakdown of a requirement into tasks that can be broken down further into manageable units of work.

An appropriate breakdown of a task can help with the scheduling of work as well as improve estimations.

## Critical path planning
Scheduling tasks in the right order ensures that the requirements are delivered when they are expected.
1. A strategy that helps achieve this is critical path planning and works as follows:
2. Determine all of the connections and dependencies between tasks
3. Determine which tasks need to be completed to deliver the system quickest
Prioritise the project’s tasks.

The Critical Path is the longest amount of time required to complete all aspects of the project. Focusing on tasks in the Critical Path increases the chance that the system will be completed on schedule.

## Traceability
Keeping track of changes to the software that influence a requirement is known as traceability.

A simple traceability technique is to tag each development task with the requirement that it relates to. The advantages of this approach are that:
1. bug fixes are associated with specific requirements
2. software releases are easier to associate with the requirements they include
3. keeping track of the activities that affect requirements also helps with activities such as creating a traceability matrix.

# Estimating task duration
Estimating how long it takes to develop a piece of software is very challenging.
This is due to changing requirements, individual skillsets, unexpected technical issues and the variety of programming tasks that are required for building a software system.

The project team needs to navigate these difficulties to ensure that the requirements of the system can be implemented on time.

For an individual developer to make an accurate estimate, they need to:
1. have completed a similar task previously so they are aware of the intricacies involved
2. have the required skillset for completing the task
3. be familiar with the system’s architecture so they know how the task fits in
4. be aware of all future technical unknowns, as much as is possible.

Due to these difficulties the following principles should be taken into consideration when estimating:
- estimation should be used as a rough guide only, as the unexpected often happens
- buffer time should always be added to estimates — as developers are notorious for overestimating their ability to complete a programming task
- aim to gradually improve the accuracy of the estimates over time
- acknowledge that unless the developer works on the same kinds of tasks, they are unlikely to improve their estimates.

## Busywork
Time spent on busywork instead of the actual task is time lost to the project team.

Many activities carried out by a project team may have no tangible outcomes. This is defined as busywork, where a team looks busy but their work provides very little benefit to the customer.

An example of busywork is manually performing tasks that are relatively simple to automate.

Busywork can arise from developers desiring to revise parts of the system, which can become a never-ending activity (this can be beneficial some times, but it not necessary to deliver the product).

Management can also cause busywork by setting arbitrary code metrics which result in unnecessary code being written.

It is important for the project team to be vigilant against busywork and eliminate its causes, otherwise it will affect the accuracy of estimations.

# Backlog
Essentially a backlog is an ordered ‘to do’ list for the team.

After the requirements have been discovered and a roadmap has been created, tasks need to be recorded for the team to work on. These tasks are captured in what is known as the backlog.

The backlog includes requirements, bugs and work tasks related to the project at hand.

Backlogs are usually used in agile projects, where less up-front planning typically takes place.

During development, the engineering team “pull” all the tasks from the top of the backlog that they have the capacity to complete in a fixed time period. This is usually done in a sprint or iteration.

## Communicating
The backlog provides a means of communication between the product owner and the project team. As such, the backlog should be stored in a central location that is easy to access for all team members.

- An issue tracker, such as JIRA which we introduced in the previous step, can be used for this task.
- A large board with physical task cards on it is also common, as shown in the below image.

The columns of the board can vary, but generally include:
- backlog or planned: tasks the team is aware of but that haven’t been started
- in progress: tasks currently being worked on
- done: tasks that have been completed, tested and reviewed and are now finished
- review or on hold: tasks that have been completed and are being verified.

Seeing tasks move through the board can be a great motivator for the project team.
Also, seeing cards stuck in a column can alert the team that progress is blocked so they can assess what needs to be done.

## Prioritising
It is important that the backlog remains a prioritised list throughout the development process and that is updated and revised frequently.

The product owner is responsible for prioritising the backlog to ensure that the project team works on the highest-value tasks.

The project team needs to keep in communication with the product owner to ensure that the work can be completed in the desired order.

## Adapting
Backlogs are intended to be adaptable to change, though frequent changes to work that has already been started can lead to a slow down in productivity as the team has to change focus.

In some cases, changing or discarding tasks is necessary. This can occur for a number of reasons, including a change in product owner priorities, new technologies becoming available, and changes in the law.

Requirements can also change and depending on the importance of the requirement, this may ripple through the backlog.









