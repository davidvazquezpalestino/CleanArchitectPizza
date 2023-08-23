using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions.HttpHandlers;
internal class UnauthorizedAccessExceptionHandler :
    IHttpExceptionHandler<UnauthorizedAccessException>
{
    public ProblemDetails Handle(UnauthorizedAccessException exception)
    {
        ProblemDetails ProblemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status401Unauthorized,
            Type = StatusCodes.Status401UnauthorizedType,
            Title = "Acceso no autorizado.",
            Detail = "El recurso solicitado no fue autorizado."
        };

        return ProblemDetails;
    }
}
