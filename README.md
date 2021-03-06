# Creekdream AspNetCore 框架
Creekdream AspNetCore 致力于打造原生、简洁、清晰化结构的 .NET CORE 项目架构设计，在组件以及框架的封装尽可能遵从 .NET CORE 的设计理念。

## 框架特点

框架吸收了 [**ABP**](https://github.com/aspnetboilerplate/aspnetboilerplate) 等一些开源框架的优秀设计，由于近几年微服务盛行，框架设计原则尽可能从简单、易用。
在模块化设计上尽可能独立，在核心类库上尽可能减少依赖，致力打造干净、整洁、易理解、快速开发的友好体验。

## 应用架构图

![image](doc/images/app-arc.png)

## 框架特性

**框架基础核心模块：**
* [快速搭建新项目](doc/QuickStart.md)
* [依赖注入](doc/Dependency.md)：Autofac、Castle.Windsor
* [模块化](doc/Module.md)
* [Model映射](doc/Mapping.md)：AutoMapper
* [ORM](doc/Orm.md)：EntityFrameworkCore、Dapper支持主流数据库
* [工作单元支持](doc/UnitOfWork.md)
* [AOP切面拦截器](doc/Aop.md)
* [单元测试](doc/UnitTest.md)：xunit

**框架独立模块**

不依赖项目框架，独立模块有自己的核心接口层，可自行根据不同需求多实现。
* [缓存模块](https://github.com/zengqinglei/Creekdream.Cache)：Redis、MemoryCache
* [消息队列](https://github.com/zengqinglei/Creekdream.RabbitMQ)
* [Apollo配置中心](https://github.com/zengqinglei/Creekdream.Configuration.Apollo)
* [Consul服务中心](https://github.com/zengqinglei/Creekdream.Discovery.Consul)

## 框架示例及模板

* [快速创建项目模板](https://github.com/zengqinglei/Creekdream.AspNetCore.Template)
* [EntityFrameworkCore 的简单示例项目](https://github.com/zengqinglei/Creekdream.SimpleDemo)
* [Dapper 的简单示例项目](https://github.com/zengqinglei/Creekdream.SimpleDemo/tree/dapper)

框架示例领域驱动分层：
* 应用层
* 核心领域层
* 仓储层
* UI层

## 微服务独立项目
* [API网关](https://github.com/zengqinglei/Creekdream.ApiGateway)(Ocelot + Consul + Skywalking)
* [IdentityServer4 认证授权项目](https://github.com/zengqinglei/FabricDemo)

## 微服务架构图

![image](doc/images/mic-service-arc.png)

## 参与贡献
1. Fork Creekdream.AspNetCore 开源框架
2. 新建 feature-\{tag} 分支
3. 完成功能并提交代码
4. 新建 Pull Request

[**更新日志**](https://github.com/zengqinglei/Creekdream.AspNetCore/releases)
