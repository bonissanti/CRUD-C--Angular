namespace SuperHeroDatabase{
	public record UpdateSuperHeroRequest(
			string Name,
			string HeroName,
			DateTime BirthDate,
			float Height,
			float Weight
			);
}
