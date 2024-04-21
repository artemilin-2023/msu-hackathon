using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WorkShare.Application.Services;
using WorksShare.API.Contracts;

namespace WorksShare.API.Controllers
{
    [Route("/api/v1/works")]   
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly WorkServices workServices;
        private readonly AccessService accessService;

        public WorkController(WorkServices workServices, AccessService accessService)
        {
            this.workServices = workServices;
            this.accessService = accessService;
        }

        [HttpPost]
        public async Task<IResult> Post([FromForm] PostWorkRequest request)
        {
            if (!ModelState.IsValid)
                return Results.BadRequest();

            var token = Request.Headers[AccessService.TokenName];
            if ((string)token == null)
                return Results.Forbid();

            var userId = await accessService.GetUserIdAsync(token);

            await workServices.AddWorkAsync(request.Hierarchy.Course, 
                request.Hierarchy.WorkType, request.Hierarchy.Subject, 
                request.Name, request.Files, userId);
            return Results.Ok();
        }

        [HttpGet]
        public async Task<IResult> GetAll([FromQuery] Filters query)
        {
            if (!ModelState.IsValid)
                return Results.BadRequest();

            var result = await workServices
                .GetAllWorksAsync(query.Course, query.Name, query.Subject, query.WorkType, query.Limit);
            return Results.Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IResult> Get([Required] Guid id)
        {
            if (!ModelState.IsValid)
                return Results.BadRequest();

            var result = await workServices.GetWorkAsync(id);
            return Results.Ok(result);
        }

        [HttpGet("search")]
        public async Task<IResult> GetByQuery([FromQuery] string query)
        {
            if (!ModelState.IsValid)
                return Results.BadRequest();

            var result = await workServices.GetAllByQueryAsync(query);
            return Results.Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete([Required] Guid id)
        {
            if (!ModelState.IsValid)
                return Results.BadRequest();

            var token = Request.Headers[AccessService.TokenName];
            if (!await accessService.HasAccessAsync(token, id))
                return Results.Forbid();

            await workServices.RemoveAsync(id);
            return Results.Ok();
        }

    }
}
