using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    public float scrollingSpeed = 2.5f;

    float groundHeight = 40.0f;

    Transform[] grounds;

    float zBorder = -25.0f;

    void Awake()
    {
        grounds = new Transform[transform.childCount];
        for (int i = 0; i < grounds.Length; i++)
        {
            grounds[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        for (int i = 0; i < grounds.Length; i++)
        {
            grounds[i].Translate(Time.deltaTime * scrollingSpeed * -transform.forward);
            if (grounds[i].position.z < zBorder)
            {
                MoveFrontEnd(i);
            }
        }
    }

    void MoveFrontEnd(int index)
    {
        grounds[index].Translate(groundHeight * grounds.Length * transform.forward);
    }
}
