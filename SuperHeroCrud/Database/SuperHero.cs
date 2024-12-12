using System.ComponentModel.DataAnnotations;

namespace SuperHeroDatabase{
	public class SuperHero{

		public Guid Id { get; init; }

		[Required]
		[MaxLength(120)]
		public string? Name { get; private set; }

		[Required]
		[MaxLength(120)]
		public string? HeroName { get; private set; }
		public string? BirthDate { get; private set; }
		public float Height { get; private set; }
		public float Weight { get; private set; }

		public List<HeroesSuperPowers> HeroesSuperPowers { get; set; } = new List<HeroesSuperPowers>();

		// Default Constructor
		public SuperHero(){}

		// Parametrized Constructor
		public SuperHero(string name, string heroname, DateTime birthdate, float height, float weight){
			Id = Guid.NewGuid();
			Name = name;
			HeroName = heroname;
			BirthDate = birthdate.ToString("dd-MM-yyyy");;
			Height = height;
			Weight = weight;
		}

		// Setter methods
		public void SetName(string name){
			Name = name;
		}

		public void SetHeroName(string heroname){
			HeroName = heroname;
		}

		public void SetBirthdate(DateTime birthdate){
			BirthDate = birthdate.ToString("dd-MM-yyyy");
		}

		public void SetHeight(float height){
			Height = height;
		}

		public void SetWeight(float weight){
			Weight = weight;
		}
	}
}
