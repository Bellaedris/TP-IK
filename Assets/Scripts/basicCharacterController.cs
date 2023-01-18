using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicCharacterController : MonoBehaviour
{

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
            transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
