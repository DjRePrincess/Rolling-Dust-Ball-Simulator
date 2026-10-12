using UnityEngine;
using System.Collections;

// Purpose: Anything to use this script, and then do something when timerEnded
// Access the class, set the targetTime (need a setter, maybe a getter too? for target time?)
public class SimpleTimer : MonoBehaviour
{
    private float targetTime = 60.0f;

    void Update()
    {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }

    public void setTargetTime(float time)
    {
        targetTime = time;
    }

    public bool timerEnded()
    {
        return true;
    }


}