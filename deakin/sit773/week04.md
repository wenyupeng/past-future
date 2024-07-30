# Modelling techniques
There are many modelling techniques that can assist a systems analyst to identify requirements, constraints and conditions of system features.

## Personas
Personas are a technique for creating fictional example users to better understand what they need from the software.
At a high-level, the creation of personas helps you empathise with the users of the system and anticipate their needs in processes that the system supports or enables.

## User stories
User stories extend the modelling performed using personas by describing specific things personas want to do with the system.
User stories outline the high level actions the system can perform for personas, which helps to identify the constraints and conditions of system features.

## Usage scenarios
Usage scenarios describe how a user interacts with a system to achieve a goal. They can be high-level or low-level, depending on the needs of the systems analyst.
They are narrative descriptions that outline what happens during the user-system interaction, but do not describe how the interaction takes place.

## Use cases
Use cases determine how a system’s feature will work. In contrast to usage scenarios, use cases focus less on the needs and motivations of users and more on how the system will be used. By refining use cases, the logic of the low-level tasks the system must perform can be determined.

## Mockups and prototypes
Mockups and prototypes are simple representations or simulations of the system that can be used to gain insight into how users might actually perform use cases.

Modelling is generally only used to identify functional requirements


# What are actors and personas?
In requirements modelling, actors represent the roles that users, and even other systems, can take with respect to the system, while personas describe specific types of users to help bring the idea to life.

Personas and actors are a type of requirements model, both used by designers, developers, project participants, and others when designing products, IT systems, and services.

## Actors
An actor is the description of a role within a system. For example, a lecturer and a student are different actors within the university system.

Actors provide an abstraction to the different levels of user roles and personalities, making them easier to work with.

## Personas
A persona is the description of a fictitious user, who does not exist as a specific person but who is described in such a way that the reader can relate to the description and believe that the user could exist in reality.

# What are user stories?
User stories capture discrete requirements based on the perspective of the end user.
User stories help convey the different stakeholders’ needs.

format:
> As a [persona], I want to [action] so that [reason].

The persona ensures that you’re thinking about the actual people who will use this feature. If there is no identifiable persona or type of user, you should reconsider whether you need this story.
The action describes what will happen, but not how it is to happen. How the action or goal is achieved is outlined in the corresponding use case. Use cases are explored in the next activity.
The reason describes the purpose of this feature, depicting why the user wants to do this thing with the software. Again, if you cannot provide a reason, you should reconsider whether the feature is actually important.

example:
~~~
As a customer, I want to purchase multiple products at once, so that I can pay in a single transaction.

As a financial officer, I want to download the last 6 months of purchase transactions as PDF reports, so that I can reconcile our financial accounts.

As a student, I want to access the course materials online, so that I can complete my assessment tasks anywhere.
~~~

# Creating user stories
User stories are simple enough that people can learn to write them in a few minutes. Get stakeholders together with pen and paper writing simple statements on what the personas defined for the project will need the software to do and why.

## Begin with epics
Before jumping into writing your user stories, start thinking about epics first.

An epic is a larger story which describes the bigger-picture product features that are to be broken up into your user stories.

You can think of epics as a rough scope of the work your feature will perform, which helps avoid duplication and inconsistencies among user stories.

## Get together with pen and paper
Meet with all stakeholders to work collaboratively on the user stories.

Simple tools such as sheets of paper, paper cards, or large post-it notes are easy to use and facilitate collaboration.
## Put your personas to use
In a previous topic, you learned how to define the different personas that are expected to use your software.

Each persona will have a defined goal they want to achieve or problem they want solved by the software.

Ask yourself what functionality the product should provide to meet the goals of each persona to create user stories.
## Keep it simple
Refine this statement using the who, what and why template, so that you end up with a clear, concise, feasible and testable user story.

> As a customer, I want to purchase food online, so that it can be delivered to my home

## Indicate priority
To help plan iterations of work, it is vital to communicate the importance of specific product features to the development team. This can be done by adding a priority to each user story.

There is no single best method to do this, but stick with a consistent strategy that works for the project team. Some tips on indicating priority will be covered in the next topic.

~~~
https://www.romanpichler.com/blog/10-tips-writing-good-user-stories/
https://www.equinox.co.nz/blog/3-key-take-outs-writing-better-user-stories
~~~

# story points
Story points are numbers that indicate how difficult the story is.

Story points allow stakeholders to prioritise user stories, and make predictions about workload.

It is important to estimate the effort required to implement user stories and relevant features.

