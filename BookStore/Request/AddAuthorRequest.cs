namespace BookStore.Request
{
    public class AddAuthorRequest
    {
        public required string AuthorName { get; set; }
        public required string AuthorSurname { get; set; }
    }
}
