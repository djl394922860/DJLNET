# DJLNET
Web应用开发框架整合

1、基于EntityFramework强耦合在框架内部，个人认为切换ORM实属搞笑，本身EF是支持跨数据库的
2、利用DbContext的延迟加载以及请求生命周期的效果，相当于把生命周期延迟等同于请求管道的生命周期，实现请求内一个数据库实力上下文，
   达到全局事务效果，具体参考 PreRequestManager
3、使用微软Ioc框架Unity实现依赖注入
4、后台UI将会采用 AdminTLE Metronic Ace 都挺好看
5、后续实现基本的 登陆 身份认证 授权 日志 缓存 API
