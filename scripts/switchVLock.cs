using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class switchVLock : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private int priorityBoostAmount = 12;

    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;
    
    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["LockOn"];
    }

    private void LnEnable()
    {
        aimAction.performed += _ => StartLock();
        aimAction.canceled += _ => CancelLock();
    }

    private void LnDisable()
    {
        aimAction.performed -= _ => StartLock();
        aimAction.canceled -= _ => CancelLock();
    }

    private void StartLock()
    {
        virtualCamera.Priority += priorityBoostAmount; // Switches to this camera since 10 is added to 9 (19 > 10 - priority level of og camera)
    }

    private void CancelLock()
    {
        virtualCamera.Priority -= priorityBoostAmount;
    }
}
