using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Vector3 winPos;
    public string nextLevelName;
    private Vector3 initPos;
    float speed= 9;
    bool isLeft;
    bool isRight;
    bool isForward;
    bool isBack;

    bool isX =true;
    bool isY =false;
    bool isZ =false;
    bool iswin;
    Vector3 point;
    float temp = 0;
    private void Start()
    {
        initPos = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y<-3 && !iswin)
        {
            transform.position =initPos;
            transform.rotation = Quaternion.identity;
             isX = true;
             isY = false;
             isZ = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Rigidbody>().isKinematic = true;

            if (isRight || isForward || isBack|| isLeft) return;
            if (isX)
            {
                if (!isY&&!isZ)
                {
                    point = new Vector3(transform.position.x - 1f, transform.position.y - 0.5f, transform.position.z);
                    isY = !isY;
                    isX = !isX;
                }
            }
            else
            {
                if (isY&&!isZ)
                {
                    point = new Vector3(transform.position.x - 0.5f, transform.position.y - 1f, transform.position.z);
                    isY = !isY;
                    isX = !isX;
                   
                }
                if (!isY && isZ)
                {
                    point = new Vector3(transform.position.x-0.5f, transform.position.y - 0.5f, transform.position.z);
                }
            }
            isLeft = true;
        }
        if (isLeft)
        {
            if (temp<90)
            {
                temp += speed;
                transform.RotateAround(point, new Vector3(0, 0, 1), speed);
            }
            else
            {
                temp = 0;
                isLeft = false;
                iswin = isWin();

            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Rigidbody>().isKinematic = true;

            if (isLeft || isForward || isBack||isRight) return;
            if (isX)
            {
                if (!isY && !isZ)
                {
                    point = new Vector3(transform.position.x + 1f, transform.position.y - 0.5f, transform.position.z);
                    isY = !isY;
                    isX = !isX;
                }
            }
            else
            {
                if (isY && !isZ)
                {
                    point = new Vector3(transform.position.x + 0.5f, transform.position.y - 1f, transform.position.z);
                    isY = !isY;
                    isX = !isX;
                   
                }
                if (!isY && isZ)
                {
                    point = new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, transform.position.z);
                }
            }
            isRight = true;
        }
        if (isRight)
        {
            if (temp > -90)
            {
                temp -= speed;
                transform.RotateAround(point, new Vector3(0, 0, 1), -speed);
            }
            else
            {
                temp = 0;
                isRight = false;
                iswin = isWin();

            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody>().isKinematic = true;

            if (isRight || isLeft || isBack||isForward) return;
            isForward = true;
            if (isX)
            {
                if (!isY&&!isZ)
                {
                    point = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z + 0.5f);
                }
            }
            else
            {
                if (isY&&!isZ)
                {
                    point = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 0.5f);
                    isY = !isY;
                    isZ = !isZ;
                   
                    return;
                }
                if (!isY && isZ)
                {
                    point = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z + 1f);
                    isY = !isY;
                    isZ = !isZ;
                }
            }
           
        }
        if (isForward)
        {
            if (temp < 90)
            {
                temp += speed;
                transform.RotateAround(point, new Vector3(1, 0, 0), speed);
            }
            else
            {
                temp = 0;
                isForward = false;
                iswin = isWin();

            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            if (isRight || isForward || isLeft||isBack) return;
            isBack = true;

            if (isX)
            {
                if (!isY && !isZ)
                {
                    point = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z - 0.5f);
                }
            }
            else
            {
                if (isY && !isZ)
                {
                    point = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z - 0.5f);
                    isY = !isY;
                    isZ = !isZ;
                    
                    return;
                }
                if (!isY && isZ)
                {
                    point = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z - 1f);
                    isY = !isY;
                    isZ = !isZ;
                }
            }
        }
        if (isBack)
        {
            if (temp > -90)
            {
                temp -= speed;
                transform.RotateAround(point, new Vector3(1, 0, 0), -speed);
            }
            else
            {
                temp = 0;
                isBack = false;
                iswin= isWin();
            }
        }
    }
    bool isWin()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        if (Mathf.RoundToInt(transform.position.x) == winPos.x && Mathf.RoundToInt(transform.position.y) == 1 && Mathf.RoundToInt(transform.position.z) == winPos.z)
        {
            if (isY)
            {
                if (nextLevelName != null && nextLevelName != "")
                {
                    GetComponent<BoxCollider>().enabled = false;
                    Invoke("ChangeScene", 2);
                }
                return true;
            }
        }
        return false;
    }
    void ChangeScene()
    {
       
            SceneManager.LoadScene(nextLevelName);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag =="yuan")
        {
            if (SceneManager.GetActiveScene().name == "Three")
            {
                foreach (var item in GetComponent<Three>().gos1)
                {
                    item.SetActive(true);
                }
            }
            if (SceneManager.GetActiveScene().name == "Five")
            {
                foreach (var item in GetComponent<Five>().gos)
                {
                    item.SetActive(true);
                }
            }
            
        }
        if (collision.transform.tag == "x")
        {
            foreach (var item in GetComponent<Three>().gos2)
            {
                item.SetActive(true);
            }
        }
        if (collision.transform.tag == "yellow")
        {
            if (isY)
            {
                if (SceneManager.GetActiveScene().name == "Four")
                {
                    foreach (var item in GetComponent<Four>().yellowGoList)
                    {
                        item.AddComponent<Rigidbody>();
                    }
                }
                if (SceneManager.GetActiveScene().name == "Five")
                {
                    foreach (var item in GetComponent<Five>().yellowGoList)
                    {
                        item.AddComponent<Rigidbody>();
                    }
                }
              
            }
        }
        if (collision.transform.tag == "win")
        {
            GetComponent<Five>().over.SetActive(true);
        }
    }
}
