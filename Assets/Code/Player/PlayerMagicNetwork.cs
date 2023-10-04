using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;
public class PlayerMagicNetwork : NetworkBehaviour
{

    public GameObject particleSystemPrefab; // Reference to your particle system prefab
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {
            
        }
        else
        {
            GetComponent<PlayerMagicNetwork>().enabled = false;
        }
    }
 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            MagicServer();
        }


    }
 
    [ServerRpc]
    public void MagicServer( )
    {
        UseMagic( );
    }
 
    [ObserversRpc]
    public void UseMagic( )
    {
        // Specify the position where you want to instantiate the particle system
        Vector3 spawnPosition = transform.position; // Use the position of the script's GameObject

        // Instantiate the particle system prefab at the specified position
        GameObject particleSystemInstance = Instantiate(particleSystemPrefab, spawnPosition, Quaternion.identity);
        Destroy(particleSystemInstance, 1.0f);
    }
}
