﻿using AutoMapper;
using CookTo.Server.Documents.BookmarksDocument;
using CookTo.Shared.Features.ManageBookmarks.Shared;

namespace CookTo.Server.Mappings;

public class BookmarksProfile : Profile
{
    public BookmarksProfile() { CreateMap<BookmarksDto, Bookmarks>().ReverseMap(); }
}
