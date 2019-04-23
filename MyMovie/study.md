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
partial view 复用view代码
view components 复用 独立组件 独立的逻辑/数据 相当于迷你mvc 不依赖父级view数据 需建立 viewComponents components welcome 类似控制器
前端  
新建 npm  使用npm  
```
<environment include="Development"></environment>开发环境引用 
<environment exclude="Development"></environment>非开发环境引用 
<script src="~/node_modules/vue/dist/vue.min.js" asp-fallback-src="加载失败 本地地址" asp-fallback-test="Vue"></script> src cdn包
css类似 href
```
## 增加继承identity类
需要修改startup,
修改ApplicationDbContext 继承的 IdentityDbContext
然后移除 
```
Remove-Migration -Context ApplicationDbContext
Add-Migration -Context ApplicationDbContext
Update-database -Context ApplicationDbContext
```
然后把所有使用identity 修改

# XSS
_htmlEncoder.Encode  
前台 @Html.Raw()
# CSRF
## 伪造请求
Header 验证

## 传参
按照顺序  
Form   
路由   
QueryString   
传递某些参数
```
IActionResult(Model user)  
```
设置部分不传参
```
public IActionResult([Bind('User',"Name")]Model user)
[BindNerver]
public string UserName{get;set;}
```
设置获取参数的位置
```
FromBody
FromQuery
FromHeader
FromRoute
FromForm
```
实例  
```
public IActionResult(
    [FromQuery]Model user,
    [FromHeader(Name="Accept")] string accept)
```
## 疑问
ModelOnly 实际展现 目测使用很少?