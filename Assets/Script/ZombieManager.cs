using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            animator.SetTrigger("Attack");
        }

        float speed = Input.GetAxis("Vertical");
        if (speed != 0)
        {
            animator.SetFloat("Speed", speed);
        }

        float direction = Input.GetAxis("Horizontal");
        if (direction != 0)
        {
            animator.SetFloat("Direction", direction);
        }
    }
}
