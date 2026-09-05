using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraAnimator : MonoBehaviour
{
    private enum CameraState
    {
        Closed,
        Opening,
        Open,
        Closing
    }

    public GameObject cameraBackground;
    public Image cameraButton;

    private CameraState currentCameraState;
    public Vector2 closedPosition;
    public Vector2 openPosition;

    public float cameraSpeed = 20.0f;

    public AudioSource cameraMoveSound;

    void Start()
    {
        currentCameraState = CameraState.Closed;
        cameraBackground.transform.position = closedPosition;
    } 

    public void changeCameraState()
    {
        if (currentCameraState == CameraState.Closed)
        {
            StartCoroutine(openCamera());
        }

        else if (currentCameraState == CameraState.Open)
        {
            StartCoroutine(closeCamera());
        }
    }

    private IEnumerator openCamera()
    {
        cameraButton.enabled = false;
        currentCameraState = CameraState.Opening;
        cameraMoveSound.Play();
        yield return StartCoroutine(slideTo(openPosition));
        currentCameraState = CameraState.Open;
        cameraButton.enabled = true;
    }

    private IEnumerator closeCamera()
    {
        cameraButton.enabled = false;
        currentCameraState = CameraState.Closing;
        cameraMoveSound.Play();
        yield return StartCoroutine(slideTo(closedPosition));
        currentCameraState = CameraState.Closed;
        cameraButton.enabled = true;
    }

    public IEnumerator slideTo(Vector2 targetPosition)
    {
        while(Vector2.Distance(cameraBackground.transform.position, targetPosition) > 0.1f)
        {
            cameraBackground.transform.position = Vector2.Lerp(cameraBackground.transform.position, targetPosition, Time.deltaTime * cameraSpeed);
            yield return null;
        }
        cameraBackground.transform.position = targetPosition;
    }

}
