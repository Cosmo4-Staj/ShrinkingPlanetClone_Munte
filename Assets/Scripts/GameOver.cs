using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.instance.Restart();
        }
        
        //GetComponent<RectTransform>().localScale = Vector3.one * PlanetManager.Size;
    }
}
