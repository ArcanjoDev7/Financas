using Microsoft.VisualBasic;

namespace Financas.Aplication.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void Setup(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(Constants.CORS_NAME);
            if (app.Environment.IsDevelopment())
            {
                // app.UseHttpsRedirection();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseStaticFiles();
            app.UseResponseCompression();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
