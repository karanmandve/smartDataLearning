using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace TrainningSessionExamples
{
    //public class RoleRequirementHandler
    //{
    //}
    public class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if (context.User.IsInRole(requirement.Role))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
    
}
