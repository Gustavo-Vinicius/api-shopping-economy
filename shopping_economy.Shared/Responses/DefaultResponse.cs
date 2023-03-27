namespace shopping_economy.Shared.Responses
{
    public class DefaultResponse
    {
          public DefaultResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}