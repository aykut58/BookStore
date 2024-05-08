namespace BookStore.Request
{
    public class AddBookRequest
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string AuthorId { get; set; }

        public required int PageNumber { get; set; }

    }
}
