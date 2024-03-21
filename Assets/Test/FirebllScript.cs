using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebllScript : MonoBehaviour
{
    public float Speed;
    public GameObject FireBall;
    public float FlyingLifetime;

    private void Start()
    {
        Invoke("DestroyFireball", FlyingLifetime);
    }

    private void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyFireball();
    }

    private void DestroyFireball()
    {
        Destroy(FireBall);
    }




}
