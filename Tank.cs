using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankNamespace;

public class Tank : MonoBehaviour
{
    [SerializeField]
    private float a = 0.1f;
    [SerializeField]
    private float TowerRotateSpeed = 1f;
    [SerializeField]
    private Renderer trackL;
    [SerializeField]
    private Renderer trackR;
    [SerializeField]
    private float trackSpeed = 0.04f;
    [SerializeField]
    private Transform barrel;
    [SerializeField]
    private float barrelspeed = 5f;
    [SerializeField]
    private float maxAngle = 25;
    [SerializeField]
    private float minAngle = 5;
    [SerializeField]
    private float angle;

    //
    Tank_Namespace Tank_Namespace = new Tank_Namespace();
    //



    void Start()
    {
        Tank_Namespace.TankTowerControl = GameObject.Find("KV1-Tower");
        trackL = GameObject.Find("track-L").GetComponent<MeshRenderer>();
        trackR = GameObject.Find("track-R").GetComponent<MeshRenderer>();
        barrel = GameObject.Find("KV1-Barrel-a").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //左右
        float v = Input.GetAxis("Vertical"); //前後
        float x = Input.GetAxis("Mouse X");

        angle = angle + Input.GetAxis("Mouse ScrollWheel") * barrelspeed;
        Vector3 barrelAngle = barrel.localEulerAngles;
        barrelAngle.x = angle;
        barrel.localEulerAngles = barrelAngle;

        this.transform.Translate(Vector3.back * v * a);
        this.transform.Rotate(0, 1 * h, 0);
        Tank_Namespace.TankTowerControl.transform.Rotate(0, 0, TowerRotateSpeed * x);
        TrackRender(v,h);
    }

    void TrackRender(float v,float h)
    {
        Vector2 TrackLOffest = trackL.material.mainTextureOffset;
        if (v != 0)
        {
            TrackLOffest.x = TrackLOffest.x + trackSpeed * v;//前進後退中
        }
        else 
        {
            TrackLOffest.x = TrackLOffest.x + trackSpeed * h;//停止前進後退
        }
        trackL.material.mainTextureOffset = TrackLOffest;

        Vector2 TrackROffest = trackR.material.mainTextureOffset;
        if (v != 0)
        {
            TrackROffest.x = TrackROffest.x + trackSpeed * v; 
        }
        else
        {
            TrackROffest.x = TrackROffest.x + trackSpeed * -h; 
        }
        trackR.material.mainTextureOffset = TrackROffest;
    }
}
