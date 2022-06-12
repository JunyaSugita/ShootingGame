using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += 0.01f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= 0.01f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.z += 0.01f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.z -= 0.01f;
        }
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
