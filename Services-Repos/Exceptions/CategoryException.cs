namespace Services_Repos.Exceptions;

[Serializable]
public class CategoryException : Exception
{
    public CategoryException()
    { }

    public CategoryException(string message)
        : base(message)
    { }

    public CategoryException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
