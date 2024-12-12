using SuperHeroDatabase;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroRoutes{
	public static class SuperPowerRoutes{
		public static void AddSuperPower(this WebApplication app){
			var superPowerGroup = app.MapGroup("superpower");

			superPowerGroup.MapGet("", async (SHDatabase context, CancellationToken ct) =>
			{
				var superPower = await context.SuperPowerDB.ToListAsync(ct);
				return Results.Ok(superPower);
			});
		}
	}
}

