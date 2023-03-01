using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour
{
    public int wave;
    public GameObject Spider;
    public bool newSpider;
    
    
    public SpiderSpawner()
    {
        wave = 1;
        newSpider = false;
    }

    
    public void Update()
    {
    }

    public void SpawnSpider()
    {
        if(newSpider == true)
        {
            Instantiate(Spider);
            newSpider = false;
        }
    }


}
