using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript_ex01 : MonoBehaviour {

private Rigidbody2D rigidBody2D;
	private BoxCollider2D collider;

	public float moveSpeed = 2.0f;
	public float jumpPower = 0.8f;

	public LayerMask groundLayer;
	public LayerMask playerLayer;

	private static string curPlayer;
	public GameObject winCollider;

	public string GetCurrentPlayer(){
		return curPlayer;
	}
	// Use this for initialization
	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D>();
		curPlayer = "Blue";

		winCollider = Instantiate(winCollider,new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
	}
	
	void Jump()
	{
		if (IsOnGround() && !Raycast(Vector2.up, playerLayer))
			rigidBody2D.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
	}

	bool Raycast(Vector2 direction, LayerMask layer)
	{
		Vector2 position = collider.bounds.min;
		float distance = 0.05f;
		float offset = 0.001f;
		float softner = 0.0f;
		Vector2 spread = ((collider.bounds.max - collider.bounds.min))/10f;


		if (direction == Vector2.left)
		{
			position.x = collider.bounds.min.x;
			position.y = collider.bounds.max.y;

			for (int i = 0; i <= 10; i++){
				//Debug.DrawRay(position - new Vector2(softner, i * spread.y - softner), direction, Color.green, 0.5f, false);
				RaycastHit2D hit= Physics2D.Raycast(position - new Vector2(softner + offset, i * spread.y - softner), direction, distance, layer);
				if (hit.collider != null) {
				    return true;
				}
			}
		}
		else if (direction == Vector2.right) 
		{
			position.x = collider.bounds.max.x;
			position.y = collider.bounds.max.y;

			for (int i = 0; i <= 10; i++){
				//Debug.DrawRay(position - new Vector2(softner, i * spread.y - softner), direction, Color.green, 0.5f, false);
				RaycastHit2D hit= Physics2D.Raycast(position - new Vector2(softner - offset, i * spread.y - softner), direction, distance, layer);
				if (hit.collider != null) {
				    return true;
				}
			}			
		}
		else if (direction == Vector2.up){
			position.x = collider.bounds.min.x;
			position.y = collider.bounds.max.y;

			for (int i = 0; i <= 10; i++){
				//Debug.DrawRay(position + new Vector2(i * spread.x - softner,softner) , direction, Color.green, 1.0f, false);
				RaycastHit2D hit= Physics2D.Raycast(position + new Vector2(i * spread.x - softner,softner + offset), direction, distance, layer);
				if (hit.collider != null) {
				    return true;
				}
			}			
		}
		else if (direction == Vector2.down){
			position.x = collider.bounds.min.x;
			position.y = collider.bounds.min.y;

			for (int i = 0; i <= 10; i++){
				//Debug.DrawRay(position + new Vector2(i * spread.x - softner,softner) , direction, Color.green, 1.0f, false);
				RaycastHit2D hit = Physics2D.Raycast(position + new Vector2(i * spread.x - softner,softner - offset), direction, distance, layer);
				if (hit.collider != null) {
				    return true;
				}
			}			
		}


		return false;
	}

	bool IsOnGround()
	{
		if (Raycast(Vector2.down, groundLayer)){
			return true;
		} else if (Raycast(Vector2.down, playerLayer))
			return true;
		// Vector2 position = collider.bounds.min;
		// Vector2 direction = Vector2.down;
		// float distance = 0.1f;
		// float softner = 0.1f;
		// float spread = (collider.bounds.max.x - softner - collider.bounds.min.x + softner)/10f;


		// for (int i = 0; i <= 10; i++){
		// 	Debug.DrawRay(position + new Vector2((spread * i) + softner,-0.1f), direction, Color.green, 5.0f, false);
		// 	RaycastHit2D hitPlayer = Physics2D.Raycast(position + new Vector2((spread * i) + 0.1f,-0.1f), direction, distance, playerLayer);
		// 	RaycastHit2D hitPlatform = Physics2D.Raycast(position + new Vector2((spread * i),-0.1f), direction, distance, groundLayer);
		// 	if (hitPlayer.collider != null || hitPlatform.collider != null) {
		// 	    return true;
		// 	}
		// }
  

		// if (collider.IsTouchingLayers(groundLayer)){
		// 	return true;
		// }
		return false;
	}

	bool CheckWinCondition()
	{
		return true;
	}
	// Update is called once per frame
	void Update () {
		// Update win collider
		winCollider.transform.position = transform.position;

		if (Input.GetKeyDown("1")){
			GameObject.FindWithTag(curPlayer).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			curPlayer = "Red";
			GameObject.FindWithTag(curPlayer).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		} else if (Input.GetKeyDown("2")){
			GameObject.FindWithTag(curPlayer).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			curPlayer = "Blue";
			GameObject.FindWithTag(curPlayer).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		} else if (Input.GetKeyDown("3")){
			GameObject.FindWithTag(curPlayer).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			curPlayer = "Yellow";
			GameObject.FindWithTag(curPlayer).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		} else if (Input.GetKeyDown("r")){
			SceneManager.LoadScene("ex00");
		}

		if (curPlayer == gameObject.tag)
		{
			if (Input.GetKey("right")){
				transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
				if (Raycast(Vector2.right, groundLayer) || Raycast(Vector2.right, playerLayer)){
					transform.Translate(Vector3.left* Time.deltaTime * moveSpeed, Space.World);
				}

			}
			if (Input.GetKey("left")){
				transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
				if (Raycast(Vector2.left, groundLayer) || Raycast(Vector2.left, playerLayer)){
					transform.Translate(Vector3.right* Time.deltaTime * moveSpeed, Space.World);
				}
			}
			if (Input.GetKeyDown("space")){
				Jump();
			}
		}else {
		}
	}
}
