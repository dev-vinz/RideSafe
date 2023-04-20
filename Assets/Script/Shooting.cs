using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] GameObject score;

    private int force = 500;
    private bool hit = false;
    
    private Animator animator;
    private ScoreScript scoreScript;

    void Start()
    {
        TryGetComponent<Animator>(out animator);
        score.TryGetComponent<ScoreScript>(out scoreScript);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the car
        if (collision.gameObject.name == "Sedan" && !hit)
        {
            rigidBody.AddForce(new Vector3(0, rigidBody.mass * force, 0));
            hit = true;

            if(scoreScript != null)
            {
                scoreScript.increaseScore(10);
            }
        }

        if (collision.gameObject.name != "Sedan" && hit)
        {
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        if(animator != null)
        {
            animator.SetTrigger("Die");

            yield return new WaitForSeconds(1f);
        }

        Destroy(gameObject);
    }
}
