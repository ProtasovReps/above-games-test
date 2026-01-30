using System;
using System.Net.Http;
using Cysharp.Threading.Tasks;
using Interface;
using UnityEngine;
using UnityEngine.Networking;

namespace Loader
{
    public sealed class TextureLoader : IHttpLoader<Texture2D>, IDisposable
    {
        public void Dispose() //cancellationtoken
        {
        }
        
        public async UniTask<Texture2D> Load(string path)
        {
            using UnityWebRequest request = UnityWebRequestTexture.GetTexture(path);

            await request.SendWebRequest();
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