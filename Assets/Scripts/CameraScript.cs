using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //Vector3 rot = new Vector3(0, 0, 0);
    //[SerializeField] private float mouseSpeed = 1f; // Чувствительность мыши
    [SerializeField] private Transform hero;
    public float distanceAway = 1.7f;
    public float distanceUp = 1.3f;
    public float smooth = 2f;

    private Vector3 TargetPosition;

    void Update()
    {
        /*float MouseX = Input.GetAxis("Mouse X") * mouseSpeed;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSpeed;
        rot.x = rot.x - MouseY;
        rot.y = rot.y + MouseX;
        rot.z = 0;
        //transform.eulerAngles = new Vector3(0, rot.y, 0);
        transform.eulerAngles = rot;*/


        TargetPosition = hero.position + Vector3.up * distanceUp - hero.forward * distanceAway;
        transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * smooth);
        transform.LookAt(hero);
    }
}
