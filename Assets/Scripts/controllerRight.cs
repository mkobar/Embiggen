using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SteamVR_TrackedObject))]

public class controllerRight : MonoBehaviour
{

    public GameObject GameWorld;
    public GameObject HMD;
    public GameObject GameManage;
    private Vector3 tmpHMDPos;
    private bool shrinking;
    private float targetNum = 0.05F;
    public GameObject projectile;
    public float shootforce = 2000F;
    public float growSpeed = 20f;
    private GameObject clone;
    public GameObject ring;
    public float normalizedTransition;
    public GameObject projectile_prefab;
    float bulletImpulse = 0.5f;


    SteamVR_TrackedObject trackedObj;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);

        if ((device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && GameWorld.transform.localScale.x <= 0.5f) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject cam = GameObject.FindGameObjectWithTag("ControllerRight");       //Change to vive cam
            GameObject projectile = (GameObject)Instantiate(projectile_prefab, cam.transform.position, cam.transform.rotation);
            projectile.transform.localScale = GameWorld.transform.localScale;
            projectile.GetComponent<Rigidbody>().mass = projectile.GetComponent<Rigidbody>().mass * .1f;
            projectile.GetComponent<Rigidbody>().AddForce(cam.transform.forward * bulletImpulse, ForceMode.Impulse);
            cam.GetComponent<AudioSource>().Play();
        }

        if (GameManage.GetComponent<GameManager>().getFirstChange() && targetNum < GameWorld.transform.localScale.x)
        {
            if (GameManage.GetComponent<GameManager>().getFirstChange() && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && !GameManage.GetComponent<GameManager>().getIsShrinking() && !GameManage.GetComponent<GameManager>().getIsGrowing())
            {
                GameManage.GetComponent<GameManager>().goDownIndex();
                targetNum = GameManage.GetComponent<GameManager>().getSize();
                GameManage.GetComponent<GameManager>().reverseIsShrinking();
                normalizedTransition = (GameWorld.transform.localScale.x - targetNum)/100;
            } else if (GameManage.GetComponent<GameManager>().getIsShrinking())
            {
                firstShrink();
            }
        }
        else if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Grip) && !GameManage.GetComponent<GameManager>().getIsShrinking() && !GameManage.GetComponent<GameManager>().getIsGrowing())
        {
            GameManage.GetComponent<GameManager>().goDownIndex();
            targetNum = GameManage.GetComponent<GameManager>().getSize();
            normalizedTransition = (GameWorld.transform.localScale.x - targetNum) / 100;
            if (targetNum < GameWorld.transform.localScale.x)
            {
                GameManage.GetComponent<GameManager>().reverseIsShrinking();
            }
        }
        else if (GameManage.GetComponent<GameManager>().getIsShrinking() && targetNum <= GameWorld.transform.localScale.x)
        {
            tmpHMDPos = HMD.transform.position;
            //iTween.ScaleTo(GameWorld, iTween.Hash("scale", new Vector3((normalizedTransition * growSpeed) * Time.deltaTime, (normalizedTransition * growSpeed) * Time.deltaTime, (normalizedTransition * growSpeed) * Time.deltaTime), "easetype", iTween.EaseType.easeInOutSine, "time", 3f));
            GameWorld.transform.localScale -= new Vector3((normalizedTransition * growSpeed) * Time.deltaTime, (normalizedTransition * growSpeed) * Time.deltaTime, (normalizedTransition * growSpeed) * Time.deltaTime);
            var diffPos = tmpHMDPos - HMD.transform.position;
            GameWorld.transform.position = new Vector3(GameWorld.transform.position.x + diffPos.x, GameWorld.transform.position.y, GameWorld.transform.position.z + diffPos.z);
            if (targetNum >= GameWorld.transform.localScale.x)
            {
                GameWorld.transform.localScale = new Vector3(targetNum, targetNum, targetNum);
                GameManage.GetComponent<GameManager>().reverseIsShrinking();

            }
        }
    }

    private void firstShrink()
    {
        GameWorld.transform.localScale -= new Vector3((normalizedTransition * growSpeed) * Time.deltaTime, (normalizedTransition * growSpeed) * Time.deltaTime, (normalizedTransition * growSpeed) * Time.deltaTime);

        //iTween.ScaleTo(GameWorld, iTween.Hash("scale", new Vector3((normalizedTransition * growSpeed) * Time.deltaTime, (normalizedTransition * growSpeed) * Time.deltaTime, (normalizedTransition * growSpeed) * Time.deltaTime), "easetype", iTween.EaseType.easeInOutSine, "time", 3f));
        if (targetNum >= GameWorld.transform.localScale.x)
        {
            GameWorld.transform.localScale = new Vector3(targetNum, targetNum, targetNum);
            GameManage.GetComponent<GameManager>().reverseIsShrinking();
            GameManage.GetComponent<GameManager>().setFirstChangeFalse();
        }

    }
}