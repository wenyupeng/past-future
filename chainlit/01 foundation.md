# initial 
## install python
I recommend that install python by installer(choose custom install), so you don't need to install pip by yourself.
[download](https://www.python.org/downloads/windows/)

## download IDE and project
I use PyCharm 2024.1 (Professional Edition) and it's easy to get project from vcs

## pip install chainlit
this is the demo to tell you environment is ok
1. `pip install chainlit`
2. `chainlit hello`

[project_resource](https://docs.chainlit.io/get-started/installation)

## receive msg from user input
- create a file `app.py` to write you application logic
````
import chainlit as cl

@cl.on_message
async def main(message: cl.Message):
    # Your custom logic goes here...

    # Send a response back to the user
    await cl.Message(
        content=f"Received: {message.content}",
    ).send()
````

- chainlit run app.py -w 
run your application, receive msg from UI

