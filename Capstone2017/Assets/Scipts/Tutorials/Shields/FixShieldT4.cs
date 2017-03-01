using UnityEngine;
using System.Collections;

public class FixShieldT4 : MonoBehaviour
{
    #region Comment Keys

    //-PausedStuff-
    /*
    This is everything that happens when the game is paused,
    or things that can pause the game
    */

    //-ConsoleStuff-
    /*
    This is for anything that will appear at the bottom where the console is,
    anything that it represents, or effected by
    */

    //-CameraStuff-
    /*
    This is anything that changes or is effected by which camera is shown
    */

    //-AudioStuff-
    /*
    Anything that is, plays, or needs audio
    */

    //-ObjectInteraction-
    /*
    This will involve anything and everything that the game world can
    interact with itself. For example the objects hitting the ship,
    or the ship shooting a bullet, or spawnpoints
    */

    //-ObjectAdjustment-
    /*
    This is anything that will change or adjust an object. An example would
    be an animation, movement
    */

    //-GameInteraction-
    /*
    Anything that can change more than just the stuff within this one level.
    For example, entering or exiting a level, variables that are needed outside
    this particular level, and other things like that
    */
    #endregion

    #region TheVariables
    public GameControllerT4 gameController;
    //public CheckColliders checkCollider;

    public GameObject carOrange, truckSkyBlue, carBluishGreen, truckYellow, carBlue, truckVermillion, carReddishPurple;
    public Material orangeEmpty, orange1fourths, orange2fourths, orange3fourths, orangeFull
        , skyBlue, bluishGreen, yellow, blue, vermillion, reddishPurple;

    public GameObject carSelection, backgroundSelection;
    int selectedCar;
    bool isSelected;

    bool[,] carGrid = new bool[6, 6];
    int[][] carList;
    int rpc_lx = 0, rpc_ly = 0, rpc_rx = 1, rpc_ry = 0, //ReddishPurpleCar Left x and y, Right x and y
        vt_ux = 5, vt_uy = 0, vt_dx = 5, vt_dy = 2,     //VermillionTruck   2, 3
        sbt_ux = 0, sbt_uy = 1, sbt_dx = 0, sbt_dy = 3, //SkyBlueTruck      4, 5
        yt_ux = 3, yt_uy = 1, yt_dx = 3, yt_dy = 3,     //YellowTruck       6, 7
        oc_lx = 1, oc_ly = 2, oc_rx = 2, oc_ry = 2,     //OrangeCar         8, 9
        bc_lx = 4, bc_ly = 4, bc_rx = 5, bc_ry = 4,     //BlueCar           10, 11
        bgc_ux = 0, bgc_uy = 4, bgc_dx = 0, bgc_dy = 5; //BlueishGreenCar   12, 13
#endregion

    void Start()
    {
        selectedCar = 4;
        isSelected = false;

        carList = new int[][]
       {    new int[] {rpc_lx, rpc_ly },   //ReddishPurpleCar   Left   0
            new int[] {rpc_rx, rpc_ry },   //ReddishPurpleCar   Right  1
            new int[] {vt_ux, vt_uy },     //VermillionTruck    Up     2
            new int[] {vt_dx, vt_dy },     //VermillionTruck    Down   3
            new int[] {sbt_ux, sbt_uy },   //SkyBlueTruck       Up     4
            new int[] {sbt_dx, sbt_dy },   //SkyBlueTruck       Down   5
            new int[] {yt_ux, yt_uy },     //YellowTruck        Up     6
            new int[] {yt_dx, yt_dy },     //YellowTruck        Down   7
            new int[] {oc_lx, oc_ly },     //OrangeCar          Left   8
            new int[] {oc_rx, oc_ry },     //OrangeCar          Right  9
            new int[] {bc_lx, bc_ly },     //BlueCar            Left   10  
            new int[] {bc_rx, bc_ry },     //BlueCar            Right  11
            new int[] {bgc_ux, bgc_uy },   //BlueishGreenCar    Up     12
            new int[] {bgc_dx, bgc_dy } }; //BlueishGreenCar    Down   13
        carGrid[0, 0] = true;      //RedishPurpleCar
        carGrid[1, 0] = true;
        carGrid[5, 0] = true;
        carGrid[0, 1] = true;
        carGrid[3, 1] = true;
        carGrid[5, 1] = true;
        carGrid[0, 2] = true;
        carGrid[1, 2] = true;
        carGrid[2, 2] = true;
        carGrid[3, 2] = true;
        carGrid[5, 2] = true;
        carGrid[0, 3] = true;
        carGrid[3, 3] = true;
        carGrid[0, 4] = true;
        carGrid[4, 4] = true;
        carGrid[5, 4] = true;
        carGrid[0, 5] = true;
    }

