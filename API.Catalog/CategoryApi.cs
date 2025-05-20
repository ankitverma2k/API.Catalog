using API.Catalog.Models;
using API.Catalog.Repositories;
using API.Catalog.Services;

namespace API.Catalog
{
    public static class CategoryApi
    {
        public static void CategoryApiConfiguation(this WebApplication web)
        {
            web.MapPost("Category", Add);
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
    }

}