The implementation effort of a user story is defined in terms of story points.

Story points:
- are an arbitrary measure used to make comparisons among different user stories
- are numbers that indicate how difficult the story is in terms of effort, risks, and unknowns
- can be any positive number: the higher the number, the higher the story point’s effort and risk
- allow stakeholders to prioritise user stories, and make predictions about how much functionality can be delivered 
  by a particular date.

## Assigning story points
User stories are compared using their story points to get an idea of the relative effort they will require to implement.

### Determine a baseline user story
Before assigning story points to your stories, determine a baseline user story that all members in the team can relate to.

This will serve as a reference to help guide members of the team in scoring stories.

### Decide on a point system
A common point system used by teams is a modified Fibonacci sequence, such as 1, 3, 5, 8, 13, 40, 100. This system helps the team recognise and account for the existence of potential unknowns in a user story.

The rationale of this particular approach is that, the higher the story point, the more unknowns there are in the user story and the less accurate the estimate will be. This is reflected in the ever-larger gaps between consecutive numbers in the sequence.

### Determine rough estimates of time
Rough estimates of time can be made once you have some data on the rate that the project team is implementing features captured in the user stories. However, those estimates are not expected to be precise.

If the estimate of a user story’s effort is too big, then it’s probably too complex and will need to be broken up into smaller stories.

Keeping user stories small ensures that the associated requirements have been thought through in sufficient detail.

Smaller user stories also provide more flexibility when scheduling tasks.

https://www.mountaingoatsoftware.com/blog/its-effort-not-complexity

# Acceptance criteria
Acceptance criteria are used to confirm that a feature is working and complete according to the customer.

Acceptance criteria complement user stories. They specify what is needed for a feature or functionality to meet what was specified in the user story.

User stories are useful but still don’t provide enough information to get software engineers started on building system features.

Acceptance criteria are intended to get the team to think through how a feature or functionality should work from the users’ perspective.

~~~
As a customer, I want to purchase food online so that it can be delivered at home
This user story could have the following acceptance criteria:

The user can’t submit their order without providing their address.
Payments can be made via Visa, MasterCard, and Paypal.
Expired credit cards are rejected.
Acceptance criteria help us understand:

what is required for the feature to work: e.g., an address is required
by what paths the user can achieve their goal: e.g., payment via one of many methods
what the system needs to do under certain circumstances: e.g., reject expired cards.
Acceptance criteria are written in natural language on the back of the corresponding user story card. This keeps the user story and its acceptance criteria together.
~~~

## Acceptance testing
Acceptance criteria help define the boundaries of a user story and are used to confirm when a story is completed and working as intended.

Acceptance criteria form the basis for acceptance testing that will confirm that a feature or functionality is working and complete according to the customer.


# Usage scenarios
Specific system details are not included in usage scenarios.

To create usage scenarios, system analysts need to identify high-level requirements related to what users expect from the system and how they may approach interacting with the system.

A usage scenario highlights the steps taken by a user to achieve a goal while using the system, without revealing any system specific details.

Specific system details are not included in usage scenarios because, at the time of their creation, it is not yet known what the system will look like and how it will function.

When creating a usage scenario, it should be written as a narrative that highlights the following:

**Actor**: the user that is interacting with the system
**Environment**: the setting in which the actor is using the system
**Goal**: the outcome the actor using the system is expecting to achieve
**Tasks**: steps undertaken by the actor in order to achieve the goal

~~~
Sam is an avid clothes shopping enthusiast who is generally too busy to visit a shopping centre. Sam works long days to fund his purchases and by the time he’s finished at work, all of the shops are closed.

Sam still wants to spend his money on clothes, so he’s decided to use an online store called “Mail Me Threads” to fulfill his desire to buy clothes within the comfort of his own home.

Sam loads his “Mail Me Threads” profile and starts to browse the catalogue. He finds some shirts that he likes and adds them to his cart. He then decides he wants some jeans, so he changes the catalogue to the denim product line and adds some jeans to his cart. Sam proceeds to the checkout to pay for his clothes. He uses his credit card and nominates an ideal delivery day so that he can be home when his new clothes are delivered.
~~~

Notice that the example portrayed above provides a narrative that provides all the relevant detail:

- the actor is portrayed as an individual named Sam
- the environment in which he is using the system “Mail Me Threads” is his home
- Sam’s goal is to buy clothes
- the tasks required to reach his goal: loading his profile, browsing catalogues, adding items to his cart, paying 
  and nominating an ideal delivery day.


Usage scenarios can be written to reflect pain points.









