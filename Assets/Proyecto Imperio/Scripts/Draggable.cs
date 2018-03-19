using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;//Vamos a implementar interfaces para que sea Draggable

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    //Siempre guardamos de que zona viene para poder retornarla
    public Transform parentToReturnTo = null;

    //Guardamos el padre del placeholder para poder retonar la carta
    public Transform placeholderParent = null;

    //Para mostrar un hueco vacío entre las cartas
    GameObject placeholder = null;


    //Si necesitamos información de que tipo es la carta
    /*public enum Slot { WEAPON,CHEST,HEAD,INVENTORY};
    public Slot typeOfItem = Slot.WEAPON;
    */


    //Método que es llamado una vez cuando cogemos una carta con el ratón
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");

        //Creamos el hueco vacío
        CreatePlaceholder();

        //Actualizamos de donde viene
        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;

        //Eliminamos su parentesco a la zona correspondiente
        this.transform.SetParent(this.transform.parent.parent);

        //Bloqueamos raycast de la carta para poder dropearla en una zona
        GetComponent<CanvasGroup>().blocksRaycasts = false;


        //Podemos iterar en todas las zonas disponibles en el juego
        //DropZone[] zones = GameObject.FindObjectsOfType<DropZone>();
    }

    //Método que es llamado continuamente cuando arrastramos una carta con el ratón
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");

        //La posición de la carta es la posición del cursor
        this.transform.position = eventData.position;

        //Movemos el hueco vacío a donde le toque
        UpdatePlaceholder();
    }

    //Método que es llamado una vez cuando soltamos el clickIzquierdo del raton (Después de OnDrop())
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        //Metemos la carta en una zona, ya sea de donde venia o con el Parent actualizado en otra zona
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex()); //La metemos en el hueco correspondiente

        //Puede volver a ser cogida
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        //Destruimos el hueco vacío
        Destroy(placeholder);

        //EventSystem.current.RaycastAll(eventData);
    }

    //Crea el GameObject en la zona correspondiente para mostrar un hueco vacío
    void CreatePlaceholder()
    {
        placeholder = new GameObject();

        //Lo ponemos en la posición correspondiente de la zona
        placeholder.transform.SetParent(this.transform.parent);
        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        //Queremos que ocupe lo mismo que la carta en el layout
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;


    }

    //Actualiza la posición del hueco vacío
    void UpdatePlaceholder()
    {
        //Actualizamos el parentesco (Cambia cuando entramos en otra zona)
        if (placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);

        //Movemos el hueco vacío a donde le corresponda del layour
        int newSiblingIndex = placeholderParent.childCount;

        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;
                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;
                break;
            }

        }

        placeholder.transform.SetSiblingIndex(newSiblingIndex);

    }
}
