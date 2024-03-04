using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public AudioSource footstepsSound, breathingSound;
    public CharacterController controller;
    public float speed = 7f;
    public float distance = 7f;
    public Vector3 velocity;
    public float gravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        footstepsSound.enabled = false;
        breathingSound.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //footstepsSound.enabled = true;
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * X + transform.forward * Z;
        if (move.magnitude > 0)
            footstepsSound.enabled = true;
        else
            footstepsSound.enabled = false;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
 
        controller.Move(velocity * Time.deltaTime);

    }
}
