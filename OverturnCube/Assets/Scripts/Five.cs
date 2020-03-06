using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Five : MonoBehaviour
{
    public GameObject[] gos;
    public GameObject[] yellowGoList;
    public GameObject over;
    public Button button;


    // Start is called before the first frame update
    void Start()
    {
        over.SetActive(false);
        button.onClick.AddListener(()=>{ Application.Quit(); });
        foreach (var item in gos)
        {
            item.SetActive(false);
        }
        yellowGoList = GameObject.FindGameObjectsWithTag("yellow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
