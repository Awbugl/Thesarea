# Thesarea
Project Thesarea, an Arcaea bot project based on go-cqhttp and Sora.

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

#### 搭建方法
* 下载 [go-cqhttp](https://github.com/Mrs4s/go-cqhttp/releases "go-cqhttp")
* 下载 [Thesarea](https://github.com/Awbugl/Thesarea/releases "Thesarea")
* 配置IP、端口、Bot账号密码、ApiToken等

#### 常见问题
+ Q:  什么是ArcaeaLimitedApi？如何申请ApiToken？
A:  请移步[Arcaea Limited API 的相关信息及申请方法](https://www.bilibili.com/read/cv14491110 "Arcaea Limited API 的相关信息及申请方法")查看。


+ Q:  用户信息在哪里存储？是否有信息泄漏风险？
A:  Bot只会在本地的数据库中存储Arc绑定信息，不会上传到云端服务器，与此同时绑定也只能使用Arc9位UID。


+ Q:  为什么Bot无法查分？
A:  请检查您的Bot是否超过了ArcaeaLimitedApi的限额，即
      每日请求数限额  2000/d;
      分钟请求数限额  120/min;
      每日用户限额 100 个账户;

+ Q:  配置文件时出现了问题/无法访问Github下载文件？
A:  可加入QQ群 191234485 ，提供文件副本下载及问题解答。

