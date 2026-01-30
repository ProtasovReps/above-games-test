using System;

namespace Interface
{
    public interface ILoadRequester<T>
    {
        public event Action<ILoadPath<T>> Requested;
    }
}