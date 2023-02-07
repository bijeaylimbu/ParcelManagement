namespace com.project.parcel.Common;

public class ResponseMessage
{
    public ResponseMessage( object message, int errorCodes)
    {
               
        Message = message;
        ErrorCodes = errorCodes;
    }
        
    public Object Message { get; set; }
        
    public int ErrorCodes { get; }
}