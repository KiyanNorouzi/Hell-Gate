using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Broadcast;
using FishNet;
using FishNet.Connection;

public class ObjectPositionBroadcast : MonoBehaviour
{
 public List<Transform> cubePositions = new List<Transform>();
    public int transformIndex;
 
    private void OnEnable()
    {
        InstanceFinder.ClientManager.RegisterBroadcast<PositionIndex>(OnPositionBroadcast);
        InstanceFinder.ServerManager.RegisterBroadcast<PositionIndex>(OnClientPositionBroadcast);
    }
 
    private void OnDisable()
    {
        InstanceFinder.ClientManager.UnregisterBroadcast<PositionIndex>(OnPositionBroadcast);
        InstanceFinder.ServerManager.UnregisterBroadcast<PositionIndex>(OnClientPositionBroadcast);
    }
 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            int nextIndex = transformIndex + 1;
            if (nextIndex >= cubePositions.Count)
                nextIndex = 0;
 
            if(InstanceFinder.IsServer)
            {
                InstanceFinder.ServerManager.Broadcast(new PositionIndex() { tIndex = nextIndex });
            }
            else if(InstanceFinder.IsClient)
            {
                InstanceFinder.ClientManager.Broadcast(new PositionIndex() { tIndex = nextIndex });
            }
        }
 
        transform.position = cubePositions[transformIndex].position;
    }
 
    private void OnPositionBroadcast(PositionIndex indexStruct)
    {
        transformIndex = indexStruct.tIndex;
    }
 
    private void OnClientPositionBroadcast(NetworkConnection networkConnection, PositionIndex indexStruct)
    {
        InstanceFinder.ServerManager.Broadcast(indexStruct);
    }
 
    public struct PositionIndex : IBroadcast
    {
        public int tIndex;
    }
}