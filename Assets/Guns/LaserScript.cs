using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public Camera PlayerCamera;
    public Transform ShootPlace;
    public float FireRate = 0.2f;
    public float LaserRange;
    public float LaserDuration = 0.05f;

    LineRenderer LaserLine;
    float FireTimer;

    void Awake()
    {
      LaserLine = GetComponent<LineRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        FireTimer += Time.deltaTime;
       if(Input.GetKeyDown(KeyCode.Mouse0) && FireTimer > FireRate)
        {
            FireTimer = 0;
            LaserLine.SetPosition(0, ShootPlace.position);
            Vector3 rayOrigin = PlayerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, PlayerCamera.transform.forward, out hit, LaserRange))
            {
                LaserLine.SetPosition(1, hit.point);
                //Destroy(hit.transform.gameObject);
            }
            else
            {
                LaserLine.SetPosition(1, rayOrigin + (PlayerCamera.transform.forward * LaserRange));
            }
            StartCoroutine(ShootLaser());
        }
    }

    IEnumerator ShootLaser()
    {
        LaserLine.enabled = true;
        yield return new WaitForSeconds(LaserDuration);
        LaserLine.enabled = false;
    }
}
