namespace Electricity.DataAccess.Entities
{
    public class Role
    {
        public Role(string name)
        {
            Name = name;
        }

        public Role()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}