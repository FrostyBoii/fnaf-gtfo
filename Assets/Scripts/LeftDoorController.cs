using UnityEngine;
using System.Collections;

public class LeftDoorController : MonoBehaviour
{
    private enum DoorState
    {
        Open,
        Closing,
        Closed,
        Opening
    }

    private Vector2 openDoorPosition;
    private Vector2 closedDoorPosition;
    public float doorSpeed = 40f;

    private DoorState currentDoorState;
    void Start()
    {
        currentDoorState = DoorState.Open;

        openDoorPosition = new Vector2(-10.5f, 4.8f);
        closedDoorPosition = new Vector2(-10.5f, -3.8f);
        transform.position = openDoorPosition;
    }

    public void changeDoorState()
    {
        Debug.Log("Start event change");
        if (currentDoorState == DoorState.Open)
        {
            currentDoorState = DoorState.Closing;
            StartCoroutine(closeDoor());
        }
        else if (currentDoorState == DoorState.Closed)
        {
            currentDoorState = DoorState.Opening;
            StartCoroutine(openDoor());
        }
    }

    private IEnumerator closeDoor()
    {
        while (transform.position != (Vector3)closedDoorPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, closedDoorPosition, doorSpeed * Time.deltaTime);

            yield return null;
        }

        currentDoorState = DoorState.Closed;
    }

    private IEnumerator openDoor()
    {
        while(transform.position != (Vector3)openDoorPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, openDoorPosition, doorSpeed * Time.deltaTime);

            yield return null;
        }

        currentDoorState = DoorState.Open;
    }
}
