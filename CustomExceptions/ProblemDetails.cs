namespace CustomExceptions;
public class ProblemDetails
{
    public int Status { get; init; }
    public string Type { get; init; }
    public string Title { get; init; }
    public string Detail { get; init; }
    public Dictionary<string, List<string>> InvalidParams { get; init; }

    //public ProblemDetails(int status,
    //    string type, string title,
    //    string detail, Dictionary<string,
    //    List<string>> invalidParams)
    //{
    //    Status = status;
    //    Type = type;
    //    Title = title;
    //    Detail = detail;
    //    InvalidParams = invalidParams;
    //}
}
