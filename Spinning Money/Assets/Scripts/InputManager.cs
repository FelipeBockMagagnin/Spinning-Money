using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public Text moneyTxt;

    public float lastX;
    public float lastY;
    public float lastZ;


    public float thisY;
    public float thisX;
    public float thisZ;


    public float x;
    public float y;
    public float z;


    // Start is called before the first frame update
    void Start()
    {
        lastX = 0;
        lastY = 0;
        lastZ = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        thisX = Input.acceleration.x;
        thisY = Input.acceleration.y;
        thisZ = Input.acceleration.z;


        y = Mathf.Abs(Mathf.Abs(Input.acceleration.y) - Mathf.Abs(lastY));
        x = Mathf.Abs(Mathf.Abs(Input.acceleration.x) - Mathf.Abs(lastX));
        z = Mathf.Abs(Mathf.Abs(Input.acceleration.z) - Mathf.Abs(lastZ));


        if(x <= 0.1)
        {
            x = 0;
        }

        if (y <= 0.1)
        {
            y = 0;
        }

        if (z <= 0.1)
        {
            z = 0;
        }


        lastX = thisX;
        lastY = thisY;
        lastZ = thisZ;


        MoneyManager.money += (x + y + z);


        moneyTxt.text = "Money: " + MoneyManager.money.ToString("0.00");


        transform.Rotate(0, 0, z);
    }
}
