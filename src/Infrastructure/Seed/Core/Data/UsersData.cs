using Domain.Users;
using Infrastructure.Seed.Abstractions;
using Infrastructure.Seed.Core.Ids;
using SharedKernel.Time;

namespace Infrastructure.Seed.Core.Data;

internal sealed class UsersData(IDateTimeProvider timeProvider) : SeedEntity<User>
{
    protected override IEnumerable<User> GetData()
    {
        return
        [
            new User
            {
                Id = UsersId.One,
                Name = "Joe",
                Pic = "",
                PicPath = "/home/morven/code/systems-integration/face_recognition/faces/",
                CreatedAt = timeProvider.UtcNow,
            },
            new User
            {
                Id = UsersId.Two,
                Name = "William",
                Pic = "",
                PicPath = "/home/morven/code/systems-integration/face_recognition/faces/",
                CreatedAt = timeProvider.UtcNow,
            },
        ];
    }
}
