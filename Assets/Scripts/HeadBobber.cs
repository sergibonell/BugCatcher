using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
public class HeadBobber : MonoBehaviour
{
    [SerializeField] float idleBobbingSpeed = 4f;
    [SerializeField] float walkingBobbingSpeed = 14f;
    [SerializeField] float bobbingAmount = 0.05f;
    [SerializeField] CinemachineVirtualCamera playerCamera;
    
    CharacterController characterController;
    float initialPosY = 0;
    float timer = 0;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        initialPosY = playerCamera.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.velocity.magnitude > 0.1f)
        {
            timer += Time.deltaTime * walkingBobbingSpeed;
        }
        else
        {
            timer += Time.deltaTime * idleBobbingSpeed;
        }
        playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x, initialPosY + Mathf.Sin(timer) * bobbingAmount, playerCamera.transform.localPosition.z);
    }
}
