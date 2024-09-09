using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public void OnFire(InputAction.CallbackContext ctx)
    {
        IWeapon weapon = GetComponentInChildren<IWeapon>();
        if (weapon != null && ctx.performed)
        {
            weapon.Action();
        }
    }
}
