using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test03_CharacterController : MonoBehaviour
{
    CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
}
