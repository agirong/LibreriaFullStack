namespace Libreria.Backend.Utils
{
    public class GeneralResponseFn
    {
        public static GeneralResponse responseGeneral(int status, string message, object? data) 
        {
            GeneralResponse response = new GeneralResponse();   
            response.Status = status;
            response.Message = message;
            response.Data = data;
            return response;
        }
    }
}
