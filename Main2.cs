class Program
{
    static void Main2()
    {
        Library library = new Library();

        // Создаем книги
        Book book1 = new Book("1984","Джордж Оруэлл", "111", 2);
        Book book2 = new Book("Мастер и Маргарита","М. Булгаков", "222", 1);

        library.AddBook(book1);
        library.AddBook(book2);

        // Создаем читателей
        Reader reader1 = new Reader("Иван", 1);
        Reader reader2 = new Reader("Анна", 2);

        library.RegisterReader(reader1);
        library.RegisterReader(reader2);
    }
}