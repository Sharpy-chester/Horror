using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRaycast : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] Transform playerCameraTransform;
    [SerializeField] float interactDist;
    private static InteractRaycast _instance;
    public static InteractRaycast Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Update()
    {
        Physics.Raycast(playerCameraTransform.position, playerCameraTransform.TransformDirection(Vector3.forward), out hit, interactDist);
    }

    public RaycastHit RayHit()
    {
        return hit;
    }
}
