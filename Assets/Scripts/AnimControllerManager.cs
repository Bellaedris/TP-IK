using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControllerManager : MonoBehaviour
{

    private Animator anim;

    private float vBlend;
    private float hBlend;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        vBlend = Input.GetAxis("Vertical");
        hBlend = Input.GetAxis("Horizontal");

        anim.SetFloat("VBlend", vBlend);
        anim.SetFloat("HBlend", hBlend);
    }
}
