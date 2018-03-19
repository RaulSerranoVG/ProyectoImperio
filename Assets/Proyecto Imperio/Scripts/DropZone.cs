using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//Vamos a implementar interfaces para soltar cartas

public class DropZone : MonoBehaviour ,IDropHandler,IPointerEnterHandler, IPointerExitHandler{

    //Si necesitamos distinguir entre zonas
    //public Draggable.Slot typeOfItem = Draggable.Slot.INVENTORY;

    //Es llamado cuando el puntero del ratón entra en el GameObject
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");

        //Detectamos si llevamos una carta
        if (eventData.pointerDrag != null)
        {
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null)
                //Establecemos padre del placeholder objeto a esta nueva zona
                d.placeholderParent = this.transform;
            
        }
    }

    //Es llamado cuando el puntero del ratón sale del GameObject
    public void OnPointerExit(PointerEventData eventData)
    {
        // Debug.Log("OnPointerExit");

        //Detectamos si llevamos una carta
        if (eventData.pointerDrag != null)
        {
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null && d.placeholderParent == this.transform)
                //Establecemos el padre del placeholder del objeto al padre que tenia que retornar
                d.placeholderParent = d.parentToReturnTo;
            
        }
    }

    //Es llamado cuando se suelta un objeto en el GameObject (Antes que OnEndDrag())
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            //Si tenemos que distinguir que tipo de carta es
            //if (typeOfItem == d.typeOfItem || typeOfItem == Draggable.Slot.INVENTORY)

            d.parentToReturnTo = this.transform;//Establecemos el nuevo padre del objeto dropeado

        }
    }


}
