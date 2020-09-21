using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Sofa.Web.Middleware
{
	public class EnableRewindableBodyStartup
	{
		private readonly RequestDelegate _next;

		public EnableRewindableBodyStartup(RequestDelegate next) => _next = next;

		public async Task InvokeAsync(HttpContext httpContext) => await RewindBodyStreamAndNext(httpContext, _next);

		private async Task RewindBodyStreamAndNext(HttpContext context, RequestDelegate next)
		{
			context.Request.EnableBuffering(); // extension method in `Microsoft.AspNetCore.Http.Internal` .EnableRewind()
			await next(context);
		}
	}
}
