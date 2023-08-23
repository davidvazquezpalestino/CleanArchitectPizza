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
        var SB = new StringBuilder();
        if(exception != null)
        {
            if(exception is ProblemDetailsException Ex)
            {
                SB.Append("<div style='margin-bottom:1rem;word-break:break-all;overflow-y:auto;'>");
                SB.Append($"{Ex.ProblemDetails.Detail}</div>");
                if(Ex.ProblemDetails.InvalidParams != null)
                {
                    foreach(var Error in Ex.ProblemDetails.InvalidParams)
                    {
                        SB.Append($"<div>{Error.Key}</div>");
                        SB.Append("<ul>");
                        foreach(var Message in Error.Value)
                        {
                            SB.Append($"<li>{Message}</li>");
                        }
                        SB.Append("</ul>");
                    }
                }
            }
            else
            {
                if(exception.Data.Count > 0)
                {
                    SB.Append("<ul>");
                    foreach(DictionaryEntry Item in exception.Data)
                    {
                        SB.Append($"<li>{Item.Key}: {Item.Value}</li>");
                    }
                    SB.Append("</ul>");
                }
            }
        }
        return SB.ToString();
    }
}
