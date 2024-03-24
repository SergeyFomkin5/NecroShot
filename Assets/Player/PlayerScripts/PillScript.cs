using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillScript : MonoBehaviour
{
    public float HealAmount = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHP>();
        if (playerHealth != null )
        {
            playerHealth.AddHealth(HealAmount);
            Destroy(gameObject);
        }
    }
}
