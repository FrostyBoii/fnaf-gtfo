using System.Data.Common;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftDoorButton : MonoBehaviour, IPointerClickHandler
{
    public LeftDoorController leftDoorController;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Button clicked");
        leftDoorController.changeDoorState();   
    }
    
}
