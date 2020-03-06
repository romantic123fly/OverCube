using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    public Button start;
    public Button one;
    public Button two;
    public Button three;
    public Button four;
    public Button five;
    public GameObject p1;
    public GameObject p2;
    // Start is called before the first frame update
    void Start()
    {
        p2.SetActive(false);
        start.onClick.AddListener(()=> { p1.SetActive(false);p2.SetActive(true); });
        one.onClick.AddListener(()=> { SceneManager.LoadScene("One");});
        two.onClick.AddListener(()=> { SceneManager.LoadScene("Two");});
        three.onClick.AddListener(()=> { SceneManager.LoadScene("Three");});
        four.onClick.AddListener(()=> { SceneManager.LoadScene("Four");});
        five.onClick.AddListener(()=> { SceneManager.LoadScene("Five");});
    }

}
