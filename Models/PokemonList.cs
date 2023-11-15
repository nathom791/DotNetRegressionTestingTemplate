namespace Models
{
    public class PokemonList
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public object Previous { get; set; }
        public List<Result> Results { get; set; }

        public class Result
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
    }
}