# installation
1. download prebuilt binaries;https://nodejs.org/en/download/prebuilt-binaries
2. unzip package;
3. add parameters to path;
4. input `node -v` in cmd to check

# introduction
- node.js is an open-source, cross-platform JavaScript runtime environment
  - develop server application
  - develop tool application
  - develop desktop application
- Node.js uses JavaScript on the server

- compare with PHP and ASP handles a file request:
  - PHP or ASP
    - send the task to computer's file system
    - waits while the file system opens and reads the file
    - returns the content to the client
    - ready to handle the next request
  - node.js handles a file request
    - sends the task to the computer's file system
    - ready to handle the next request
    - when the file system has opened and read the file, the server returns the content to the client
- node.js eliminates the waiting, and simply continues with the next request.
- node.js runs single-threaded, non-blocking, asynchronous programming, which is very memory efficient
