namespace CvBuilder.Api.Extensions
{
    public static class MediatorExtension
    {
        public static async Task<IResult> SendCommand<T>(this IMediator mediator, T command)
        {
            var response = await mediator.Send(command!) as ApiResult;

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }
    }
}
