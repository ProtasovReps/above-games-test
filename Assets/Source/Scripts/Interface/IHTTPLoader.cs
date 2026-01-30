using System;
using Cysharp.Threading.Tasks;

namespace Interface
{
    public interface IHttpLoader<T> : IDisposable
    {
        public UniTask<T> Load(string path);
    }
}