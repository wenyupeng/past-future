# Domain Driven Design Quickly

关注精简的业务模型及实现的匹配

```
模型驱动设计：MDD
模型驱动架构：MDA
```


Explain how the selection is used within the Accounts and for the menu.
Selection is used as label to mark user's action, and passed in the object.

Why use an enumeration for the menu? What are the advantages, and other approaches?
Because enumeration can normalize data, no need to repeat definitions during development
advantages: only need to create once, then it can be use everywhere. And it can be easy to achieve global unification 

How is repetition used in the program? What capabilities does this give us?
Repetition is used to get the right input from user.
We can get what we actual need by repetition, even though we input error during process 

How can control flow help increase the capability of our objects?
control flow help increase the capability of objects, for instant:
when object need to do repeat work, it can use while loop;
when object need to make a decision, it can use if/switch;

