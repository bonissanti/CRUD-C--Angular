namespace SuperHeroDatabase{
	public record SuperHeroDTO(){
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public string? HeroName { get; init; }
		public string? BirthDate { get; set; }
		public float Height { get; set; }
		public float Weight { get; set; }
		public List<Guid> SuperPowerIds { get; init; } = null!;
		public List<string?> SuperPowerName { get; init; } = new List<string?>();
	};
}
