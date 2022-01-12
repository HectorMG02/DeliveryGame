using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject[] powerups;

    [SerializeField] private GameObject deliverPoint;
 

    private void Start()
    {
        deliverPoint.SetActive(false);
        SpawnItem();
    }

    public void SpawnItem()
    { 
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
    }
    
    public void SpawnDeliverPoint()
    {
        deliverPoint.SetActive(true);
    }
}
