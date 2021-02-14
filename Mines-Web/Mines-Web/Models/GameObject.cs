namespace Mines_Web.Models
{
    public class GameObject
    {
        public int Id { get; set; } = 0;
        public string DateCreated { get; set; } = "dd-MM-yyyy hh:mm:ss.fff";
        public string Difficulty { get; set; } = "beginner";

        public GameObject()
        {
        }
    }
}