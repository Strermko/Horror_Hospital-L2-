using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] bool folowPlayer;

    Transform playerTrransform;
    Animator animator;
    bool isFollowing;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Find the player GameObject using the tag "Player"
        playerTrransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (playerTrransform == null)
        {
            Debug.LogError("Player not found! Make sure the player GameObject has the 'Player' tag.");
        }
    }
    void Update()
    {
        // Rotate towards the player
        if (playerTrransform != null && isFollowing)
        {
            RotateTowardsPlayer();
        }
    }

    public void Awakening()
    {
        animator.SetBool("Awaked", true);
    }

    void RotateTowardsPlayer()
    {
        // Calculate the direction from the enemy to the player
        Vector3 direction = playerTrransform.position - transform.position;

        // Ensure the enemy does not tilt when rotating towards the player
        direction.y = 0f;

        // Calculate the rotation needed to look at the player
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate the enemy towards the player
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void StartFollowing()
    {
        isFollowing = true;
    }
}
