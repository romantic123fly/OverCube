using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Four : MonoBehaviour
{
    public GameObject[] yellowGoList;
    // Start is called before the first frame update
    void Start()
    {
        yellowGoList = GameObject.FindGameObjectsWithTag("yellow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