    void Update()
    {
        Debug.Log("[0,0]" + carGrid[0, 0] + " [1,0]" + carGrid[1, 0] + " [2,0]" + carGrid[2, 0] + " [3,0]" + carGrid[3, 0] + " [4,0]" + carGrid[4, 0] + " [5,0]" + carGrid[5, 0]
              + "\n[0,1]" + carGrid[0, 1] + " [1,1]" + carGrid[1, 1] + " [2,1]" + carGrid[2, 1] + " [3,1]" + carGrid[3, 1] + " [4,1]" + carGrid[4, 1] + " [5,1]" + carGrid[5, 1]
              + "\n[0,2]" + carGrid[0, 2] + " [1,2]" + carGrid[1, 2] + " [2,2]" + carGrid[2, 2] + " [3,2]" + carGrid[3, 2] + " [4,2]" + carGrid[4, 2] + " [5,2]" + carGrid[5, 2]
              + "\n[0,3]" + carGrid[0, 3] + " [1,3]" + carGrid[1, 3] + " [2,3]" + carGrid[2, 3] + " [3,3]" + carGrid[3, 3] + " [4,3]" + carGrid[4, 3] + " [5,3]" + carGrid[5, 3]
              + "\n[0,4]" + carGrid[0, 4] + " [1,4]" + carGrid[1, 4] + " [2,4]" + carGrid[2, 4] + " [3,4]" + carGrid[3, 4] + " [4,4]" + carGrid[4, 4] + " [5,4]" + carGrid[5, 4]
              + "\n[0,5]" + carGrid[0, 5] + " [1,5]" + carGrid[1, 5] + " [2,5]" + carGrid[2, 5] + " [3,5]" + carGrid[3, 5] + " [4,5]" + carGrid[4, 5] + " [5,5]" + carGrid[5, 5]);
        Debug.Log("carlist[][]\nReddishPurpleCar:\nLeft: " + rpc_lx + ", " + rpc_ly + "\nRight: " + rpc_rx + ", " + rpc_ry + "\nYellowTruck:\nLeft:" + yt_ux + ", " + yt_uy + "\nRight: " + yt_dx + ", " + yt_dy);
        
        if (gameController.paused != true && gameController.interiorCamera.enabled == true)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (isSelected == false)
                {
                    isSelected = true;
                }
                else
                {
                    isSelected = false;
                }
            }

            #region Moving The selection
            if (isSelected == false)
            {
                if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
                {
                    if (backgroundSelection.transform.position.z < 0)
                    {
                        selectedCar = selectedCar - 1;
                        backgroundSelection.transform.position = new Vector3(backgroundSelection.transform.position.x, backgroundSelection.transform.position.y, backgroundSelection.transform.position.z + 4);
                    }
                    else if (carSelection.transform.position.z > -8)
                    {
                        selectedCar = selectedCar - 1;
                        carSelection.transform.position = new Vector3(carSelection.transform.position.x, carSelection.transform.position.y, carSelection.transform.position.z - 4);
                    }
                    else
                    {
                        Debug.Log("Error sound");
                    }
                }
                if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
                {
                    if (backgroundSelection.transform.position.z > 0)
                    {
                        selectedCar = selectedCar + 1;
                        backgroundSelection.transform.position = new Vector3(backgroundSelection.transform.position.x, backgroundSelection.transform.position.y, backgroundSelection.transform.position.z - 4);
                    }
                    else if (carSelection.transform.position.z < 12)
                    {
                        selectedCar = selectedCar + 1;
                        carSelection.transform.position = new Vector3(carSelection.transform.position.x, carSelection.transform.position.y, carSelection.transform.position.z + 4);
                    }
                    else
                    {
                        Debug.Log("error sound");
                    }
                }
            }
            #endregion

