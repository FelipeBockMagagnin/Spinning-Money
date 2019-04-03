using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private float lastX;
    private float lastY;
    private float lastZ;

    private float thisY;
    private float thisX;
    private float thisZ;

    private float x;
    private float y;
    private float z;

    public float rotationMult;

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

        MoneyManager.money += ((x + y + z) / 7) * MoneyManager.moneyMultiply;
        CountTimeWithoutStopShaking();
        transform.Rotate(0, 0, z * rotationMult);
    }


    private float timewithoutshaking = 0;

    /// <summary>
    /// Shake the bag if shaking the phone
    /// </summary>
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

    private bool shakeOn = false;
    private float shakePower = 0.3f;

    // sprite original position
    private Vector3 originPosition= new Vector3(0,0.33f,0);
    private Vector3 normalPosition = new Vector3(0,0.33f,0);

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
