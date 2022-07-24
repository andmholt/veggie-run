using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jello : MonoBehaviour
{
    private Animator animator;
    public bool jiggle = false;
    public bool jump = false;

    private AudioSource squish;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        squish = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SetParameters();

        if ((jiggle || jump) && !squish.isPlaying)
            squish.Play();
    }

    private void SetParameters()
    {
        animator.SetBool("Jiggle", jiggle);
        animator.SetBool("Jump", jump);
    }
}
