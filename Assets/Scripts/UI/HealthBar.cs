using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    Slider healthFill;


    // Start is called before the first frame update
    void Start()
    {
       //healthFill = GetComponent<Slider>();
    }

    public void UpdateHealthBar(float _hp, float _maxHp)
    {
        //Debug.Log("hp = " + _hp/_maxHp);
        healthFill.value = _hp/_maxHp;
    }
}
