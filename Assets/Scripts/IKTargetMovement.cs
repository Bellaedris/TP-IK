using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTargetMovement : MonoBehaviour
{
    public float speed = 1f;

    public Transform target1;

    public Transform target2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            target1.position += Vector3.left * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            target1.position += Vector3.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
            target1.position += Vector3.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            target1.position += Vector3.back * speed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Q))
            target2.position += Vector3.left * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            target2.position += Vector3.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Z))
            target2.position += Vector3.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            target2.position += Vector3.back * speed * Time.deltaTime;
    }
}
