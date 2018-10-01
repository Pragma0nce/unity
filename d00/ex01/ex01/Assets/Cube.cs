using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	public float speed ;

	// Use this for initialization
	void Start () {
		speed = Random.Range(3.0f, 10.0f);
	}

	void PrintPrecision()
	{
		float precision = ((transform.localPosition.y - (-4.22f)) * 10);
		Debug.Log("Precision: " + precision);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);

		if (transform.localPosition.y <= -5){
			//PrintPrecision();
			Destroy(this.gameObject);
		}

		if (Input.GetKeyDown("a") && gameObject.tag == "A"){
			PrintPrecision();
			Destroy(this.gameObject);
		} else  if (Input.GetKeyDown("s") && gameObject.tag == "S"){
			PrintPrecision();
			Destroy(this.gameObject);
		}
		else  if (Input.GetKeyDown("d") && gameObject.tag == "D"){
			PrintPrecision();
			Destroy(this.gameObject);
		}
	}
}
