using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    //camera will follow this
    public Transform target;


    //distance from target
    public float height;


    public float angle;
    public float rotationalSpeed = 150;
    public float radius;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float cameraX = target.position.x + (radius * Mathf.Cos(angle));
        float cameraY = target.position.y + height;
        float cameraZ = target.position.z + (radius * Mathf.Sin(angle));

        transform.position = new Vector3(cameraX, cameraY, cameraZ);

        if (Input.GetKey(KeyCode.A))
        {
            angle = angle - rotationalSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            angle = angle + rotationalSpeed * Time.deltaTime;
        }

        transform.LookAt(target.position);


    }
}
