# 项目说明
一个酒店管理项目，具体技术栈如下：
服务发现与服务注册：`dubbo` + `zookeeper`
服务鉴权：`Spring Security` + `Oauth2`
接口层：`Spring MVC`
应用支持：`Spring Boot`
缓存：`Redis`
消息队列：`Rabbit MQ`
持久层：`Mybatis plus`
数据库：`Mysql`

# 收获与感悟
很感谢当时那些指导我排查bug的大佬，这份工作中我主要负责APP端的登录、客户信息管理、租房信息维护、还有第三方支付，主要在单点登录和第三方支付这两个模块上学到了新东西。单点登录现在已经是很普通的内容，但是在当时还是很新的，那时候用`JWT`的系统都不多。主要还是第三方支付模块设计，这个异步回调确认对当时的我来说还是有少少震撼（也是在这时候开始知道内网穿透，嘿嘿）。

持久化框架

---
one of my experience is about the hotel management, use dubbo and zookeeper as Service discovery and service registration, use spring security and Oauth2 as Service authentication
Spring MVC as the interface, spring boot as the container, redis as the cache and distribute lock, rabbit mq as the message queue to decouple the relationship between business, mybatis plus as the persistence framework, And we use mysql as the database














