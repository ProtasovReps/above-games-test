using System;
using System.Collections;
using System.Net.Http;
using Interface;
using UnityEngine;
using UnityEngine.Networking;

namespace Loader
{
    public sealed class ImageLoader : IHttpLoader<Texture2D>
    {
        public IEnumerator Load(string path, Action<Texture2D> successCallback)
        {
            using UnityWebRequest request = UnityWebRequestTexture.GetTexture(path);

            yield return request.SendWebRequest();
            ValidateRequestResult(request);

            Texture2D texture = GetTexture(request);
            successCallback?.Invoke(texture);
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