namespace WebApplication1.Extensions;

public static class AsyncEnumeratorExtensions
{
    public static async Task<T> GetLastAsync<T>(this IAsyncEnumerable<T> source, CancellationToken cancellationToken = default)
    {
        T last = default!;
        bool hasElements = false;

        await foreach (var item in source.WithCancellation(cancellationToken))
        {
            last = item;
            hasElements = true;
        }

        if (!hasElements)
            throw new InvalidOperationException("The source sequence is empty.");

        return last;
    }
}