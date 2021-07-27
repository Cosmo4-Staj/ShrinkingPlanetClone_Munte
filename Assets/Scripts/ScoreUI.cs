using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
	public TextMeshProUGUI text;

	RectTransform rt;
	Vector2 startPos;

	void Start()
	{
		rt = GetComponent<RectTransform>();
		startPos = rt.anchoredPosition;
	}

	void Update()
	{
		text.text = PlanetManager.Score.ToString("0.#") + "m";

		rt.anchoredPosition = Vector2.Lerp(Vector2.zero, startPos, PlanetManager.Size);
	}
}
