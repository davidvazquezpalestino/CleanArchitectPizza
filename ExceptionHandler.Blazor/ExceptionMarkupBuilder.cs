using CustomExceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandler.Blazor;
public class ExceptionMarkupBuilder
{
    public static string Build(Exception exception)
    {
        StringBuilder? sb = new StringBuilder();
        if(exception != null)
        {
            if(exception is ProblemDetailsException ex)
            {
                sb.Append("<div style='margin-bottom:1rem;word-break:break-all;overflow-y:auto;'>");
                sb.Append($"{ex.ProblemDetails.Detail}</div>");
                if(ex.ProblemDetails.InvalidParams != null)
                {
                    foreach(var error in ex.ProblemDetails.InvalidParams)
                    {
                        sb.Append($"<div>{error.Key}</div>");
                        sb.Append("<ul>");
                        foreach(var message in error.Value)
                        {
                            sb.Append($"<li>{message}</li>");
                        }
                        sb.Append("</ul>");
                    }
                }
            }
            else
            {
                if(exception.Data.Count > 0)
                {
                    sb.Append("<ul>");
                    foreach(DictionaryEntry item in exception.Data)
                    {
                        sb.Append($"<li>{item.Key}: {item.Value}</li>");
                    }
                    sb.Append("</ul>");
                }
            }
        }
        return sb.ToString();
    }
}
