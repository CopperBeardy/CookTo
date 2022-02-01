using CookTo.Server.Documents.BookmarksDocument;
using CookTo.Shared.Features.ManageBookmarks.Shared;

namespace CookTo.Server.Mappings;

public static class BookmarksMapping
{
    public static Bookmarks FromDtoToBookmarks(BookmarksDto obj)
    {
        var bookmarks = new Bookmarks() { UserId = obj.UserId };
        bookmarks.BookMarkedRecipes
            .AddRange(
                obj.BookMarkedRecipes
                    .Select(
                        bm => new SectionBookMarked()
                            {
                                BookMarkedRecipeId = bm.BookMarkedRecipeId,
                                RecipeTitle = bm.RecipeTitle
                            }));
        return bookmarks;
    }

    public static BookmarksDto FromBookmarksToDto(Bookmarks obj)
    {
        var bookmarks = new BookmarksDto() { UserId = obj.UserId };
        bookmarks.BookMarkedRecipes
            .AddRange(
                obj.BookMarkedRecipes
                    .Select(
                        bm => new BookMarked()
                            {
                                BookMarkedRecipeId = bm.BookMarkedRecipeId,
                                RecipeTitle = bm.RecipeTitle
                            }));
        return bookmarks;
    }
}
