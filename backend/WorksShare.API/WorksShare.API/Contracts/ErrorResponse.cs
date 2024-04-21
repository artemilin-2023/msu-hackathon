namespace WorksShare.API.Contracts
{
    public class ErrorResponse
    {
        public string Message { get; set; }

        public ErrorResponse(string message = "Ошибка в параметрах, указанных в запросе")
        {
            Message = message;
        }
    }
}
