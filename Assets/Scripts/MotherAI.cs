using UnityEngine;

public class MotherAI : MonoBehaviour
{
    private enum MotherState
    {
        Inactive,
        Waiting,
        Attacking
    }

    private MotherState currentMotherState;
    private float timeInactive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMotherState = MotherState.Inactive;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeInactive >= 20.0f)
        {
            changeMotherState();
        }
        else
        {
            timeInactive += Time.deltaTime;
        }
    }

    private void changeMotherState()
    {
        if (currentMotherState == MotherState.Inactive)
        {
            currentMotherState = MotherState.Waiting;
        }
        else if (currentMotherState == MotherState.Waiting)
        {
            currentMotherState = MotherState.Attacking;
        }
        else if (currentMotherState == MotherState.Attacking)
        {
            currentMotherState = MotherState.Inactive;
        }
    }
}
