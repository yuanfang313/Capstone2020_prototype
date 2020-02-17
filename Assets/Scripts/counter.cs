using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counter : MonoBehaviour
{
    public Text output;
    public float speed;
    float count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count = count + speed;
        int number = (int)count;
        output.text = "score: " + number.ToString();
        Debug.Log(count);
    }
}
