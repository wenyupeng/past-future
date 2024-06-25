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


我曾作为中级Java工程师在恒大集团（曾是中国最大的房地产公司）开发并维护系统
我在恒大参与的第一个项目是恒大酒店管理系统，主要帮助集团管理酒店资源，酒店服务，包含工程管家，运营管理，客房管家，配置管理，系统管理等。
我参与的第二个系统是恒大公寓APP，主要帮助恒大集团管理公寓物资，公寓服务。
我们团队有16个人，两个项目经理，三个后台高级开发工程师，三个后台中级工程师，四个前端工程师，四个测试工程师。
我的主要工作贡献如下：
1. 完成项目二期的酒店资产模块、支付接口（第三方支付）、用户登录等；
2. 完成项目三期的布草酒水模块、房源信息模块；
在项目开发期间，我按时按质交付代码，完善开发设计文档，并帮助其他工程师解决开发问题
工程
I worked as an intermediate Java engineer to develop and maintain systems at Evergrande Group (Evergrande Group, once the largest real estate company in China). 
The first project I participated in at Evergrande was the Evergrande Hotel Management System, which mainly helped the group manage hotel resources and hotel services. 
Including engineering housekeeper, operation management, guest room housekeeper, configuration management, system management, etc. The second system I participated in is the Evergrande Apartment APP, which mainly helps Evergrande Group manage apartment materials and apartment services. Our team has 16 people, two project managers, three back-end senior development engineers, three back-end mid-level engineers, four front-end engineers, and four test engineers. My main work contributions are as follows: 1. Completed the hotel asset module, payment interface (third-party payment), user login, etc. in the second phase of the project; 2. Completed the linen and beverage module, housing information module in the third phase of the project; In project development During this period, I delivered code on time and with high quality, improved development design documents, and helped other engineers solve development problems.












