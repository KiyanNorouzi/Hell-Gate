using FishNet;
using UnityEngine;
using UnityEngine.UI;

public sealed class ServerPortal : MonoBehaviour
{
       void OnTriggerEnter(Collider collider) {
            InstanceFinder.ServerManager.StartConnection();
			InstanceFinder.ClientManager.StartConnection();
             Debug.Log($"Server");
        }
}
