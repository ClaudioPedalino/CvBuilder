namespace CvBuilder.Api.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public IMediator Mediator { get; set; }

        public BaseController(IServiceProvider serviceProvider)
        {
            Mediator = serviceProvider.GetRequiredService<IMediator>();
        }
    }
}
