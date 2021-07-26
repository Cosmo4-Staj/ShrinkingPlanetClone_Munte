using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	[Range(0, 15)]
	public float moveSpeed = 10f;

	[Range(50, 250)]
	public float rotationSpeed = 10f;

	private Rigidbody rb;
	private float rotation;

	public Vector2 rangePlayerPosX;

	void Start()
	{
		rb = this.GetComponent<Rigidbody>();
	}

	void Update()
	{
		//TO DO : mousebuttondown
		rotation = Input.GetAxisRaw("Horizontal");

	}

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + this.transform.forward * -moveSpeed * Time.fixedDeltaTime);

		Vector3 rotationY = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
		Quaternion deltaRotation = Quaternion.Euler(rotationY);
		Quaternion targetRotation = rb.rotation * deltaRotation;
		rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.fixedDeltaTime));
	}
}

/*public class PlayerManager : MonoBehaviour
{
	public float moveSpeed = 10f;
	public float rotationSpeed = 10f;

	private float rotation;

	private Rigidbody rb;

	Vector3 curOffset, mouseOffset;
	GameObject playerOffsetX;
	public Vector2 rangePlayerPosX;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		SetOffset();
	}
	void SetOffset()
	{
		playerOffsetX = new GameObject();
		playerOffsetX.name = "GameObjectOffset";
		playerOffsetX.transform.position = this.transform.position;
	}
	void Update()
	{
		rotation = Input.GetAxisRaw("Horizontal");
	}

	void FixedUpdate()
	{

		this.transform.position += this.transform.forward * Time.deltaTime * moveSpeed;

		float pos = (Input.mousePosition.x * (rangePlayerPosX.y - rangePlayerPosX.x)) / Screen.width;
		pos -= (rangePlayerPosX.y - rangePlayerPosX.x) / 2;

		if (Input.GetMouseButtonDown(0))
		{
			playerOffsetX.transform.position = new Vector3(pos, this.transform.position.y, this.transform.position.z);
			mouseOffset = this.transform.position - playerOffsetX.transform.position;
		}
		else if (Input.GetMouseButton(0))
		{
			playerOffsetX.transform.position = new Vector3(pos, this.transform.position.y, this.transform.position.z);
			mouseOffset.y = mouseOffset.z = 0;
			curOffset = playerOffsetX.transform.position + mouseOffset;
			curOffset.x = Mathf.Clamp(curOffset.x, rangePlayerPosX.x, rangePlayerPosX.y);
			this.transform.position = curOffset;
		}
	}
}*/