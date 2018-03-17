using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//Vamos a implementar interfaces para soltar cartas

public class DropZone : MonoBehaviour ,IDropHandler,IPointerEnterHandler, IPointerExitHandler{

    public Draggable.Slot typeOfItem = Draggable.Slot.INVENTORY;

    //Es llamado cuando el puntero del ratón entra en el GameObject
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");

    }

    //Es llamado cuando el puntero del ratón sale del GameObject
    public void OnPointerExit(PointerEventData eventData)
    {
       // Debug.Log("OnPointerExit");

    }

    //Es llamado cuando se suelta un objeto en el GameObject
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if (typeOfItem == d.typeOfItem || typeOfItem == Draggable.Slot.INVENTORY)
                d.parentToReturnTo = this.transform;

        }
    }


}
