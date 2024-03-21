using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    
    public Transform ShootSpace;
    //public LineRenderer laserline;
    public Camera cam;

    public float damage = 30f;
    public int MagazineCapacity = 6;
    public float FireRate = 1.0f;
    public float ShootRange = 100f;
    public float HitForce = 100f;
    public int ShotCount = 1;
    [SerializeField] private float _nextFire;

    public bool _useSpread;
    public float SpreadWidth = 1.0f;

    private WaitForSeconds ShotDuration = new WaitForSeconds(.07f);

    [SerializeField] private LayerMask _layerMask;

    void Start()
    {
        Links();
    }

    // Update is called once per frame
    void Update()
    {
        OnDrawGizmos();
        
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastShoot();
        }
        
    }

    public void Links()
    {
        
    }

    public void RaycastShoot()
    {
       
        RaycastHit hit;
        

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(ShootSpace.transform.position, transform.forward, Color.red);
            EnemyScript enemy = hit.transform.GetComponent<EnemyScript>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        //var direction = _useSpread ? transform.forward + SpreadCalc() : transform.forward;

        //var ray = new Ray(transform.position, direction);

        //if (Physics.Raycast(ray, out RaycastHit hitInfo, ShootRange, _layerMask))
        //{
        //    var hitCollider = hitInfo.collider;
        //    Debug.Log("Pew");

        //    if (hitCollider.gameObject.tag == "Enemy")
        //    {
        //        SendMessage("TakeDamage", damage);
        //    }
        //}
    }

    public void OnDrawGizmos()
    {
        var ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray,out var hitInfo, ShootRange, _layerMask))
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Debug.DrawRay(ShootSpace.transform.position, forward,Color.green);
            
        }
    }

    private Vector3 SpreadCalc()
    {
        return new Vector3
        {
            x = Random.Range(-SpreadWidth, SpreadWidth),
            y = Random.Range(-SpreadWidth, SpreadWidth),
            z = Random.Range(-SpreadWidth, SpreadWidth)
        };
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    var EnemyHealth = collision.gameObject.GetComponent<EnemyScript>();
    //    if ()
    //    {
    //        EnemyHealth.TakeDamage(damage);
    //    }
    //}

}
