using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Three : MonoBehaviour
{
    public GameObject[] gos1;
    public GameObject[] gos2;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in gos1)
        {
            item.SetActive(false);
        }
        foreach (var item in gos2)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
