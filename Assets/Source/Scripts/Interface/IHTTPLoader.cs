using Cysharp.Threading.Tasks;

namespace Interface
{
    public interface IHttpLoader<T>
    {
        public UniTask<T> Load(string path);
    }
}