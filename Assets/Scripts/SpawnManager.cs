using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject powerUpPrefab;

    [SerializeField] private Sprite[] iconImages;

    [SerializeField] private GameObject deliverPoint;
    [SerializeField] private GameObject deliverAvailableText;

    private void Start()
    {
        deliverPoint.SetActive(false);
        SpawnItem();
        SpawnPowerUp();
    }

    public void SpawnPowerUp()
    {
        Vector3 powerUpPosition = new Vector3(Random.Range(-30f, 30f), 30f, 0);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(powerUpPosition, 1.0f);
         
        if (colliders.Length > 0)
        {
            SpawnPowerUp();
        }
        else
        {
            Instantiate(powerUpPrefab, powerUpPosition, Quaternion.identity);
        }
    }

    public void SpawnItem()
    { 
        
        int randomImage = Random.Range(0, iconImages.Length);
        itemPrefab.GetComponent<SpriteRenderer>().sprite = iconImages[randomImage];
        
        Vector3 itemPosition = new Vector3(Random.Range(-30f, 30f), 30f, 0);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(itemPosition, 1.0f);
         
        if (colliders.Length > 0)
        {
            SpawnItem();
        }
        else
        {
            Instantiate(itemPrefab, itemPosition, Quaternion.identity);
        }
        
    }


    public void HideDeliverPoint()
    {
        deliverPoint.SetActive(false);
        deliverAvailableText.SetActive(false);
    }
    
    public void SpawnDeliverPoint()
    {
        deliverPoint.SetActive(true);
        deliverAvailableText.SetActive(true);
    }
}
