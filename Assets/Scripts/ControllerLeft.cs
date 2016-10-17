using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SteamVR_TrackedObject))]

public class ControllerLeft : MonoBehaviour {

    public GameObject GameWorld;
    public GameObject HMD;
    public GameObject GameManage;
    private Vector3 tmpHMDPos;
    private float targetNum = 100f;
    public float growSpeed = 20f;
    public float normalizedTransition;

    private GameObject pickup;

    SteamVR_TrackedObject trackedObj;
    FixedJoint joint;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && pickup.tag == "grabbable" || Input.GetKeyDown(KeyCode.UpArrow))
        {
            pickup.transform.parent = this.transform;
            pickup.GetComponent<Rigidbody>().isKinematic = true;
            
            //tmpHMDPos = HMD.transform.position;
            //GameWorld.transform.localScale += new Vector3(10F, 10F, 10F);
            //var diffPos = tmpHMDPos - HMD.transform.position;
           // GameWorld.transform.position = new Vector3(GameWorld.transform.position.x + diffPos.x, GameWorld.transform.position.y, GameWorld.transform.position.z + diffPos.z);
        }

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Grip) && !GameManage.GetComponent<GameManager>().getIsGrowing() && !GameManage.GetComponent<GameManager>().getIsShrinking() && !GameManage.GetComponent<GameManager>().getFirstChange()) 
        {
            Debug.Log("Hits here");
            GameManage.GetComponent<GameManager>().goUpIndex();
            targetNum = GameManage.GetComponent<GameManager>().getSize();
            normalizedTransition = (targetNum - GameWorld.transform.localScale.x) / 100;
            if (targetNum > GameWorld.transform.localScale.x)
            {
                GameManage.GetComponent<GameManager>().reverseIsGrowing();
            }
        }
        if(device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            pickup.transform.parent = null;
            pickup.GetComponent<Rigidbody>().isKinematic = false;
        }

        if (GameManage.GetComponent<GameManager>().getIsGrowing() && targetNum >= GameWorld.transform.localScale.x)
        {
            tmpHMDPos = HMD.transform.position;
            //iTween.ScaleTo(GameWorld, iTween.Hash("scale", new Vector3(normalizedTransition * growSpeed * Time.deltaTime, normalizedTransition * growSpeed * Time.deltaTime, normalizedTransition * growSpeed * Time.deltaTime), "easetype", iTween.EaseType.easeInOutSine, "time", 3f));

            GameWorld.transform.localScale += new Vector3(normalizedTransition * growSpeed * Time.deltaTime, normalizedTransition * growSpeed * Time.deltaTime, normalizedTransition * growSpeed * Time.deltaTime);
            var diffPos = tmpHMDPos - HMD.transform.position;
            GameWorld.transform.position = new Vector3(GameWorld.transform.position.x + diffPos.x, GameWorld.transform.position.y, GameWorld.transform.position.z + diffPos.z);

            if (targetNum < GameWorld.transform.localScale.x)
            {
                Debug.Log("hits the else");
                GameManage.GetComponent<GameManager>().reverseIsGrowing();
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        pickup = collider.gameObject;
        Debug.Log(pickup);
    }
}
