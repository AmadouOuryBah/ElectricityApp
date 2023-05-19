

namespace Electricity.BusinessLogic.DTO_s
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserDto> Users { get; set; }
    }
}
