using System.Data.Common;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightDoorButton : MonoBehaviour, IPointerClickHandler
{
    public RightDoorController rightDoorController;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Button clicked");
        rightDoorController.changeDoorState();   
    }
    
}
