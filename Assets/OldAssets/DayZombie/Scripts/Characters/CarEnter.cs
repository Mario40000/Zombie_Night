using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Utility;

public class CarEnter : MonoBehaviour
{
    public CarUserControl carUserControl;
    public CarController carController;
    public CarAIControl carIaControl;
    public WaypointProgressTracker tracker;
    public CarAudio carAudio;
    public GameObject Player;
    public GameObject carCamera;
    public GameObject playerCamera;
    public Transform exitPoint;

    public string enterKey = "f";
    public string exitKey = "r";
    private float oldPitch;
    private bool canEnter;
    private bool inCar;
    // Use this for initialization
    void Start()
    {
        oldPitch = carAudio.pitchMultiplier;
        //carAudio.pitchMultiplier = 0.0f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (canEnter == true)
        {
            if (Input.GetKeyDown(enterKey))
            {
                Player.transform.parent = exitPoint;
                Player.transform.localPosition = new Vector3(-1.5f, 0f, 0f);
                Player.SetActive(false);
                playerCamera.transform.parent = exitPoint;
                playerCamera.transform.localPosition = new Vector3(-1.5f, 0f, 0f);
                playerCamera.SetActive(false);
                carCamera.SetActive(true);
                carUserControl.enabled = true;
                carController.enabled = true;
                carIaControl.enabled = false;
                tracker.enabled = false;
                //carAudio.pitchMultiplier = oldPitch;
                canEnter = false;
                inCar = true;


            }
        }
        if (inCar == true)
        {
            if (Input.GetKeyDown(exitKey))
            {
                Player.SetActive(true);
                Player.transform.parent = null;
                playerCamera.SetActive(true);
                playerCamera.transform.parent = null;
                carCamera.SetActive(false);
                carUserControl.enabled = false;
                carController.enabled = false;
                //carAudio.pitchMultiplier = 0;
                canEnter = false;
                inCar = false;
              

            }

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canEnter = true;


        }



    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canEnter = false;

        }

    }
}