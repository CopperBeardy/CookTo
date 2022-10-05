namespace CookTo.Shared;

public static class ErrorMessage<T> where T : class
{
    public static string ItemsNotFound() => $"Items of {typeof(T)} were not found";

    public static string ItemNotFound(string id) => $"Item of {typeof(T)} with ID: {id}, was not found";
}
