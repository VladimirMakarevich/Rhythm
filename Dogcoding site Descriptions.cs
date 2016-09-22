Опишу немного сам сайт, из чего он сделан, какие расширения я использовал, какие недочеты есть в сайте, где какой кастыль был применен.
Строго не судите, так как это мой первый полноценный проект который я сделал с нуля. За исключением конечно же front end (хотя и тут пришлось подогнать многое под себя). Сам шаблон сайта был взят (тут ссылка).
Все исходные материалы вы можете скачать в конце статьи. Можно пользоваться, изучать, капировать. Думаю для тех кто только начинает, как и я, будет интересно поизучать.
Я не буду детально описывать, что, зачем и почему и откуда взялось. В кратце пробегусь, какие библиотеки я использовал, и почему именно их. Для более детального понимания, к каждой библиотеке буду прикреплять несколько ссылок, если кто то захочет лучше понять всю кухню. 


Начнем с ninject.
Ninject: 
Ninject - это IoC контейнер. Помимо Ninject, существуют такие контейнеры, как: Castle Windsor, Autofac, Unity и еще много разный вариантов. IoC контейнеры испрользуются для внедрения зависимостей. При помощи данного подхода, мы явно разделяем все наши зависимости, блогадаря чему можно лучше/проще протестировать наш код. Мы также избегаем конкретных реализаций и работаем с объектами на уровне интерфейсов.
Установить можно Ninject через NuGet Packages. 

Создаем фабрику контроллеров:
public class NinjectControllerFactory : DefaultControllerFactory
{
    private IKernel ninjectKernel;
    public NinjectControllerFactory()
    {
        ninjectKernel = new StandardKernel();
        AddBindings();
    }
 
    protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
    {
        return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
    }
 
    private void AddBindings()
    {
        ninjectKernel.Bind<IRepository>().To<EfRepository>();
    }
}

Больше о Ninject можно читануть на GitHub. (https://github.com/ninject/ninject/wiki)

--------------------------------------------------------------------------------------

Работа с базой данных.
Я использовал Ef и подход Database First:
Вот тут было бы логичнее наверное использовать все таки Code First. Но мне хотелось еще и поиграться с MS SQL и непосредственно с самим языком SQL. Сам script для SQL можно посмотреть в проекте, папка SQL.
В качестве БД я использовал MSSQL 2014.
В качестве источников для дополнительного чтива, мне кажется достаточно будет просто почитать на официальном сайте, вот тут (https://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application)
Тут и про DB first можно почитать и про Code first.

--------------------------------------------------------------------------------------

Automapper:
Automapper позволяет проецировать одну модель  на другую, что позволяет сократить объемы кода и упростить саму программу.

public static class MappingConfig
{
    public static MapperConfiguration MapperConfigCategory;
    public static MapperConfiguration MapperConfigTag;
    public static MapperConfiguration MapperConfigComment;
    public static MapperConfiguration MapperConfigPost;
 
    public static void RegisterMapping()
    {
        MapperConfigCategory = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category, CategoryViewModel>().ReverseMap();
        });
        MapperConfigTag = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Tag, TagViewModel>().ReverseMap();
        });
        MapperConfigComment = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Comment, CommentViewModel>().ReverseMap();
        });
        MapperConfigPost = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Post, PostViewModel>().ReverseMap();
        });
    }
}

Регестрируем в Global.asax:
 
 MappingConfig.RegisterMapping();

Ну а сама реализация в контроллере :

 IMapper model = MappingConfig.MapperConfigPost.CreateMapper();
 Post context = model.Map<Post>(post);

И все. И получаем готовую мродель со всем данными. Если в ручную инициализировать все свойства этих моделей, пришлось бы в методе контроллера, прописывать от 6 до 14 строчек. Лень... она такая :)



--------------------------------------------------------------------------------------

