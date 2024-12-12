using System.ComponentModel.DataAnnotations;

namespace SuperHeroDatabase{
    public class SuperPower
    {
        public Guid Id { get; set; }

		[Required]
		[MaxLength(50)]
        public string? Name { get; set; }

		[MaxLength(250)]
		public string? Description { get; set; } = null!;

		public List<HeroesSuperPowers> HeroesSuperPowers { get; set; } = new List<HeroesSuperPowers>();

        public SuperPower() { }

        public SuperPower(string name, string? description)
        {
            Id = Guid.NewGuid();
            Name = name;
			Description = description;
        }

		public void SetName(string name){
			Name = name;
		}

		public void SetDescription(string description){
			Description = description;
		}
    }
}

