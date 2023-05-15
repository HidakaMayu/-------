using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Vector3 orgPos;
    [SerializeField] float moveDistance;
    [SerializeField] float moveSpeed;

    private void Awake()
    {
        orgPos = this.transform.position;
    }

    private void FixedUpdate()
    {
        this.transform.position = orgPos + new Vector3(0, 0, Mathf.Sin(Time.time * moveSpeed) * moveDistance);
    }
}