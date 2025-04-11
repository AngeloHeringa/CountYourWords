namespace CountYourWords.Interfaces;

public interface IFileReader // Could be used for testability/mocking, not directly necessary in this case
{
    string? ReadAllText();
}
