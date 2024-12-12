using SuperHeroDatabase;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroRoutes{
	public static class Routes{
		public static void AddSuperHero(this WebApplication app)
		{
			var superHeroGroup = app.MapGroup("superhero");

			/****** GET Method ******/
			superHeroGroup.MapGet("", async (SHDatabase context, CancellationToken ct) =>
			{
				var superHeroes = await context.SuperHeroDB
					.Include(hero => hero.HeroesSuperPowers)
					.ThenInclude(hsp => hsp.SuperPower)
					.Select(hero => new SuperHeroDTO{
						Id = hero.Id,
						Name = hero.Name,
						HeroName = hero.HeroName,
						BirthDate = hero.BirthDate,
						Height = hero.Height,
						Weight = hero.Weight,
						SuperPowerIds = hero.HeroesSuperPowers.Select(hsp => hsp.SuperPowerId).ToList(),
						SuperPowerName = hero.HeroesSuperPowers.Select(hsp => hsp.SuperPower.Name).ToList()
					})
					.ToListAsync(ct);

				if (!superHeroes.Any())
					return (Results.NotFound("Hmmm, maybe you should add a SuperHero."));

				return (Results.Ok(superHeroes));
			});
			
			superHeroGroup.MapGet("/{id}", async (Guid id, SHDatabase context, CancellationToken ct) =>
			{
				var superHeroes = await context.SuperHeroDB
					.Include(hero => hero.HeroesSuperPowers)
					.ThenInclude(hsp => hsp.SuperPower)
					.Where(hero => hero.Id == id)
					.Select(hero => new SuperHeroDTO{
						Id = hero.Id,
						Name = hero.Name,
						HeroName = hero.HeroName,
						BirthDate = hero.BirthDate,
						Height = hero.Height,
						Weight = hero.Weight,
						SuperPowerIds = hero.HeroesSuperPowers.Select(hsp => hsp.SuperPowerId).ToList(),
						SuperPowerName = hero.HeroesSuperPowers.Select(hsp => hsp.SuperPower.Name).ToList()
					})
					.FirstOrDefaultAsync(ct);
				
				return superHeroes is not null ? Results.Ok(superHeroes) : Results.NotFound("Error! SuperHero not found.");
			});

			/***** POST Method ******/
			superHeroGroup.MapPost("", async (AddSuperHeroRequest request, SHDatabase context, CancellationToken ct) =>
			{
				bool isExist = await ValidationHelper.IsHeroNameExistsAsync(request.HeroName, context, ct:ct);

				if (isExist)
					return (Results.Conflict("Error! A superhero with this heroName already exists."));

				var newSuperHero = new SuperHero(request.Name, request.HeroName, request.BirthDate, request.height, request.weight);

				foreach (var superPowerId in request.SuperPowerIds){
					var superPower = await context.SuperPowerDB.FindAsync(superPowerId);
					if (superPower != null){
						newSuperHero.HeroesSuperPowers.Add(new HeroesSuperPowers
						{
							Hero = newSuperHero,
							SuperPower = superPower
						});
					}
					else
						return Results.BadRequest($"Error! SuperPowerId {superPowerId} is invalid!");
				}

				await context.SuperHeroDB.AddAsync(newSuperHero, ct);
				await context.SaveChangesAsync(ct);
				var response = new SuperHeroDTO{
					Id = newSuperHero.Id,
					Name = newSuperHero.Name,
					HeroName = newSuperHero.HeroName,
					SuperPowerIds = newSuperHero.HeroesSuperPowers.Select(hsp => hsp.SuperPowerId).ToList()
				};

				return (Results.Ok(response));
			});

			/****** DELETE method ******/
			superHeroGroup.MapDelete("{id}", async (Guid id, SHDatabase context, CancellationToken ct) =>
			{
				var superhero = await context.SuperHeroDB.SingleOrDefaultAsync(superHero => superHero.Id == id);

				if (superhero == null)
					return (Results.NotFound("Error: SuperHero not found"));

				context.SuperHeroDB.Remove(superhero);
				await context.SaveChangesAsync(ct);
				return (Results.Ok($"SuperHero with ID {id} deleted successfully"));
			});

			/****** Put Method ******/
			superHeroGroup.MapPut("{id}", async (Guid id, UpdateSuperHeroRequest request, SHDatabase context, CancellationToken ct) =>
			{
				var superHero = await context.SuperHeroDB.SingleOrDefaultAsync(superHero =>
						superHero.Id == id);

				if (superHero == null){
					return (Results.NotFound("Error: SuperHero not found!"));
				}

				if (!string.IsNullOrWhiteSpace(request.HeroName))
				{
					bool isExist = await ValidationHelper.IsHeroNameExistsAsync(request.HeroName, context, id, ct:ct);
					if (isExist)
						return (Results.Conflict("Error! A superhero with this HeroName already exists."));
				}

				try
				{
					UpdateSuperHeroFields(superHero, request);
					await context.SaveChangesAsync(ct);
					return Results.Ok(superHero);
				}
				catch(Exception ex){
					return Results.Problem(detail: ex.Message, title: "An error occurred while updating the superhero.", statusCode: 500);
				}
			});
		}

		private static void UpdateSuperHeroFields(SuperHero superhero, UpdateSuperHeroRequest request){
			if (!string.IsNullOrWhiteSpace(request.Name) && request.Name != "string")
				superhero.SetName(request.Name);

			if (!string.IsNullOrWhiteSpace(request.HeroName) && request.HeroName != "string")
				superhero.SetHeroName(request.HeroName);

    		if (request.BirthDate != default)
 		   		superhero.SetBirthdate(request.BirthDate);			
		
			if (request.Height > 0)
				superhero.SetHeight(request.Height);

			if (request.Weight > 0)
				superhero.SetWeight(request.Weight);
		}
	}
}
