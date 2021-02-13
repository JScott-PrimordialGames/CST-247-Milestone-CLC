namespace Mines_Web.Services.Data
{
    public class GameObject
    {
        public int Id { get; set; }
        public string JSONstring { get; set; }

        public GameObject(int id, string jSONstring)
        {
            Id = id;
            JSONstring = jSONstring;
        }

        public GameObject(string jSONstring)
        {
            JSONstring = jSONstring;
        }
    }
}