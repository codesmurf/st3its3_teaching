namespace CPRRegister;

public class Person
{
    public string CPR { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    private static Random random = new Random();
    public static Person CreateRandomPerson(string cpr)
    {

        return new Person()
        {
            CPR = cpr,
            FirstName = DanishFirstNames[random.Next(DanishFirstNames.Count)],
            LastName = DanishLastNames[random.Next(DanishFirstNames.Count)]
        };
    }

    private static readonly List<string> DanishFirstNames = new List<string>
    {
        "Emil", "Sofie", "Frederik", "Mia", "Magnus", "Laura", "William", "Emma", "Mads", "Line",
        "Alexander", "Amalie", "Lucas", "Clara", "Oliver", "Ida", "Noah", "Sarah", "Mathias", "Lærke",
        "Mikkel", "Anna", "Victor", "Signe", "Oscar", "Maria", "Carl", "Julie", "Christian", "Louise",
        "Jonathan", "Nanna", "Philip", "Alberte", "Elias", "Johanne", "Rasmus", "Frida", "Anders", "Liva",
        "Sebastian", "Victoria", "Anton", "Karoline", "Simon", "Isabella", "Filip", "Sofia", "Kasper", "Astrid",
        "Theo", "Olivia", "Lukas", "Nina", "Matias", "Silje", "Benjamin", "Thilde", "Gustav", "Anna-Sophie",
        "Nikolaj", "Cecilie", "Viggo", "Rebecca", "Valdemar", "Johanna", "Mikael", "Albert", "Karl", "Karla",
        "Erik", "Sille", "Felix", "Alberte", "Jens", "Marie", "Magnus", "Ingrid", "Jesper", "Ellen", "Malthe",
        "Ida-Marie", "Casper", "Sara", "Lasse", "Josefine", "Emilie", "Thorkild", "Stine", "Niels", "Sofia",
        "Troels", "Elisabeth", "Søren", "Louisa", "Andreas", "Isabel", "Jørgen", "Solvej", "Rikke", "Ane"
    };

    private static readonly List<string> DanishLastNames = new List<string>
        {
            "Andersen", "Nielsen", "Jensen", "Pedersen", "Larsen", "Rasmussen", "Christensen",
            "Sørensen", "Madsen", "Olsen", "Thomsen", "Petersen", "Knudsen", "Johansen",
            "Jakobsen", "Eriksen", "Hansen", "Mortensen", "Kristensen", "Lund", "Svendsen",
            "Mikkelsen", "Simonsen", "Olesen", "Poulsen", "Jørgensen", "Carlsen", "Andresen",
            "Henriksen", "Iversen", "Lorentzen", "Schmidt", "Lassen", "Mogensen", "Møller",
            "Svendsen", "Vestergaard", "Kristiansen", "Jørgensen", "Thygesen", "Villadsen",
            "Buch", "Hermansen", "Berg", "Søgaard", "Sørensen", "Nielsen", "Andersen",
            "Knudsen", "Jensen", "Christiansen", "Larsen", "Mortensen", "Eriksen", "Olsen",
            "Jakobsen", "Poulsen", "Hansen", "Petersen", "Thomsen", "Lund", "Madsen", "Rasmussen",
            "Simonsen", "Henriksen", "Andresen", "Kristensen", "Olesen", "Iversen", "Carlsen",
            "Mikkelsen", "Svendsen", "Vestergaard", "Lorentzen", "Mogensen", "Jørgensen",
            "Villadsen", "Buch", "Hermansen", "Lassen", "Møller", "Berg", "Søgaard", "Schmidt",
            "Johansen", "Jørgensen", "Villadsen", "Andresen", "Carlsen", "Henriksen", "Jakobsen",
            "Knudsen", "Kristensen", "Lorentzen", "Madsen", "Mikkelsen", "Mogensen", "Nielsen",
            "Olesen", "Olsen", "Petersen", "Poulsen", "Rasmussen", "Schmidt", "Simonsen",
            "Svendsen", "Thomsen", "Møller", "Vestergaard", "Berg", "Buch", "Hansen", "Hermansen",
            "Iversen", "Larsen", "Lund", "Søgaard", "Sørensen", "Thygesen", "Nielsen", "Andersen",
            "Knudsen", "Jensen", "Christiansen", "Larsen", "Mortensen", "Eriksen", "Olsen",
            "Jakobsen", "Poulsen", "Hansen", "Petersen", "Thomsen", "Lund", "Madsen", "Rasmussen",
            "Simonsen", "Henriksen", "Andresen", "Kristensen", "Olesen", "Iversen", "Carlsen",
            "Mikkelsen", "Svendsen", "Vestergaard", "Lorentzen", "Mogensen", "Jørgensen",
            "Villadsen", "Buch", "Hermansen", "Berg", "Søgaard", "Schmidt", "Johansen", "Jørgensen",
            "Villadsen", "Andresen", "Carlsen", "Henriksen", "Jakobsen", "Knudsen", "Kristensen",
            "Lorentzen", "Madsen", "Mikkelsen", "Mogensen", "Nielsen", "Olesen", "Olsen",
            "Petersen", "Poulsen", "Rasmussen", "Schmidt", "Simonsen", "Svendsen", "Thomsen",
            "Møller", "Vestergaard", "Berg", "Buch", "Hansen", "Hermansen", "Iversen", "Larsen",
            "Lund", "Søgaard", "Sørensen", "Thygesen"
        };
}