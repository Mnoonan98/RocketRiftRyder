using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("hit detected");
        Destroy(other.gameObject);
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit detected");
        Destroy(collision.gameObject);
        this.gameObject.SetActive(false);
    }
}
