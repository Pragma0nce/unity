using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public bool isMelee;

	public GameObject projectile;
	public float burstAmount;
	public float timeToBurst;
	public float timeBetweenShots;

	private float timerNextShot;
	private float timerNextBurst;
	private float timerDeleteProjectile;

	private int numBullets;

	public Sprite bulletSprite;
	public float bulletSize;

	// Use this for initialization
	public void Fire()
	{
		if (timerNextBurst < 0)
		{
			if (timerNextShot < 0)
        	{
        		Quaternion rot = transform.rotation;

        		GameObject clone = Instantiate(projectile, transform.position, rot);
        		
        		clone.GetComponent<SpriteRenderer>().sprite = bulletSprite;
        		clone.transform.localScale = new Vector3(bulletSize, bulletSize, bulletSize);

        		if (isMelee){
        			clone.GetComponent<ProjectileMovement>().timerToDelete = 0.05f;
        			clone.GetComponent<ProjectileMovement>().speed = 10.0f;
        		}

		         Vector3 mousePos = Input.mousePosition;
		         mousePos.z = 5.23f;

		         Vector3 objectPos = Camera.main.WorldToScreenPoint (clone.transform.position);
		         mousePos.x = mousePos.x - objectPos.x;
		         mousePos.y = mousePos.y - objectPos.y;

		         float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		         clone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        		numBullets++;
        		timerNextShot = timeBetweenShots;
        	}

        	if (numBullets >= burstAmount){
        		numBullets = 0;
        		timerNextBurst = timeToBurst;
        	}
		}
	}

	void Start () {
		numBullets = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timerNextBurst -= Time.deltaTime;
		timerNextShot -= Time.deltaTime;		
	}
}
