namespace APIAssignment1.Model
{
    public class ResponseHandler
    {
        public static ApiResponse GetExceptionResponse(Exception ex)
        {
            ApiResponse response = new ApiResponse();
            response.Code = "1";
            response.ResponseData = ex.Message;
            return response;
        }
        public static ApiResponse GetAppResponse(ResponseType type, object? contract)
        {
            ApiResponse response;

            response = new ApiResponse { ResponseData = contract };
            switch (type)
            {
                case ResponseType.Success:
                    response.Code = "200";
                    response.Message = "Success";

                    break;
                case ResponseType.NotFound:
                    response.Code = "404";
                    response.Message = "Key does not exist";
                    break;
                case ResponseType.Conflict:
                    response.Code = "409";
                    response.Message = "Key already exist";
                    break;
            }
            return response;
        }
    }
}

