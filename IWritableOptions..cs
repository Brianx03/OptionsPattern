using Microsoft.Extensions.Options;

namespace OptionsPattern
{
    public interface IWritableOptions<out T> : IOptionsSnapshot<T> where T : class, new()
    {
        Task Update(Action<T> applyChanges);
    }
}