            #region Moving the cars
            if (isSelected == true)
            {
                if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
                {
                    switch (selectedCar)
                    {
                        #region ReddishPurpleCar
                        case 1:
                            Debug.Log("BlueCar doesn't move down");
                            break;
                        #endregion
                        #region VermillionTruck
                        case 2:
                            vt_uy--;
                            if (vt_uy >= 0)
                            {
                                if (carGrid[vt_ux, vt_uy] == false)
                                {
                                    truckVermillion.transform.position = new Vector3(truckVermillion.transform.position.x, truckVermillion.transform.position.y, truckVermillion.transform.position.z + 1);
                                    carGrid[vt_ux, vt_uy] = true;
                                    carGrid[vt_dx, vt_dy] = false;
                                }
                                else
                                {
                                    Debug.Log("Error sound, something in the way");
                                    vt_uy++;
                                    vt_dy++;
                                }
                            }
                            else
                            {
                                vt_uy++;
                                vt_dy++;
                                Debug.Log("Error sound, out of bounds");
                            }
                            vt_dy--;
                            break;
                        #endregion
                        #region SkyBlueTruck
                        case 3:
                            sbt_uy--;
                            if (sbt_uy >= 0)
                            {
                                if (carGrid[sbt_ux, sbt_uy] == false)
                                {
                                    truckSkyBlue.transform.position = new Vector3(truckSkyBlue.transform.position.x, truckSkyBlue.transform.position.y, truckSkyBlue.transform.position.z + 1);
                                    carGrid[sbt_ux, sbt_uy] = true;
                                    carGrid[sbt_dx, sbt_dy] = false;
                                }
                                else
                                {
                                    Debug.Log("Error sound, something in the way");
                                    sbt_uy++;
                                    sbt_dy++;
                                }
                            }
                            else
                            {
                                sbt_uy++;
                                sbt_dy++;
                                Debug.Log("Error sound, out of bounds");
                            }
                            sbt_dy--;
                            break;
                        #endregion
                        #region YellowTruck
                        case 4:
                            yt_uy--;
                            if (yt_uy >= 0)
                            {
                                if (carGrid[yt_ux, yt_uy] == false)
                                {
                                    truckYellow.transform.position = new Vector3(truckYellow.transform.position.x, truckYellow.transform.position.y, truckYellow.transform.position.z + 1);
                                    carGrid[yt_ux, yt_uy] = true;
                                    carGrid[yt_dx, yt_dy] = false;
                                }
                                else
                                {
                                    Debug.Log("Error sound, something in the way");
                                    yt_uy++;
                                    yt_dy++;
                                }
                            }
                            else
                            {
                                yt_uy++;
                                yt_dy++;
                                Debug.Log("Error sound, out of bounds");
                            }
                            yt_dy--;
                            break;
                        #endregion
                        #region OrangeCar
                        case 5: //OrangeCar
                            Debug.Log("OrangeCar doesn't move down");
                            break;
                        #endregion
                        #region BlueCar
                        case 6: //BlueCar
                            Debug.Log("BlueCar doesn't move down");
                            break;
                        #endregion
                        #region BlueishGreenCar
                        case 7:
                            bgc_uy--;
                            if (bgc_uy >= 0)
                            {
                                if (carGrid[bgc_ux, bgc_uy] == false)
                                {
                                    carBluishGreen.transform.position = new Vector3(carBluishGreen.transform.position.x, carBluishGreen.transform.position.y, carBluishGreen.transform.position.z + 1);
                                    carGrid[bgc_ux, bgc_uy] = true;
                                    carGrid[bgc_dx, bgc_dy] = false;
                                }
                                else
                                {
                                    Debug.Log("Error sound, something in the way");
                                    bgc_uy++;
                                    bgc_dy++;
                                }
                            }
                            else
                            {
                                bgc_uy++;
                                bgc_dy++;
                                Debug.Log("Error sound, out of bounds");
                            }
                            bgc_dy--;
                            break;
                        #endregion
                    }
                }
                if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
                {
                    switch (selectedCar)
                    {
                        #region ReddishPurpleCar
                        case 1:
                            Debug.Log("ReddishPurpleCar doesn't move down");
                            break;
                        #endregion
                        #region VermillionTruck
                        case 2:
                            vt_dy++;
                            if (vt_dy <= 5)
                            {
                                if (carGrid[vt_dx, vt_dy] == false)
                                {
                                    truckVermillion.transform.position = new Vector3(truckVermillion.transform.position.x, truckVermillion.transform.position.y, truckVermillion.transform.position.z - 1);
                                    carGrid[vt_dx, vt_dy] = true;
                                    carGrid[vt_ux, vt_uy] = false;
                                }
                                else
                                {
                                    Debug.Log("Error sound, something in the way");
                                    vt_dy--;
                                    vt_uy--;
                                }
                            }
                            else
                            {
                                vt_dy--;
                                vt_uy--;
                                Debug.Log("Error sound, out of bounds");
                            }
                            vt_uy++;
                            break;
                        #endregion
                        #region SkyBlueTruck
                        case 3:
                            sbt_dy++;
                            if (sbt_dy <= 5)
                            {
                                if (carGrid[sbt_dx, sbt_dy] == false)
                                {
                                    truckSkyBlue.transform.position = new Vector3(truckSkyBlue.transform.position.x, truckSkyBlue.transform.position.y, truckSkyBlue.transform.position.z - 1);
                                    carGrid[sbt_dx, sbt_dy] = true;
                                    carGrid[sbt_ux, sbt_uy] = false;
                                }
                                else
                                {
                                    Debug.Log("Error sound, something in the way");
                                    sbt_dy--;
                                    sbt_uy--;
                                }
                            }
                            else
                            {
                                sbt_dy--;
                                sbt_uy--;
                                Debug.Log("Error sound, out of bounds");
                            }
                            sbt_uy++;
                            break;
                        #endregion
                        #region YellowTruck
                        case 4:
                            yt_dy++;
                            if (yt_dy <= 5)
                            {
                                if (carGrid[yt_dx, yt_dy] == false)
                                {
                                    truckYellow.transform.position = new Vector3(truckYellow.transform.position.x, truckYellow.transform.position.y, truckYellow.transform.position.z - 1);
                                    carGrid[yt_dx, yt_dy] = true;
                                    carGrid[yt_ux, yt_uy] = false;
                                }
                                else
                                {
                                    Debug.Log("Error sound, something in the way");
                                    yt_dy--;
                                    yt_uy--;
                                }
                            }
                            else
                            {
                                yt_dy--;
                                yt_uy--;
                                Debug.Log("Error sound, out of bounds");
                            }
                            yt_uy++;
                            break;
                        #endregion
                        #region OrangeCar
                        case 5: //OrangeCar
                            Debug.Log("OrangeCar doesn't move down");
                            break;
                        #endregion
                        #region BlueCar
                        case 6: //BlueCar
                            Debug.Log("BlueCar doesn't move down");
                            break;
                        #endregion
                        #region BlueishGreenCar
                        case 7:
                            bgc_dy++;
                            if (bgc_dy <= 5)
                            {
                                if (carGrid[bgc_dx, bgc_dy] == false)
                                {
                                    carBluishGreen.transform.position = new Vector3(carBluishGreen.transform.position.x, carBluishGreen.transform.position.y, carBluishGreen.transform.position.z - 1);
                                    carGrid[bgc_dx, bgc_dy] = true;
                                    carGrid[bgc_ux, bgc_uy] = false;
                                }
                                else
                                {
                                    Debug.Log("Error sound, something in the way");
                                    bgc_dy--;
                                    bgc_uy--;
                                }
                            }
                            else
                            {
                                bgc_dy--;
                                bgc_uy--;
                                Debug.Log("Error sound, out of bounds");
                            }
                            bgc_uy++;
                            break;
                        #endregion
                    }
                }
                if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
                {
                    switch (selectedCar)
                    {
                        #region ReddishPurpleCar
                        case 1:
                            rpc_rx++;
                            if (rpc_rx <= 5)
                            {
                                if (carGrid[rpc_rx, rpc_ry] == false)
                                {
                                    carReddishPurple.transform.position = new Vector3(carReddishPurple.transform.position.x + 1, carReddishPurple.transform.position.y, carReddishPurple.transform.position.z);
                                    carGrid[rpc_rx, rpc_ry] = true;
                                    carGrid[rpc_lx, rpc_ly] = false;
                                }
                                else
                                {
                                    Debug.Log("Error sound, something in the way");
                                    rpc_rx--;
                                    rpc_lx--;
                                }
                            }
                            else
                            {
                                rpc_rx--;
                                rpc_lx--;
                                Debug.Log("Error sound, out of bounds");
                            }
                            rpc_lx++;
                            break;
                        #endregion
                        #region VermillionTruck
                        case 2:
                            Debug.Log("ReddishPurpleCar doesn't move down");
                            break;
                        #endregion
                        #region SkyBlueTruck
                        case 3:
                            Debug.Log("ReddishPurpleCar doesn't move down");
                            break;
                        #endregion
                        #region YellowTruck
                        case 4:
                            Debug.Log("ReddishPurpleCar doesn't move down");
                            break;
                        #endregion
                        #region OrangeCar
                        case 5:
                            oc_rx++;
                            if (oc_rx <= 5)
                            {
                                if (carGrid[oc_rx, oc_ry] == false)
                                {
                                    carOrange.transform.position = new Vector3(carOrange.transform.position.x + 1, carOrange.transform.position.y, carOrange.transform.position.z);
                                    carGrid[oc_rx, oc_ry] = true;
                                    carGrid[oc_lx, oc_ly] = false;
                                }
                                else
                                {
                                    Debug.Log("Error sound, something in the way");
                                    oc_rx--;
                                    oc_lx--;
                                }
                            }
                            else if (oc_rx < 9)
                            {
                                carOrange.transform.position = new Vector3(carOrange.transform.position.x + 1, carOrange.transform.position.y, carOrange.transform.position.z);
                            }
                            else if (oc_rx == 9)
                            {
                                //ADDTOGAME
                                //gameController.ShieldUp(true);
                                //GameControllerT4  ShieldsUp();
                                carOrange.transform.position = new Vector3(carOrange.transform.position.x + 1, carOrange.transform.position.y, carOrange.transform.position.z);
                                gameController.PauseGame(true);
                            }
                            else
                            {
                                oc_rx--;
                                oc_lx--;
                                Debug.Log("Error sound, out of bounds");
                            }
                            oc_lx++;
                            break;
                        #endregion
                        #region BlueCar
                        case 6:
                            bc_rx++;
                            if (bc_rx <= 5)
                            {
                                if (carGrid[bc_rx, bc_ry] == false)
                                {
                                    carBlue.transform.position = new Vector3(carBlue.transform.position.x + 1, carBlue.transform.position.y, carBlue.transform.position.z);
                                    carGrid[bc_rx, bc_ry] = true;
                                    carGrid[bc_lx, bc_ly] = false;
                                }
                                else
                                {
                                    Debug.Log("Error sound, something in the way");
                                    bc_rx--;
                                    bc_lx--;
                                }
                            }
                            else
                            {
                                bc_rx--;
                                bc_lx--;
                                Debug.Log("Error sound, out of bounds");
                            }
                            bc_lx++;
                            break;
                        #endregion
                        #region BluishGreenCar
                        case 7:
                            Debug.Log("ReddishPurpleCar doesn't move down");
                            break;
                        #endregion
                    }
                }
                if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
                {
                    switch (selectedCar)
                    {
                        #region ReddishPurpleCar
                        case 1:
                            rpc_lx--;
                            if (rpc_lx >= 0)
                            {
                                if (carGrid[rpc_lx, rpc_ly] == false)
                                {
                                    carReddishPurple.transform.position = new Vector3(carReddishPurple.transform.position.x - 1, carReddishPurple.transform.position.y, carReddishPurple.transform.position.z);
                                    carGrid[rpc_lx, rpc_ly] = true;
                                    carGrid[rpc_rx, rpc_ry] = false;
                                }
                                else
                                {
                                    Debug.Log("Error sound, something in the way");
                                    rpc_lx++;
                                    rpc_rx++;
                                }
                            }
                            else
                            {
                                rpc_lx++;
                                rpc_rx++;
                                Debug.Log("Error sound, out of bounds");
                            }
                            rpc_rx--;
                            break;
                        #endregion
                        #region VermillionTruck
                        case 2:
                            Debug.Log("ReddishPurpleCar doesn't move down");
                            break;
                        #endregion
                        #region SkyBlueTruck
                        case 3:
                            Debug.Log("ReddishPurpleCar doesn't move down");
                            break;
                        #endregion
                        #region YellowTruck
                        case 4:
                            Debug.Log("ReddishPurpleCar doesn't move down");
                            break;
                        #endregion
                        #region OrangeCar
                        case 5:
                            oc_lx--;
                            if (oc_lx >= 5)
                            {
                                carOrange.transform.position = new Vector3(carOrange.transform.position.x - 1, carOrange.transform.position.y, carOrange.transform.position.z);
                            }
                            else if (oc_lx >= 0)
                            {
                                if (carGrid[oc_lx, oc_ly] == false)
                                {
                                    carOrange.transform.position = new Vector3(carOrange.transform.position.x - 1, carOrange.transform.position.y, carOrange.transform.position.z);
                                    carGrid[oc_lx, oc_ly] = true;
                                    carGrid[oc_rx, oc_ry] = false;
                                }
                                else
                                {
                                    Debug.Log("Error sound, something in the way");
                                    oc_lx++;
                                    oc_rx++;
                                }
                            }
                            else
                            {
                                oc_lx++;
                                oc_rx++;
                                Debug.Log("Error sound, out of bounds");
                            }
                            oc_rx--;
                            break;
                        #endregion
                        #region BlueCar
                        case 6:
                            bc_lx--;
                            if (bc_lx >= 0)
                            {
                                if (carGrid[bc_lx, bc_ly] == false)
                                {
                                    carBlue.transform.position = new Vector3(carBlue.transform.position.x - 1, carBlue.transform.position.y, carBlue.transform.position.z);
                                    carGrid[bc_lx, bc_ly] = true;
                                    carGrid[bc_rx, bc_ry] = false;
                                }
                                else
                                {
                                    Debug.Log("Error sound, something in the way");
                                    bc_lx++;
                                    bc_rx++;
                                }
                            }
                            else
                            {
                                bc_lx++;
                                bc_rx++;
                                Debug.Log("Error sound, out of bounds");
                            }
                            bc_rx--;
                            break;
                        #endregion
                        #region BluishGreenCar
                        case 7:
                            Debug.Log("ReddishPurpleCar doesn't move down");
                            break;
                        #endregion
                    }
                }
            }
            #endregion
        }
    }
}