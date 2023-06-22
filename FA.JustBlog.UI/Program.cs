using FA.JustBlog.Core.Repositories.UnitOfWork;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var uow = new UnitOfWork())
        {

            var tag = uow.PostRepository.GetPostsByTag("#Socal");
            tag.ToList().ForEach(x => Console.WriteLine($"{x.Id}, {x.Title}"));
        }
    }
}