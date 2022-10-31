using GameCritic.Application.Common.Dtos.User;

namespace GameCritic.Application.Common.Dtos.Review
{
    public class ReviewListDto
    {
        public int Id { get; set; }

        public int Mark { get; set; }

        public string? Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public UserListDto User { get; set; }
    }
}
