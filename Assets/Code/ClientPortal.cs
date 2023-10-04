using FishNet;
using UnityEngine;
using UnityEngine.UI;

public sealed class ClientPortal : MonoBehaviour
{
       void OnTriggerEnter(Collider collider) {
		InstanceFinder.ClientManager.StartConnection();
                Debug.Log($"CLient");
        }
}
