using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{

    private RawImage barRawImage;

    public Image imageHp;

    private RectTransform barMaskRectTransform;

    public Hp hp;

    private void Awake()
    {
        barMaskRectTransform = transform.Find("barMask").GetComponent<RectTransform>();
        //barImage = transform.Find("bar").GetComponent<Image>();
        barRawImage = transform.Find("barMask").Find("bar").GetComponent<RawImage>();

        hp = new Hp();
    }

    private void Update()
    {
        hp.Update();

        //barImage.fillAmount = mana.GetNormalized();
        Rect uvRect = barRawImage.uvRect;
        uvRect.x -= .1f * Time.deltaTime;
        barRawImage.uvRect = uvRect;

        imageHp.fillAmount = hp.GetNormalized();
    }
}

public class Hp
{
    public const int Hp_Max = 100;
    public float hpAmount = 100;
    private float hpRegenAmount = 25;

    public void Update()
    {
        if (hpAmount > Hp_Max)
        {
            hpAmount = Hp_Max;
        }
        else
        {
            hpAmount += hpRegenAmount * Time.deltaTime;
        }
    }

    public void TrySpendMana(int amount)
    {
        if (hpAmount >= amount)
        {
            hpAmount -= amount;
        }
    }

    public float GetNormalized()
    {
        return hpAmount / Hp_Max;
    }



}
