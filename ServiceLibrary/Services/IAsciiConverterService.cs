namespace ServiceLibrary
{
    public interface IAsciiConverterService : IMyService
    {
        string Convert(string imagePath);
    }
}