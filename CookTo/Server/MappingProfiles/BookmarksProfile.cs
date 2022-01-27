using AutoMapper;
using CookTo.Server.Documents.BookmarksDocument;
using CookTo.Shared.Features.ManageBookmarks;

namespace CookTo.Server.MappingProfiles;

public class BookmarksProfile : Profile
{
    public BookmarksProfile()
    {
        CreateMap<Bookmarks, AddBookmarksDto>().ReverseMap();
        CreateMap<List<Bookmarks>, List<BookmarksResultDto>>().ReverseMap();
    }
}
