// using System.Reflection.Metadata;
// using System.Security.Claims;
using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models.Reports;
using Fina.Core.Requests.Reporters;
using Fina.Core.Responses;

namespace Fina.Api.Endpoints.Reports;

public class GetFinancialSummaryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/summary", HandleAsync)
            .Produces<Response<FinancialSummary?>>();

    private static async Task<IResult> HandleAsync(
        // ClaimsPrincipal user,
        IReportHandler handler)
    {
        var request = new GetFinancialSummaryRequest
        {
            UserId = ApiConfiguration.UserId,
        };
        var result = await handler.GetFinancialSummaryReportAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}