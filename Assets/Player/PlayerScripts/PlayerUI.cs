using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public float MaxHp = 100;
    public float CurrentHp;
    public Image HpImage;
    public GameObject DeathScreen;
    public Camera CameraLink;
    public Transform Aim;
    void Start()
    {
        CurrentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = CameraLink.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Aim.position = hit.point;
        }

        transform.LookAt(Aim.position);
    }



    void TakeDamage(float damage)
    {
        damage = 5;

        CurrentHp -= damage;

        if(CurrentHp <= 0)
        {
            DeathScreen.SetActive(true);
            Time.timeScale = 0;  
        }
    }
}

