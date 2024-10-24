using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestUIText : MonoBehaviour
{
    TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = GameManager.Instance.Player.HP.ToString();
    }
}
