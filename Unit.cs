using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public Slider HPSlider;
    public int hp;
    public int hpMax = 100;
    public int at;


    void Start()
    {
        hp = hpMax;
        HPSlider.maxValue = hpMax;
        HPSlider.value = hpMax;
        at = 10;
    }


    public void OnDamage(int _damage)
    {
        hp -= _damage;
        if(hp <= 0)
        {
            hp = 0;
        }
        HPSlider.value = hp;
        Debug.Log(hp);
    }

}
