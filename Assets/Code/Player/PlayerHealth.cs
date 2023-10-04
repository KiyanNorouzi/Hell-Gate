using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object.Synchronizing;
using FishNet.Object;
using TMPro;


public class PlayerHealth : NetworkBehaviour
{
    [SyncVar] public int health = 10;
    private TextMeshProUGUI healthText;
    private GameObject GameOver;
     private Animator animator;

    private void Start()
    {
        healthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
        GameOver = GameObject.FindGameObjectWithTag("GameOver");
        GameOver.SetActive(false);
    }
 
    private void Update()
    {
        if (!base.IsOwner)
            return;
 
        healthText.text = health.ToString();

        if(health <= 0 ){
            health =0;    
            GameOver.SetActive(true);
            animator.SetBool("Death", true);

            StartCoroutine(WaitForFunction());
          
   
        }
    }


    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(4);
        ClientManager.StopConnection();
    }
}