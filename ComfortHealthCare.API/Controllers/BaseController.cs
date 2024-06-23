using DataLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComfortHealthCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, Trepository> : ControllerBase
    where TEntity : class, IEntity
    where Trepository : IRepository<TEntity>
    {
        private readonly Trepository repository;
        public BaseController(Trepository repository)
        {
            this.repository = repository;
        }

    }
}
