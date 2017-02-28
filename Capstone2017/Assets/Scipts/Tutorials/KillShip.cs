using UnityEngine;
using System.Collections;

public class KillShip : MonoBehaviour
{
    public Rigidbody bullet;//Makes it have physics
    public float bulletExit;
    public MeshRenderer MeshMe;
    Quaternion rotationB;

    // Use this for initialization
    void Start()
    {
        MeshMe.material = MeshMe.materials[0];
        bulletExit = this.transform.position.z + 1.5f;
        InvokeRepeating("Shoot", 5, 3);
        rotationB.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 90, this.transform.eulerAngles.z);
    }

    void Shoot()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {//                                                                          This mess makes it one z position farther than where it was before
        Rigidbody newBullet = Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y, bulletExit), bullet.rotation) as Rigidbody;
        newBullet.AddRelativeForce(this.transform.forward, ForceMode.VelocityChange);
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
    }
    void OnTriggerEnter(Collider col)
    {//Checks to see if you hit, if you did destroys it
        Destroy(this.gameObject);
    }
}
