using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
	public static float Size
	{
		get { return myTransform.localScale.x; }
	}
	public static float Score
	{
		get { return Size * 5f; }
	}

	private static Transform myTransform;

	public float shrinkSpeed = .01f;

	void Awake()
	{
		myTransform = transform;
	}

	void Update()
	{
		transform.localScale *= 1f - shrinkSpeed * Time.deltaTime;
	}
}
