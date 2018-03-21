using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Para referenciar al texto e imagenes

//Guarda las referencias a todo los textos e imágenes de la carta
public class CardDisplay : MonoBehaviour {

    public CardScript cardScript; //Referencia al contenido de la carta

    [Header("Text Component References")]
    //Atributos comunes
    public Text nameText;
    public Text descriptionText;
    public Text manaText;

    //Hechizos no lo necesitan, lo dejamos a null
    public Text attackText;
    public Text healthText;

    [Header("Image References")]
    //Artwork de la carta
    public Image cardGraphicImage;

    //Base de la carta
    public Image cardBodyImage;//Fondo de la carta


    // Use this for initialization
    void Start()
    {

        //Si hemos establecido el asset
        if (cardScript != null)
        {
            //Inicializamos atributos comunes
            nameText.text = cardScript.cardName;
            manaText.text = cardScript.manaCost.ToString();
            descriptionText.text = cardScript.description;

            cardGraphicImage.sprite = cardScript.cardImage;

            //Si es un minion, inicializamos sus atributos
            if (cardScript.health != 0)
            {
                attackText.text = cardScript.attack.ToString();
                healthText.text = cardScript.health.ToString();
            }
        }
    }
	

}
