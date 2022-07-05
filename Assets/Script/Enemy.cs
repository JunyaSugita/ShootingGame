using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    int enemyMaxHp = 50;
    private int enemyHp;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemyMaxHp;
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHp <= 0)
        {
            Destroy(this.gameObject);
        }

        slider.value = (float)enemyHp / (float)enemyMaxHp;
    }

    public void Damege()
    {
        enemyHp = enemyHp - 1;
    }
}
