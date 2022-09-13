using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float engineSpeed = 2;
    public float turnSpeed = 70;
    private Renderer rend;

    private List<GameObject> corners;

    private Vector3 frontRCorner;
    private Vector3 frontLCorner;
    private Vector3 backRCorner;
    private Vector3 backLCorner;

    Color color = new Color(0.0f, 10.0f, 1.0f);
    
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();

        corners = new List<GameObject>();

        corners.Add(new GameObject("frontRCorner"));
        corners.Add(new GameObject("frontLCorner"));
        corners.Add(new GameObject("backRCorner"));
        corners.Add(new GameObject("backLCorner"));

        frontRCorner = new Vector3(rend.bounds.max.x, rend.bounds.min.y, rend.bounds.max.z);
        frontLCorner = new Vector3(rend.bounds.min.x, rend.bounds.min.y, rend.bounds.max.z);
        backRCorner = new Vector3(rend.bounds.max.x, rend.bounds.min.y, rend.bounds.min.z);
        backLCorner = new Vector3(rend.bounds.min.x, rend.bounds.min.y, rend.bounds.min.z);

         foreach (GameObject corner in corners){
            corner.transform.SetParent(transform);
            if (corner.name == "frontRCorner"){
                corner.transform.position = frontRCorner;
            }
            if (corner.name == "frontLCorner"){
                corner.transform.position = frontLCorner;
            }
            if (corner.name == "backRCorner"){
                corner.transform.position = backRCorner;
            }
            if (corner.name == "backLCorner"){
                corner.transform.position = backLCorner;
            }
        }
    }

    private void FixedUpdate() {
        movement();
    }

    // Update is called once per frame
    void Update()
    {
        // Draw rays from bottom 4 corners of car
        foreach(GameObject corner in corners){
             Debug.DrawLine(corner.transform.position, corner.transform.position + (-transform.up * 0.5f), color);
        }
    }

    private void movement(){
        // Get Car Transform
        Vector3 pos = transform.position;

        // Get up/down keys pressed
        float acceleration = Input.GetAxis("Vertical");
        float turning = Input.GetAxis("Horizontal");

        // Get new position of car when accelerating
        pos += transform.forward * acceleration * engineSpeed * Time.deltaTime;

        // Rotate car when turning
        transform.Rotate(0, turning * turnSpeed * Time.deltaTime, 0);

        // Update transform with new position
        transform.position = pos;
    }
}
