using Microsoft.EntityFrameworkCore;

namespace SuperHeroDatabase{
	public class SHDatabase : DbContext{

		public DbSet<SuperHero> SuperHeroDB { get; set; } = null!;
		public DbSet<SuperPower> SuperPowerDB { get; set; } = null!;
		public DbSet<HeroesSuperPowers> HeroesSuperPowersDB { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			optionsBuilder.UseSqlite("Data source=database.sqlite");
            base.OnConfiguring(optionsBuilder);
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder){
			modelBuilder.Entity<HeroesSuperPowers>()
				.HasKey(hsp => new { hsp.HeroId, hsp.SuperPowerId });

			modelBuilder.Entity<HeroesSuperPowers>()
				.HasOne(hsp => hsp.Hero)
				.WithMany(h => h.HeroesSuperPowers)
				.HasForeignKey(hsp => hsp.HeroId);

			modelBuilder.Entity<HeroesSuperPowers>()
				.HasOne(hsp => hsp.SuperPower)
				.WithMany(sp => sp.HeroesSuperPowers)
				.HasForeignKey(hsp => hsp.SuperPowerId);

		}
		public static void SeedData(SHDatabase context){
			if (!context.SuperPowerDB.Any()){
				context.SuperPowerDB.AddRange(
						new SuperPower { Name = "Fly", Description = "Allows flight to everywhere"},
						new SuperPower { Name = "Strength", Description = "Ultimate strength, 10x that of a common human"},
						new SuperPower { Name = "Invisibility", Description = "Turns you invisible"},
						new SuperPower { Name = "Infinity money", Description = "A power like a cheat code in GTA"},
						new SuperPower { Name = "Read Minds", Description = "You acquire the ability to read the minds of everyone"}
						);
				context.SaveChanges();
			}
		}
	}


	public static class ValidationHelper{
		public static async Task<bool> IsHeroNameExistsAsync(string heroName, SHDatabase context, Guid? excludeId = null, CancellationToken ct = default){
			return await context.SuperHeroDB.AnyAsync(superHero =>
					superHero.HeroName == heroName && (excludeId == null || superHero.Id != excludeId), ct);
		}
	}
 }
