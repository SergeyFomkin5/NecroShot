using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public float MaxHp = 100;

    public float _currentValue;
    public GameObject panel;
    public GameObject Aim;
    public GameObject HealthBar;
    public Image HpBar;
    // Start is called before the first frame update
    void Start()
    {
        _currentValue = MaxHp;
        //UpdateHealthbar();
    }

    // Update is called once per frame
    void Update()
    {
        //HpBar.fillAmount -= 0.001f;

        PlayerIsDead();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            
            HpBar.fillAmount -= 0.01f;
        }
    }

    public void TakeDamage(float damage)
    {
        //отнять урон от текущего значения здоровья
        _currentValue -= damage;

        //проверить, что здоровья не осталось
        if (_currentValue <= 0)
        {
            Destroy(gameObject);
        }
        UpdateHealthbar();
    }

    void UpdateHealthbar()
    {
        HpBar.fillAmount = _currentValue / MaxHp;
    }

    public void AddHealth(float amount)
    {
        //Прибавить к текущему здоровью значение amount
        _currentValue += amount;
        //Если текущее здоровье больше, чем максимальное значение
        //if(_currentValue > MaxHp)
        //{
        //    _currentValue = MaxHp;
        //}
        _currentValue = Mathf.Clamp( _currentValue, 0, MaxHp );
        UpdateHealthbar();
        //Обновить полоску здоровья
    }

    void PlayerIsDead()
    {
        if (HpBar.fillAmount <= 0)
        {
            panel.SetActive(true);
            HealthBar.SetActive(false);
            Aim.SetActive(false);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<CameraScript>().enabled = false;
            
        }
    }
}
