using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    
    
    void Update()
    {
         Destroy(gameObject, 4f);
    }
}
