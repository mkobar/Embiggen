using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public bool isGrowing = false;
    public bool isShrinking = false;
    public bool firstChange = true;
    public float[] sizes = new float[] { 0.05f, 1f, 100f };
    public int index = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool getFirstChange()
    {
        return firstChange;
    }

    public void setFirstChangeFalse()
    {
        firstChange = false;
    }

    public float getSize()
    {
        return sizes[index];
    }

    public void goUpIndex()
    {
        if(index <= 1)
        {
            index++;
        }
    }

    public void goDownIndex()
    {
        if (index >=1)
        {
            index--;
        }
    }

    public void reverseIsGrowing()
    {
        isGrowing = !isGrowing;
    }

    public void reverseIsShrinking()
    {
        isShrinking = !isShrinking;
    }

    public bool getIsGrowing()
    {
        return isGrowing;
    } 

    public bool getIsShrinking()
    {
        return isShrinking;
    }
}

