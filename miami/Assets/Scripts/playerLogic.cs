using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLogic : MonoBehaviour
{
	public float	speed;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//------------------------------- Movement WASD -----------------------------------
		if (Input.GetKey("w"))
			 transform.Translate(Vector3.up * Time.deltaTime * this.speed, Space.World);
		if (Input.GetKey("s"))
			 transform.Translate(Vector3.down * Time.deltaTime * this.speed, Space.World);
		if (Input.GetKey("a"))
			 transform.Translate(Vector3.left * Time.deltaTime * this.speed, Space.World);
		if (Input.GetKey("d"))
			 transform.Translate(Vector3.right * Time.deltaTime * this.speed, Space.World);
		//---------------------------------------------------------------------------------

		//-------------------------------- Follow Mouse -----------------------------------
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10.0f;
		Vector3 clickPos = Camera.main.ScreenToWorldPoint(mousePos);
		Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.x = mousePos.x - object_pos.x;
		mousePos.y = mousePos.y - object_pos.y;
		float step = speed * Time.deltaTime;
		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle + 90.0f, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, step * 4.0f);
		//---------------------------------------------------------------------------------
	}

	//-------------------------------- Pickup Weapon ----------------------------------
	void OnCollisionEnter (Collision col)
	{
		Debug.Log("TEST");
		// if(col.gameObject.name == "prop_powerCube")
		// {
		// 	Destroy(col.gameObject);
		// }
	}
	//---------------------------------------------------------------------------------
}
