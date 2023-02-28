using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour
{
    public GameObject Spider;

    public void Update()
    {
        Instantiate(Spider);
    }
}
