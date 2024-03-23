namespace Mission11_Blosil.Models;

public interface IBookstoreRepository
{
    public IQueryable<Book> Books { get; }
}