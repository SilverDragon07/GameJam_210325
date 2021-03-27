using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveX = 0.1f;
    public float MoveY = 0.1f;
    private float horizotal = 0.01f;
    private float Vertical = 0.01f;

    void Update()
    {
        horizotal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizotal * MoveX, 0, Vertical * MoveY), Space.World);
    }
}
