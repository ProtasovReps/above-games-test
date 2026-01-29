using System;
using System.Collections;

namespace Interface
{
    public interface IHttpLoader<T>
    {
        public IEnumerator Load(string path, Action<T> successCallback);
    }
}