using UnityEngine;
using UnityEngine.Networking;

namespace Network
{
    public class SimpleNetwork : MonoBehaviour
    {
        [SerializeField] private string postUrl;
        [SerializeField] private string auth;

        public void PostData(string data)
        {
            var request = UnityWebRequest.Post(postUrl, data);
            request.SetRequestHeader("Authorization", auth);
            request.SendWebRequest();
        }
    }
}