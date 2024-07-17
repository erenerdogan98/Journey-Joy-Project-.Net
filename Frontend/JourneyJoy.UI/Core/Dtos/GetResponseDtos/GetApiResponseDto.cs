namespace JourneyJoy.UI.Core.Dtos.GetResponseDtos
{
    public record GetApiResponseDto<T>(T Data, bool Success, string Message, int statusCode, Dictionary<string, List<string>> Errors = null)
    {

    }
}
