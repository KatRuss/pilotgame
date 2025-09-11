using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform[] povs;
    [SerializeField] float speed;

    int index = 0;
    private Vector3 target;

    void Update()
    {
        //TODO: Ability to change camera position to a specific location
        target = povs[index].position;

    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        transform.forward = povs[index].forward;
    }
}
