using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCubes : MonoBehaviour
{

    public GameObject yellowCube;
    public GameObject blueCube;
    public Transform yellowCube_p;
    public Transform blueCube_p;
    

   
    // Start is called before the first frame update
    void Start()
    {
        int positions = Random.Range(1, 3);
        Debug.Log(positions);
        if (positions == 1)
        {
            Instantiate(yellowCube, yellowCube_p.position, Quaternion.identity);
            Instantiate(blueCube, blueCube_p.position, Quaternion.identity);
        } else if (positions == 2)
        {
            Instantiate(yellowCube, blueCube_p.position, Quaternion.identity);
            Instantiate(blueCube, yellowCube_p.position, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
