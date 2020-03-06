using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        for (int j = 0; j < 6; j++)
        {
            var a = Instantiate(Resources.Load<GameObject>("Prefab/Base"), transform.position + new Vector3(0, -0.1f, j), Quaternion.identity);
            for (int i = 0; i < 10; i++)
            {
                Instantiate(Resources.Load<GameObject>("Prefab/Base"), a.transform.position + new Vector3(i+1, 0, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
