using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public Image mana;
    public float manaRemain = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RegenInTime", 1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        mana.fillAmount = manaRemain;
    }

    public void UseMana(float cost)
    {
        manaRemain -= cost;
    }

    void RegenInTime()
    {
        if (manaRemain <= 1f)
        {
            manaRemain += 0.002f;
        }
    }

    public float GetManaRemain()
    {
        return manaRemain;
    }
}
