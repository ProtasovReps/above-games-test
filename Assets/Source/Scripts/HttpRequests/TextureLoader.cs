using System;
using System.Net.Http;
using System.Threading;
using Cysharp.Threading.Tasks;
using Interface;
using UnityEngine;
using UnityEngine.Networking;

namespace HTTPRequests
{
    public sealed class TextureLoader : IHttpLoader<Texture2D>, IDisposable
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new ();
        
        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
        
        public async UniTask<Texture2D> Load(string path)
        {
            using UnityWebRequest request = UnityWebRequestTexture.GetTexture(path);

            UnityWebRequestAsyncOperation operation = request.SendWebRequest();
            
            await UniTask.WaitUntil(
                () => operation.isDone, 
                cancellationToken: _cancellationTokenSource.Token,
                cancelImmediately: true);

            if (_cancellationTokenSource.IsCancellationRequested)
            {
                request.Abort();
                _cancellationTokenSource.Token.ThrowIfCancellationRequested();
            }
            
            ValidateRequestResult(request);
            return GetTexture(request);
        }

        private void ValidateRequestResult(UnityWebRequest request)
        {
            if (request.result == UnityWebRequest.Result.Success)
            {
                return;
            }

            throw new HttpRequestException(request.error);
        }

        private Texture2D GetTexture(UnityWebRequest request)
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(request);

            if (texture == null || texture.width == 0 || texture.height == 0)
            {
                throw new InvalidOperationException("Texture is invalid");
            }

            return texture;
        }
    }
}