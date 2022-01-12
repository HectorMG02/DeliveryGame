using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 300f;
    [SerializeField] private float moveSpeed = 20f;

    int totalCount = 0;
    int itemsCount = 0;
    [SerializeField] SpawnManager spawnManager;



    private void Update()
    {
        Movement();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            itemsCount += 1;
            Destroy(other.gameObject);

            if (itemsCount >= 3)
            {
                spawnManager.SpawnDeliverPoint();
            }
            else
            {
                spawnManager.SpawnItem();
            }
        } 
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeliverPoint")
        {
            Delivered();
        }
    }

    void Movement()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }


    void Delivered()
    {
        totalCount += itemsCount;
        itemsCount = 0;
        
        spawnManager.HideDeliverPoint();
        spawnManager.SpawnItem();
    }



}


  