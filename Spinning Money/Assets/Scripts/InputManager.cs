using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public float lastX;
    public float lastY;
    public float lastZ;


    public float thisY;
    public float thisX;
    public float thisZ;


    public float x;
    public float y;
    public float z;

    public float rotationMult;


    // Start is called before the first frame update
    void Start()
    {
        lastX = 0;
        lastY = 0;
        lastZ = 0;
        if(rotationMult == 0)
        {
            rotationMult = 1;
        }
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


        if (x <= 0.1)
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


        MoneyManager.money += ((x + y + z) / 5) * MoneyManager.moneyMultiply;


        CountTimeWithoutStopShaking();


        transform.Rotate(0, 0, z * rotationMult);
    }


    public float timewithoutshaking = 0;

    void CountTimeWithoutStopShaking()
    {
        if(x > 0.2 || y > 0.2 || z > 0.2)
        {

            timewithoutshaking = 0.2f;
        }
        else
        {
            timewithoutshaking -= Time.deltaTime;
        }

        if(timewithoutshaking > 0)
        {
            shakeOn = true;
        }
        else
        {
            shakeOn = false;
        }

    }



        // vars
    private bool shakeOn = false;
    private float shakePower = 0.3f;

    // sprite original position
    private Vector3 originPosition= new Vector3(0,0.33f,0);
    private Vector3 normalPosition = new Vector3(0,0.33f,0);

    // Update is called once per frame
    void Update()
    {
        // if shake is enabled
        if (shakeOn)
        {
            // reset original position
            transform.position = originPosition;

            // generate random position in a 1 unit circle and add power
            Vector2 ShakePos = Random.insideUnitCircle * shakePower;

            // transform to new position adding the new coordinates
            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);
        }
        else
        {
            transform.position = normalPosition;
        }
    }
}
