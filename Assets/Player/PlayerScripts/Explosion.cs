using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float maxSize = 5f;
    public float ExpSpeed = 1f;
    public float damage = 50;
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * ExpSpeed;

        if (transform.localScale.x > maxSize )
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHP>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }

        var enemyHealth = other.GetComponent<EnemyScript>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
    }
}
