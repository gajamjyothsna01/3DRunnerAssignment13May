using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawingCoins : MonoBehaviour
{
    public Transform playerPosition;
    Vector3 randomPoint;
    //public GameObject prefab;
    //public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SpawnCoins()
    {
      
          randomPoint  = playerPosition.position + new Vector3(UnityEngine.Random.Range(-10f, 20f), 1f, UnityEngine.Random.Range(-1.3f, 3.5f));
          //Debug.Log(randomPoint);
        
       
        GameObject temp = PoolScript.instance.GetObjectsFromPool("CoinS");
       
        //GameObject temp = Instantiate(prefab, transform);
        if (temp != null)
        {
            
            temp.SetActive(true);
            //temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
            temp.transform.position = randomPoint;


       }
    }
    private void SpawnGCoins()
    {

        randomPoint = playerPosition.position + new Vector3(UnityEngine.Random.Range(-10f, 50f), 1f, UnityEngine.Random.Range(-1.3f, 3.5f));
        //Debug.Log(randomPoint);


        GameObject temp = PoolScript.instance.GetObjectsFromPool("CoinG");
       
        //GameObject temp = Instantiate(prefab, transform);
        if (temp != null)
        {
            
            temp.SetActive(true);
            //temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
            temp.transform.position = randomPoint;


        }
    }
    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            UnityEngine.Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            UnityEngine.Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            UnityEngine.Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCoins();
        SpawnGCoins();
    }

}
