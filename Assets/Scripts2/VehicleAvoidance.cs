using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAvoidance : MonoBehaviour {

    public float speed = 10f;
    public float mass = 5f;
    public float force = 40f;
    public float minimumDistToAvoid = 10f;//피할수있는 거리 

    private float curSpeed;
    private Vector3 targetPoint;

    void Start()
    {
        mass = 5f;
        targetPoint = Vector3.zero;//벡터3값은 0
    }
    void OnGUI()
    {
        GUILayout.Label("Click anyWhere to move the vehicle.");
    }
    void Update()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)&& Physics.Raycast(ray, out hit, 100f))
        {
            targetPoint = hit.point;
        }
        Vector3 dir = (targetPoint - transform.position);
        dir.Normalize();
        AvoidObstacles(ref dir);

        if (Vector3.Distance(targetPoint, transform.position) < 3f) return;
        curSpeed = speed * Time.deltaTime;
        var rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation , rot ,5f*Time.deltaTime);
        transform.position += transform.forward * curSpeed;
    }
    public void AvoidObstacles(ref Vector3 dir)
    {
        RaycastHit hit;
        int layerMask = 1 << 8;//1부터8까지
        if(Physics.Raycast(transform.position,transform.forward,out hit,minimumDistToAvoid,layerMask))
        {
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0;
            dir = transform.forward + hitNormal * force;
        }
    }

}
