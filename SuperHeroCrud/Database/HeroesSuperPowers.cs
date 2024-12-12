namespace SuperHeroDatabase{
	public class HeroesSuperPowers
	{
		public Guid HeroId { get; set; }
		public SuperHero Hero { get; set; } = null!;

		public Guid SuperPowerId { get; set; }
		public SuperPower SuperPower { get; set; } = null!;
	}
}
