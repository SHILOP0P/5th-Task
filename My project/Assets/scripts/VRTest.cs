using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRTest : MonoBehaviour
{
    public int x = 0;
    public Text Mytxt;
    public GameObject MyTest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Mytxt.text = x.ToString();
        x++;
        if (x > 100)
        {
            MyTest.SetActive(false);
        }
        
    }
}
