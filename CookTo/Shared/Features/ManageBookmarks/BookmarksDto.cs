namespace CookTo.Shared.Features.ManageBookmarks;

public class BookmarksDto
{
    public string UserId { get; set; }


    public List<BookMarked>? BookMarkedRecipes { get; set; }
}