Identity: 
Про Identity и так много что написано в сети. Поэтому я не буду описывать как я реализовывал сие чудо. Единственное что отмечу, что я не стал реализовывать полный функционал этой технологии. Так как нету в этом необходимости. Да и прописав самостоятельно только тот участок кода, что тебе нужно, лучше начинаешь понимать как оно устроена. Вот тут, можно вникнуть в суть аутентификации в ASP.NET MVC.
(https://habrahabr.ru/post/227351/)
И на официальном сайте (http://asp.net)



--------------------------------------------------------------------------------------

NLog:
(http://nlog-project.org/)
Данная технология позволяет протоколировать, отлавливать исключения и записывать в необходимую БД или XML. А можно просто в txt формате. Устанавливать в проект как и все остальное, через NuGet, следующей командой в консоли:

Install-Package NLog

Далее пользуемся документацией но NLog (http://nlog-project.org/wiki/Tutorial).

В NLog.config настраиваем небходимый функционал, запись в MS SQL, прописываем следующее:
...
  <targets>
    <!-- file targets -->
    <target name="asyncFile" xsi:type="AsyncWrapper">
      <target xsi:type="File" name="f" fileName="${basedir}/Logs/${shortdate}.log"
            layout="${longdate} ${uppercase:${level}} ${message} ${aspnet-user-identity}"/>
    </target>
 
    <!-- database targets -->
    <target name="database" xsi:type="Database" keepConnection="true" useTransactions="true"
             dbProvider="System.Data.SqlClient"
             connectionString="Data source=HOME_STUDIO\SQLEXPRESS;initial catalog=DogCoding;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;"
             commandText="INSERT INTO [log].[Logger](EventDateTime, EventLevel, UserName, MachineName, EventMessage, ErrorSource, ErrorClass, ErrorMethod, ErrorMessage, InnerErrorMessage) VALUES (@EventDateTime, @EventLevel, @UserName, @MachineName, @EventMessage, @ErrorSource, @ErrorClass, @ErrorMethod, @ErrorMessage, @InnerErrorMessage)">
      <!-- parameters for the command -->
      <parameter name="@EventDateTime" layout="${date:s}" />
      <parameter name="@EventLevel" layout="${level}" />
      <parameter name="@UserName" layout="${aspnet-user-identity}" />
      <parameter name="@MachineName" layout="${machinename}" />
      <parameter name="@EventMessage" layout="${message}" />
      <parameter name="@ErrorSource" layout="${event-context:item=error-source}" />
      <parameter name="@ErrorClass" layout="${event-context:item=error-class}" />
      <parameter name="@ErrorMethod" layout="${event-context:item=error-method}" />
      <parameter name="@ErrorMessage" layout="${event-context:item=error-message}" />
      <parameter name="@InnerErrorMessage" layout="${event-context:item=inner-error-message}" />
    </target>
  </targets>
  <rules>
...
</nlog>

В web.config прописываем вот это:
<configuration>
  <configSections>
  ...
    <section name="nlog" type="NLog.Config.ConfigSectionHandler, NLog" />
  ...
  </configSections>
</configuration>

Далее в коде, создаем новый экземпляр:
private static NLog.Logger logger = LogManager.GetCurrentClassLogger();

И в блоке try/catch ловим ошибки:
catch (Exception ex)
{
    logger.Error("Faild in PostController ActionResult Post [HttpPost]: {0}", ex.Message);
}

Помимо метода Error нам также доступны и другие методы:
    logger.Trace("Sample trace message, ...");
    logger.Debug("Sample debug message, ...");
    logger.Info("Sample informational message, ...}");
    logger.Warn("Sample warning message, ...");
    logger.Error("Sample error message, ...");
    logger.Fatal("Sample fatal error message, ...");
    logger.Log(LogLevel.Info, "Sample informational message, ...");

И таким образом мы получаем запись в базу данных всех наших ошибок, которые мы отлавливаем. 
С NLog я не стал сильно заморачиваться, так как следующее что я хотел попробовать внедрить в проект, это ELMAH.
Хотя вот тут есть интересная статья по использованию NLog. И при желании можно многое сделать с его помощью.


--------------------------------------------------------------------------------------

ELMAH:
(https://code.google.com/p/elmah/) <------- Сюда>
Огромные возможности при минимальных затратах, и много хорошей документации в придачу.
Утанавливаем следующей командой: Install-Package Elmah

Скачиваем SQL script тоже через NuGet: Install-Package elmah.sql
И запускаем скрипт в нашей БД, что бы создать необходимую таблицу

Ограничиваем доступ к просмотру наших ошибок:
      <authorization>
        <allow roles="admin" />
        <deny users="*" />
      </authorization>

а так же устанавливаем true в security 
    <security allowRemoteAccess="true" />

Далее добавляем строку подключения к базе данных.
    <errorLog type="Elmah.SqlErrorLog, Elmah" connectionStringName="DogCoding"/>

Прописываем фильтр:
    <errorFilter>
          <test>
                <jscript>
                      <expression>
                            <![CDATA[
                // @assembly mscorlib
                // @assembly System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
                // @import System.IO
                // @import System.Web
 
                HttpStatusCode == 404
                || BaseException instanceof FileNotFoundException
                || BaseException instanceof HttpRequestValidationException
                /* Using RegExp below (see http://msdn.microsoft.com/en-us/library/h6e2eb7w.aspx) */
                || Context.Request.UserAgent.match(/crawler/i)
                || Context.Request.ServerVariables['REMOTE_ADDR'] == '127.0.0.1' // IPv4 only
                ]]>                 
          </expression>       
        </jscript>      
      </test>
    </errorFilter>
    
Для того что бы отобразить пользователю соответствующие ошибки пропишим следующее:

В Global.asax, который будет отвечать за показ специальных View с кодом ошибок для пользователя:
protected void Application_Error(object sender, EventArgs e)
{
    var httpContext = ((MvcApplication)sender).Context;
    var ex = Server.GetLastError();
    var status = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
 
    // Is Ajax request? return json
    if (httpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
    {
        httpContext.ClearError();
        httpContext.Response.Clear();
        httpContext.Response.StatusCode = status;
        httpContext.Response.TrySkipIisCustomErrors = true;
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.Write("{ success: false, message: \"Error occured in server.\" }");
        httpContext.Response.End();
    }
    else
    {
        var currentController = " ";
        var currentAction = " ";
        var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
 
        if (currentRouteData != null)
        {
            if (currentRouteData.Values["controller"] != null &&
            !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
            {
                currentController = currentRouteData.Values["controller"].ToString();
            }
            if (currentRouteData.Values["action"] != null &&
            !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
            {
                currentAction = currentRouteData.Values["action"].ToString();
            }
        }
 
        var controller = new ErrorController();
        var routeData = new RouteData();
 
        httpContext.ClearError();
        httpContext.Response.Clear();
        httpContext.Response.StatusCode = status;
        httpContext.Response.TrySkipIisCustomErrors = true;
 
        routeData.Values["controller"] = "Error";
        routeData.Values["action"] = status == 404 ? "NotFound" : "Index";
 
        controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
        ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
    }
}

Потом создаем контроллер ErrorController, там метод действия NotFound и Index.
И к этим действиям свои представления.

--------------------------------------------------------------------------------------

CKeditor и расширение для MVC:
Это расширение для оформления контента. Почти как Word.
Устанавливается через NuGet Packages

Что бы подключить, нужно в представлении прописать следующий скрипт:
@section scripts {
    <script src="~/Scripts/ckeditor/ckeditor.js"></script>
    <script>
        var editor = CKEDITOR.instances['ShortDescription'];
        if (editor) { editor.destroy(true); }
        CKEDITOR.replace('ShortDescription', { enterMode: CKEDITOR.ENTER_BR, });
    </script>
}

Где:
['DescriptionPost']
- это имя нашего ХТМЛхелпера, который ответственный за содержание нашего поста.

@Html.TextAreaFor(m => m.Description, new { @name = "Description", @id = "Description", @class = "input-md round form-control", @style = "height: 84px;", @placeholder = "Description" })

+ Расширение к CKeditor для MVC
Cтраничка GitHub нашего расширения, что бы можно было загружать фотографии: (http://github.com/mcm-ham/ckeditor-image-uploader)

Вот официальный сайт CKeditor: (http://ckeditor.com/)

--------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------



***Заключение***
Из основных недачетов которые тут есть, это отсутствие тестов. Да, это про*б :). Но в дальнейшем я планирую покрыть основные участки кода тестами. (лучше позже чем никогда
Следующие что тут держится на кастыле, это jQuery и AJAX. Отправка форм и валидация на стороне клиента. Либо у меня руки не из того места, либо что то намудрили разработчики шаблона сайта с JavaScript. Потому что я так и не смогу разобраться как внедрить в код нармальную валидацию и отправку форм на сервер.
И последнее о чем пожалел. Это то, что не сразу документировал весь код. Но это тоже исправиться. :)

На этом все наверное. По возможности буду улучшать, развивать и дописывать проект. Буду рад любым вашим комментариям и замечаниям. И незабываем про критику, буду рад услышить :).