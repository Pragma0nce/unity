using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Update is called once per frame
Vector3 mouse_pos;
Transform target; //Assign to the object you want to rotate
Vector3 object_pos;
float angle;

    // Use this for initialization
    void Start () {
        
    }


     void Update ()
     {
         //rotation
         Vector3 mousePos = Input.mousePosition;
         mousePos.z = 5.23f;

         Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
         mousePos.x = mousePos.x - objectPos.x;
         mousePos.y = mousePos.y - objectPos.y;

         float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
         angle += 90.0f;
         transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}