using UnityEngine;
using System.Collections;

public class AimShipT3 : MonoBehaviour
{//This goes onto the ship for the Engines System
    float currentX, currentZ, currentY;
    bool isMoving;
    public GameControllerT3 gameController;
    public Rigidbody bullet;//Makes it have physics
    public SpriteRenderer spriteRend;
    public Sprite aiming;
    public Sprite shoot;
    public Transform bulletExit;
    
    void Start()
    {
        spriteRend.sprite = aiming;
        currentX = this.transform.eulerAngles.x;
        currentY = this.transform.eulerAngles.y;
        isMoving = false;
    }
    void Update()
    {
        if (gameController.paused != true && gameController.backCamera.enabled == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                if (currentY > -10)
                {
                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, currentY = currentY - 1, this.transform.eulerAngles.z);
                }
                else
                    Debug.Log("This will play an Error.Sound");
            }
            #region Other Stuff
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                if (currentY < 10)
                {
                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, currentY = currentY + 1, this.transform.eulerAngles.z);
                }
                else
                    Debug.Log("This will play an Error.Sound");
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                if (currentX < 5)
                {
                    this.transform.eulerAngles = new Vector3(currentX = currentX + 1, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                }
                else
                    Debug.Log("This will play an Error.Sound");
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                if (currentX > -5)
                {
                    this.transform.eulerAngles = new Vector3(currentX = currentX - 1, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                }
                else
                    Debug.Log("This will play an Error.Sound");
            }
            #endregion
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(Shooting());
            }
        }
    }
    IEnumerator Shooting()
    {//                                                                          This mess makes it one z position farther than where it was before
        Rigidbody newBullet = Instantiate(bullet, new Vector3(bulletExit.transform.position.x, bulletExit.transform.position.y, bulletExit.transform.position.z), bullet.rotation) as Rigidbody;
        newBullet.AddForce(transform.forward * -30f, ForceMode.VelocityChange);
        spriteRend.sprite = shoot;
        float counter = 0f;
        float length = .1f;
        while (counter <= length)
        {//keeps the loop going until real time has met the desired length
            counter += Time.deltaTime;
            yield return null;
        }
        spriteRend.sprite = aiming;
    }
}