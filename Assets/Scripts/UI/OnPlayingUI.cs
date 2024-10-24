using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnPlayingUI : MonoBehaviour
{
    public Gradient color;

    Slider hpBar;
    Image fillArea;

    void Awake()
    {
        Transform temp = transform.GetChild(0);
        hpBar = temp.GetComponent<Slider>();
        temp = temp.GetChild(1);
        temp = temp.GetChild(0);
        fillArea = temp.GetComponent<Image>();
    }

    void Update()
    {
        hpBar.value = (GameManager.Instance.Player.HP / GameManager.Instance.Player.maxHp);
        fillArea.color = color.Evaluate(hpBar.value);
    }
}
