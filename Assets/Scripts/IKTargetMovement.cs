using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTargetMovement : MonoBehaviour
{
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float vSpeed = Input.GetAxis("Vertical");
        float hSpeed = Input.GetAxis("Horizontal");
        
        transform.position += Vector3.forward * vSpeed + Vector3.right * hSpeed;
    }
}
