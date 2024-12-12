namespace SuperHeroDatabase{
	public record AddSuperHeroRequest(
			string Name,
			string HeroName,
			DateTime BirthDate,
			float height,
			float weight,
			List<Guid>SuperPowerIds
			);
}
