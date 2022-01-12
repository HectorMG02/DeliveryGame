using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 300f;
    [SerializeField] private float moveSpeed = 20f;
    
    private void Update()
    {
        
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        
        transform.Translate(0, moveAmount, 0);
    }


    public void Die()
    {
        Destroy(gameObject);
    }
}


  