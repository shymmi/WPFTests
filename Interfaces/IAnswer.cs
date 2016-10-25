namespace Interfaces
{
    public interface IAnswer
    {
        int ID { get; set; }
        string Text { get; set; }
        bool IsCorrect { get; set; }
        bool IsSelected { get; set; }
    }
}