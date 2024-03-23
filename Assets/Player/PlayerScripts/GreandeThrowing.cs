using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreandeThrowing : MonoBehaviour
{
    public Rigidbody GrenadePrefab;
    public Transform GrenadeTransform;

    public float force;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var greande = Instantiate(GrenadePrefab);
            greande.transform.position = GrenadeTransform.position;
            greande.GetComponent<Rigidbody>().AddForce(GrenadeTransform.forward * force);
        }
    }
}
