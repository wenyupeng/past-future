# install JDK
1. search java relevance list
   - yum -y list java* // or yum search jdk
2. install jdk
   - yum install java-1.8.0-openjdk.x86_64
3. check jdk installation correct
   - java -version
4. export java home
   - vi /etc/profile
   - ``` 
      export JAVA_HOME=/usr/lib/jvm/java-1.8.0-openjdk-1.8.0.412.b08-1.el7_9.x86_64/jre/bin/java
      export PATH=$JAVA_HOME/bin:$PATH
      export CLASSPATH=.:$JAVA_HOME/lib/dt.jar:$JAVA_HOME/lib/tools.jar
     ```
5. exist profile and refresh configuration
   - source /etc/profile
````
1. yum default installation path: /usr/lib/jvm
2. install jdk by yum, may be hard to find java home, follow these steps to find java home
   - echo $JAVA_HOME                 // response blank
   - which java                      // `/usr/bin/java` this is a link not directory
   - ls -lrt /usr/bin/java           //  `lrwxrwxrwx 1 root root 22 May  5 11:27 /usr/bin/java -> /etc/alternatives/java`
   - ls -lrt /etc/alternatives/java  // `lrwxrwxrwx 1 root root 73 May  5 11:27 /etc/alternatives/java -> /usr/lib/jvm/java-1.8.0-openjdk-1.8.0.412.b08-1.el7_9.x86_64/jre/bin/java` this is java home
3. echo $JAVA_HOME       //  /usr/lib/jvm/java-1.8.0-openjdk-1.8.0.292.b10-1.el7_9.x86_64/jre/bin/java
4. yum install java-1.8.0-openjdk-devel.x86_64 // install other java command
````

# install maven
- yum -y install maven 
- mvn -v 
````
Apache Maven 3.0.5 (Red Hat 3.0.5-17)
Maven home: /usr/share/maven
Java version: 1.8.0_412, vendor: Red Hat, Inc.
Java home: /usr/lib/jvm/java-1.8.0-openjdk-1.8.0.412.b08-1.el7_9.x86_64/jre
Default locale: en_US, platform encoding: UTF-8
OS name: "linux", version: "3.10.0-693.2.2.el7.x86_64", arch: "amd64", family: "unix"
````

set aliyun images
- vi  /etc/maven/settings.xml
````
<mirror>
      <id>alimaven</id>
      <name>aliyun maven</name>
      <url>http://maven.aliyun.com/nexus/content/groups/public/</url>
      <mirrorOf>central</mirrorOf>       
</mirror>
````