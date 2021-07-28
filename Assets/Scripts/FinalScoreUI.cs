using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FinalScoreUI : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "d = <i><b>" + PlanetManager.Score.ToString("0.#") + "</b>m</i>";
    }

}
