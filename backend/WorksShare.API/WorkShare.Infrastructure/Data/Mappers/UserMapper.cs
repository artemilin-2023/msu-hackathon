using WorkShare.Domain;
using WorkShare.Infrastructure.Data.Entities;

namespace WorkShare.Infrastructure.Data.Mappers
{
    internal static class UserMapper
    {
        public static User Map(this UserEntity entity)
        {
            return new User(entity.Id, entity.Name);
        }

        public static UserEntity Map(this User user)
        {
            return new UserEntity()
            {
                Id = user.Id,
                Name = user.Name,
            };
        }
    }
}
