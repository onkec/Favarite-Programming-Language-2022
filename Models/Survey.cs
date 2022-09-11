namespace FaveProgrammingLang.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string FaveProgrammingLang { get; set; }

        public Survey()
        {

        }
    }
}
