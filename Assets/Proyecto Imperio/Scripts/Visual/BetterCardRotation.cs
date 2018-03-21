using UnityEngine;
using System.Collections;

//Componente que asociado a un GameObject card, permite hacer una rotación correcta: Muestra el front y back cuando corresponde
//Cuando la carta está boca arriba solo se renderiza el front y cuando está boca abajo solo el back

[ExecuteInEditMode]//Esto hace que todo el código del Update(), también se llame en el editor
public class BetterCardRotation : MonoBehaviour {

    //GameObject que representa el Front de la carta
    public RectTransform cardFront;

    //GameObject que representa el Back de la carta
    public RectTransform cardBack;

    //Objeto vacío que se pone en el centro de la carta un poco por detras de la cara.
    public Transform targetFacePoint;

    //3D collider para detectar raycast
    public Collider col;

    //Atributo que representa si la carta está boca abajo o boca arriba
    private bool showingBack = false;

	// Update is called once per frame
	void Update () 
    {
        //Lanzamos un rayo desde la camara al targetPoint.
        RaycastHit[] hits;
        hits = Physics.RaycastAll(Camera.main.transform.position, //Origen
                                  (-Camera.main.transform.position + targetFacePoint.position).normalized,  //Dirección
            (-Camera.main.transform.position + targetFacePoint.position).magnitude) ; //Máxima distancia


        //Si pasa por el collider, debemos mostrar el back
        bool passedThroughColliderOnCard = false;
        foreach (RaycastHit h in hits)
        {
            if (h.collider == col)
                passedThroughColliderOnCard = true;
        }

        //Solo entra aquí cuando cambia de estado la carta
        if (passedThroughColliderOnCard!= showingBack)
        {
            showingBack = passedThroughColliderOnCard;

            //Mostramos el Back
            if (showingBack)
            {
                cardFront.gameObject.SetActive(false);
                cardBack.gameObject.SetActive(true);
            }

            //Mostramos el top
            else
            {
                cardFront.gameObject.SetActive(true);
                cardBack.gameObject.SetActive(false);
            }

        }

	}
}
