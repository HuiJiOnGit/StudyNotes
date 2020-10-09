# dotnet core 3.1在控制台使用依赖注入，logger和configuration

1. 添加`IServiceCollection`

   ```c#
   //会用上的命名空间
   using Microsoft.Extensions.DependencyInjection;
   IServiceCollection services = new ServiceCollection();
   // 然后就可以像在asp.net core 里面的 注入了
   ```

   

2. 创建`servicesProvider`实列

   ```c#
   //创建服务
    var servicesProvider = services.BuildServiceProvider();
   ```

   

3. 在控制台中获取注入

```c#
var airServices = servicesProvider.GetService<AirWalkServices>();
```

4. 在其他文件中注入和asp.net core同理，在构造函数中注入即可
5. 使用log

```c#
//启用日志,记得是在创建servicesProvider实列之前
services.AddLogging(builder => builder.AddConsole());
//使用logger
var logger = servicesProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
logger.LogInformation("start app");
//其他文件中使用直接注入即可
```

> 注意，这里的 `builder.AddConsole()`可能垃圾VS没有提示，需要安装这个包
>
> `Microsoft.Extensions.Logging.Console`

如果需要使用其它log，把log记录到日志，数据库，建议使用第三方log

> 例子：https://mp.weixin.qq.com/s/rg3JbwPY7zNx6UPKEBIIuA

6. 使用config

需要引用这个几个包，VS大概率又又又没提示

>     Microsoft.Extensions.Configuration.FileExtensions
>     Microsoft.Extensions.Configuration.Json

```c#
IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
 services.AddSingleton(configuration);
//Directory.GetCurrentDirectory()这个方法根据微软文档的说法，如果是windows服务的程序，获取的是c盘system文件夹，暂时找不到链接了
```

使用同直接注入就行

```c#
private readonly IConfiguration _configuration;
public Class1(IConfiguration configuration)
{
    _configuration = configuration;
}
```

同理也可以使用其他的json文件

```c#
IConfiguration tempConfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("你的json文件")
                    .Build();
//然后我把它注入到了这个TemplateDto类
services.Configure<TemplateDto>(tempConfig);
```

调用

```c#
private readonly IOptions<TemplateDto> _options;
public Class1(IOptions<TemplateDto> options)
{
    _options = options;
}
```

以上，完成

2020-10-9 10:48 第一版