using UnityEngine;
using System.Collections;

public class AimShip : MonoBehaviour
{//This goes onto the ship for the Engines System
    float currentX, currentZ, currentY;
    bool isMoving;
    public GameControllerT2 gameController;

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
        if (gameController.paused != true)
        {
            #region MovementAndRestrictions
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                if (isMoving == false)
                {
                    isMoving = true;
                    StartCoroutine("MoveLeft");
                }
                else
                    Debug.Log("Error Sound plays");
            }
            #region OtherStuff
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                if (isMoving == false)
                {
                    isMoving = true;
                    StartCoroutine("MoveRight");
                }
                else
                    Debug.Log("Error Sound plays");
            }
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            {
                if (isMoving == false)
                {
                    isMoving = true;
                    StartCoroutine("MoveUp");
                }
                else
                    Debug.Log("Error Sound plays");
            }
            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.A))
            {
                if (isMoving == false)
                {
                    isMoving = true;
                    StartCoroutine("MoveDown");
                }
                else
                    Debug.Log("Error Sound plays");
            }
            #endregion
            #endregion

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(Shooting());
            }
        }
    }

    #region IEnumerator Stuff
    IEnumerator MoveLeft()
    {
        if (currentY > -10)
        {
            float targetY = currentY - 5f;
            while (currentY > targetY)
            {
                this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, currentY = currentY - 0.3f, this.transform.eulerAngles.z);
                yield return null;
            }
        }
        else
            Debug.Log("This will play an Error.Sound");
        isMoving = false;
    }

    #region OtherMovements
    IEnumerator MoveRight()
    {
        if (currentY < 10)
        {
            float targetY = currentY + 5f;
            while (currentY < targetY)
            {
                this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, currentY = currentY + 0.3f, this.transform.eulerAngles.z);
                yield return null;
            }
        }
        else
            Debug.Log("This will play an Error.Sound");
        isMoving = false;
    }
    IEnumerator MoveDown()
    {
        if (currentX > -5)
        {
            float targetX = currentX - 5f;
            while (currentX > targetX)
            {
                this.transform.eulerAngles = new Vector3(currentX = currentX - 0.3f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                yield return null;
            }
        }
        else
            Debug.Log("This will play an Error.Sound");
        isMoving = false;
    }
    IEnumerator MoveUp()
    {
        if (currentX < 5)
        {
            float targetX = currentX + 5f;
            while (currentX < targetX)
            {
                this.transform.eulerAngles = new Vector3(currentX = currentX + 0.3f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                yield return null;
            }
        }
        else
            Debug.Log("This will play an Error.Sound");
        isMoving = false;
    }
    #endregion

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
    #endregion
}