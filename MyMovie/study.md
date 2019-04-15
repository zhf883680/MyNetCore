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
ctor 快速创建构造函数

code First 创建 更新数据库
```
Add-Migration Xxxxx
Update-Database
```
_Layout 模板 可直接新建 搜索layout  
~ 网站根目录 ?绝对路径?  
可有可无项目
```
 @RenderSection("scripts", required: false)
```
_ViewStart.cshtml:  Layout = "~/Views/Shared/_Layout.cshtml"; 开始渲染时候执行的代码  
_ViewImports:  用于写通用的  例如 @using Models  

## 疑问
ModelOnly 实际展现 目测使用很少?