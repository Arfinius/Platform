using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour {

    private Image barImage;

    public Mana mana;

    bool isEmptyMana = false;

    private void Awake()
    {
        barImage = transform.Find("bar").GetComponent<Image>();

        mana = new Mana();
    }

    private void Update()
    {
        mana.Update();

        barImage.fillAmount = mana.GetNormalized();
    }

    public void ShieldWhenS()
    {
        if (isEmptyMana == false)
        {
            mana.TrySpendMana(1);
        }
        if (mana.manaAmount <= 0)
        {
            isEmptyMana = true;
        }
        else if (mana.manaAmount >= 0)
        {
            isEmptyMana = false;
        }
    }
}


public class Mana
{
    public const int Mana_Max = 100;
    public float manaAmount = 100;
    private float manaRegenAmount = 25;

    public void Update()
    {
        if (manaAmount > Mana_Max)
        {
            manaAmount = Mana_Max;
        }
        else
        {
            manaAmount += manaRegenAmount * Time.deltaTime;
        }
    }

    public void TrySpendMana(int amount)
    {
        if(manaAmount >= amount)
        {
            manaAmount -= amount;
        }
    }

    public float GetNormalized()
    {
        return manaAmount / Mana_Max;
    }
}
