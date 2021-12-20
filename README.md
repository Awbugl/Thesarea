# Thesarea

使用.Net6.0，基于Sora与go-cqhttp的Arcaea查分QQBot

----

#### 功能

> /a

> /a bind

> /a info

> /a b30

##### * 由于ArcaeaLimitedApi的限制，不提供图片查分，敬请谅解。

----

#### 感谢

* 本项目的数据来源于ArcaeaLimitedApi与AndreaBotDB。

#### 部署方法
* 向lowiro写邮件申请ApiToken（详见 **常见问题**-**什么是ArcaeaLimitedApi？如何申请ApiToken？**）
* 下载 [go-cqhttp](https://github.com/Mrs4s/go-cqhttp/releases "go-cqhttp")
* 下载 [Thesarea](https://github.com/Awbugl/Thesarea/releases "Thesarea")
* 配置IP、端口、Bot账号密码、ApiToken等（详细教程日后补上）

#### 常见问题

+ Q: **什么是Thesarea？**
A: 基于ArcaeaLimitedApi和AndreabotDB的开源ArcBot项目，**Thesarea** = **thes**eus + **ar**caea + andr**ea**。

+ Q: **为什么要开发Thesarea？**
A: Lowiro的每一次加密算法更新都会导致大多数Arc查分Bot依赖的BotArcApi停止运行一段时间，需要时间和人力去解码和更新。目前（2021/10/20），BAA由于技术原因暂时还未完全恢复服务。为了让一些QQ群可以得到属于自己的可用的查分服务（虽然这受制于Lowiro），我们开发了Thesarea。

+ Q: **什么是ArcaeaLimitedApi？如何申请ApiToken？**
A: Lowiro为开发者提供的官方查分接口，详情可移步 [ArcaeaLimitedAPI 的相关信息及申请方法](https://www.bilibili.com/read/cv14491110 "ArcaeaLimitedAPI 的相关信息及申请方法") 查看。

+ Q: **我部署Thesarea会得到什么？**
A: 得到属于自己的可用的Arc查分Bot。

+ Q: **使用Thesarea有何限制？**
A: 除了违法行为与盈利行为以外，您可以任意应用这份开源项目。

+ Q: **用户信息在哪里存储？**
A: Thesarea只会在本地的数据库中存储Arc绑定信息，不会上传到云端服务器，但也导致绑定只能使用Arc9位UID。

+ Q: **想要自己部署Thesarea需要具备什么知识？部署在哪里？**
A: 按照教程/指北逐步操作即可；可部署在您的电脑，或您自行租赁的云服务器上。

+ Q:  **为什么部署之后Bot无法查分？**
A:  请检查
> 您是否正确配置了所有配置项
> 您是否申请并正确填写了ApiToken
> 您的Bot是否超过了ArcaeaLimitedApi的限额，即
       每日请求数限额  2000/d;      分钟请求数限额  120/min;      每日用户限额 100 个账户;

+ Q:  **配置文件时出现了问题/无法访问Github下载文件？**
A:  可加入QQ群 191234485 ，提供文件副本下载及问题解答。

