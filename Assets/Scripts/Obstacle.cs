using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Driver driver;

    private void Start()
    {
        driver = FindObjectOfType<Driver>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            driver.itemsCount--;
            driver.UpdateItemsText();
        }
    }
}
