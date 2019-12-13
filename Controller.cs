﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform circle;
    public Transform outerCircle;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            circle.transform.position = pointA * -1;
            outerCircle.transform.position = pointA * -1;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }

       
    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = Vector2.zero;
            offset.x = pointB.x - pointA.x;
            offset.y = pointB.y - pointA.y;
            //Debug.Log(offset);

            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            
            moveCharacter(direction * -1);


            circle.transform.position = (new Vector2(pointA.x + direction.x, pointA.y + direction.y)) * -1;
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
    void moveCharacter(Vector2 newdirection)
    {
        
        Vector2 moveDir = newdirection * speed * Time.deltaTime;
        //Debug.Log(newdirection * -1);
        player.Translate(moveDir);
    }
   
}
