using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTests : MonoBehaviour
{
    [SerializeField] private InputControls _controls;

    private void OnEnable()
    {
        _controls.QPortalUser.Movement.performed += Movement_performed;
        _controls.QPortalUser.Movement.Enable();
    }
    private void OnDisable()
    {
        _controls.QPortalUser.Movement.performed -= Movement_performed;
        _controls.QPortalUser.Movement.Disable();
    }

    private void Movement_performed(UnityEngine.Experimental.Input.InputAction.CallbackContext obj)
    {
        Debug.Log("movement");
    }
}
