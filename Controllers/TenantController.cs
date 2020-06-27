using Microsoft.AspNetCore.Mvc;
using FluentMigratorDemo.Model;
using FluentMigratorDemo.Services;

namespace FluentMigratorDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService) {
            _tenantService = tenantService;
        }

        [HttpPost]
        public void Create(Tenant tenant)
        {
            _tenantService.Create("dev_1");
        }
    }
}