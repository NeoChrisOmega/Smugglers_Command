using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour
{
    public Rigidbody bullet;//Makes it have physics
    public float bulletExit;
    //public MeshRenderer MeshMe;

    Transform turret;
    Transform target;
    float timer;

    // Use this for initialization
    void Start()
    {
        turret = this.transform;
        target = GameObject.Find("Ship").transform;
        //MeshMe.material = MeshMe.materials[2];
        bulletExit = this.transform.position.z + 1.5f;
        //InvokeRepeating("Shoot", 10, 10);
    }

    void Update()
    {
        turret.transform.LookAt(target);
        timer += Time.deltaTime;
        if (timer>10.0f)
        {
            Rigidbody newBullet = Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y, bulletExit), this.transform.rotation) as Rigidbody;
            newBullet.AddRelativeForce(Vector3.forward * 30, ForceMode.VelocityChange);
            timer = 0.0f;
        }
    }
    void OnTriggerEnter(Collider col)
    {//Checks to see if you hit, if you did destroys it
        Destroy(this.gameObject);
        Destroy(col.gameObject);
    }

    /*
    void Shoot()
    {
        //StartCoroutine(Shooting());
    }
    IEnumerator Shooting()
    {//           
        Rigidbody newBullet = Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y, bulletExit), bullet.rotation) as Rigidbody;
        //newBullet.AddRelativeTorque(transform.forward * -5, ForceMode.VelocityChange);
        newBullet.AddRelativeForce(transform.forward * 5, ForceMode.VelocityChange);
        MeshMe.material = MeshMe.materials[2];
        float counter = 0f;
        float length = .1f;
        Debug.Log("Before calling Mesh");
        while (counter <= length)
        {//keeps the loop going until real time has met the desired length
            counter += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Called Mesh");
        MeshMe.material = MeshMe.materials[1];
    }*/
}
