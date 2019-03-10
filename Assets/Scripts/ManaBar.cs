using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour {
    

    private RawImage barRawImage;

    private RectTransform barMaskRectTransform;

    public Mana mana;

    public Image imageMana;

    bool isEmptyMana = false;


    private void Awake()
    {
        barMaskRectTransform = transform.Find("barMask").GetComponent<RectTransform>();
        
        barRawImage = transform.Find("barMask").Find("bar").GetComponent<RawImage>();

        

        mana = new Mana();
    }

    private void FixedUpdate()
    {
        mana.Update();

        Rect uvRect = barRawImage.uvRect;
        uvRect.x += .1f * Time.fixedDeltaTime;
        barRawImage.uvRect = uvRect;

        imageMana.fillAmount = mana.GetNormalized();
    }

    public void ShieldWhenS()
    {
        if (isEmptyMana == false)
        {
            mana.TrySpendMana(2);
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
    private float manaRegenAmount = 20;

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
