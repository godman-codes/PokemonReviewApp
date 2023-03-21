namespace PokemonReviewApp.Dto
{
    public class PokemonDto
    {
        // dto is to make use we dont return all the fields in our databse tables
        // especially if we have confidential information in them 
        // so if we dont use dto and auto mapper the remaining fields like list, collection will just show null
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
