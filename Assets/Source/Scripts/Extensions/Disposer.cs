using System;
using System.Collections.Generic;

namespace Extensions
{
    public sealed class Disposer : IDisposable
    {
        private readonly List<IDisposable> _disposables = new ();
        
        public void Dispose()
        {
            for (int i = 0; i < _disposables.Count; i++)
            {
                _disposables[i].Dispose();
            }
        }
        
        public void Add(IDisposable disposable)
        {
            _disposables.Add(disposable);
        }
    }
}