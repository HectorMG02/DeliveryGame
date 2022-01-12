using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 300f;
    [SerializeField] private float baseSpeed = 20f;
    [SerializeField] private float boostSpeed = 35f;

    private float moveSpeed;

    public int totalCount = 0;
    public int itemsCount = 0;
    [SerializeField] SpawnManager spawnManager;

    [SerializeField] private Text totalText;
    [SerializeField] private Text itemsText;

    private void Start()
    {
        
        moveSpeed = baseSpeed;
    }

    private void Update()
    {
        Movement();

        if (itemsCount <= 0)
        {
            itemsCount = 0;
            UpdateItemsText();
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            itemsCount += 1;
            UpdateItemsText();
            Destroy(other.gameObject);

            if (itemsCount >= Random.Range(1, 5))
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
        else if (other.gameObject.tag == "PowerUp")
        {
            Destroy(other.gameObject);
            StartCoroutine(Boost());
        }
    }

    void Movement()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount;

        moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }


    void Delivered()
    {
        totalCount += itemsCount;
        itemsCount = 0;

        UpdateTotalText();
        UpdateItemsText();

        spawnManager.HideDeliverPoint();
        spawnManager.SpawnItem();
    }


    public void UpdateTotalText()
    {
        totalText.text = "Objetos entregados: " + totalCount.ToString();
    }

    public void UpdateItemsText()
    {
        itemsText.text = "Objetos recogidos: " + itemsCount.ToString();
    }


    IEnumerator Boost()
    {
        moveSpeed = boostSpeed;
        yield return new WaitForSeconds(5);
        moveSpeed = baseSpeed;
        yield return new WaitForSeconds(3);
        spawnManager.SpawnPowerUp();
    }

}


   