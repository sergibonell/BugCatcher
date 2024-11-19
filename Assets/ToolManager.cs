using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class ToolManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerCam;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = playerCam.transform.rotation;
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        IWeapon weapon = GetComponentInChildren<IWeapon>();
        if (weapon != null && ctx.performed)
        {
            weapon.Action();
        }
    }
}
