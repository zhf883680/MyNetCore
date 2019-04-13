# 学习记录
## mysql EFCore
```
Microsoft.EntityFrameworkCore
Pomelo.EntityFrameworkCore.MySql
从数据库生成模型安装以下包
Microsoft.EntityFrameworkCore.Tools
```
```
//注册mysql服务
services.AddDbContext<Models.lmdsContext>(options =>
{
options.UseMySql(Configuration["LmdsConnection"]);
});
```
## 笔记
尽量使用
```
nameof(error) 页面跳转或者其他 方便重构
```
