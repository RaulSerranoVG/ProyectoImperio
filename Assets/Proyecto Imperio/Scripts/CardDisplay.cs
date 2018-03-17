using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Para referenciar al texto e imagenes

public class CardDisplay : MonoBehaviour {

    public Card card;

    public Text nameText;
    public Text descriptionText;

    public Image artworkImage;

    public Text manaText;
    public Text attackText;
    public Text healthText;


    // Use this for initialization
    void Start () {
        //Inicializar la carta
        nameText.text = card.nameCard;
        descriptionText.text = card.description;

        artworkImage.sprite = card.artwork;

        manaText.text = card.manaCost.ToString();
        attackText.text = card.attackValue.ToString();
        healthText.text = card.health.ToString();
	}
	

}
