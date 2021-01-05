using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Rigidbody projectile;
    [SerializeField] float speed = 50f;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody shoot = Instantiate(projectile, transform.position, transform.rotation); //動態產生物件
            shoot.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shoot.transform.GetComponent<Collider>());
        }

    }
}
