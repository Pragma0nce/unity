using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject weapon;
	// Use this for initialization
	void Start () {
		weapon = Instantiate(weapon, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            weapon.GetComponent<Weapon>().Fire();
        }

		weapon.transform.position = gameObject.transform.position;	
		weapon.transform.rotation = gameObject.transform.rotation;	

	}
}
