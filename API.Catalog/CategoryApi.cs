using API.Catalog.Models;
using API.Catalog.Repositories;
using API.Catalog.Services;

namespace API.Catalog
{
    public static class CategoryApi
    {
        public static void CategoryApiConfiguation(this WebApplication app)
        {
            app.MapPost("Category", Add);
            app.MapGet("/Category", GetAsync);
        }
        private static async Task<IResult> Add(Category category, ICategoryService repository)
        {
            try
            {
                await repository.Insert(category);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                Results.Problem(ex.Message);
                throw;
            }
        }
        private static async Task<IEnumerable<Category>>GetAsync(ICategoryService repository)
        {
            try
            {
              var result=  await repository.GetAll();
                return result;
            }
            catch (Exception ex)
            {
                Results.Problem(ex.Message);
                throw;
            }
        }
    }

}
