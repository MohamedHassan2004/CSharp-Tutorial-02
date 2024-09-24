using System.Reflection;

namespace Attr
{
    class Program
    {
        static void Mainv02(string[] args)
        {
            // List of players with their attributes
            List<Player> players = new List<Player>
            {
                new Player
                {
                    Name = "Lionel Messi",
                    BallControl = 9,
                    Dribbling = 18,
                    Passing = 4,
                    Speed = 85,
                    Power = 990
                },
                new Player
                {
                    Name = "Christiano Ronaldo",
                    BallControl = 9,
                    Dribbling = 21,
                    Passing = 4,
                    Speed = 110,
                    Power = 980
                },
                new Player
                {
                    Name = "Naymar Jr",
                    BallControl = 11,
                    Dribbling = 16,
                    Passing = 4,
                    Speed = 85,
                    Power = 1000
                }
            };

            // List to store validation errors
            var errors = new List<Error>();

            // Validate each player's attributes
            foreach (var player in players)
            {
                var properties = player.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    // Get the SkillAttribute applied to the property
                    var skillAttribute = prop.GetCustomAttribute<SkillAttribute>();
                    if (skillAttribute != null)
                    {
                        var value = prop.GetValue(player);
                        // Check if the value is within the valid range
                        if (!skillAttribute.IsValid(value))
                        {
                            errors.Add(new Error(prop.Name,
                                $"Invalid value. Accepted Range is {skillAttribute.Minimum}-{skillAttribute.Maximum}"));
                        }
                    }
                }
            }

            // Display validation errors or success message
            if (errors.Count > 0)
            {
                foreach (var e in errors)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                Console.WriteLine("Players' info are valid");
            }

            Console.ReadKey();
        }
    }

    // Class representing a player with various skills
    public class Player
    {
        public string Name { get; set; }

        [Skill(nameof(BallControl), 1, 10)]
        public int BallControl { get; set; } // 1 - 10

        [Skill(nameof(Dribbling), 1, 20)]
        public int Dribbling { get; set; } // 1 - 20

        [Skill(nameof(Power), 1, 1000)]
        public int Power { get; set; } // 1 - 1000

        [Skill(nameof(Speed), 1, 100)]
        public int Speed { get; set; } // 1 - 100

        [Skill(nameof(Passing), 1, 4)]
        public int Passing { get; set; } // 1 - 4
    }

    // Custom attribute to define skill properties
    public class SkillAttribute : Attribute
    {
        public string Name { get; private set; }
        public int Minimum { get; private set; }
        public int Maximum { get; private set; }

        public SkillAttribute(string name, int minimum, int maximum)
        {
            Name = name;
            Minimum = minimum;
            Maximum = maximum;
        }

        // Method to validate if the value is within the defined range
        public bool IsValid(object obj)
        {
            var value = (int)obj;
            return value >= Minimum && value <= Maximum;
        }
    }

    // Class to represent validation errors
    public class Error
    {
        private string field;
        private string details;

        public Error(string field, string details)
        {
            this.field = field;
            this.details = details;
        }

        public override string ToString()
        {
            return $"{{\"{field}\": \"{details}\"}}";
        }
    }
}
