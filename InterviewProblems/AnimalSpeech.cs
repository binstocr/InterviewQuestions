using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewProblems
{
	internal enum Animal
	{
		Dog,
		Cat,
		Cow
	}

	internal class AnimalSpeech
	{
		public readonly Func<string> Speak;

		public static IDictionary<Animal, string> AnimalSounds =
			new Dictionary<Animal, string>()
			{
				{ Animal.Dog, "arf" },
				{ Animal.Cat, "meow" },
				{ Animal.Cow, "moo" }
			};

		public AnimalSpeech(Animal inputAnimal)
		{
			string sound = string.Empty;
			foreach (var animal in Enum.GetValues(typeof(Animal)).Cast<Animal>())
			{
				sound = AnimalSounds[animal];
				if (inputAnimal == animal)
				{
					Speak = () => sound;
				}
			}
		}
	}
}
