using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este Script no se va adjuntar a otro objeto
/*Actuará como una plantilla de todos los datos que queremos guardar
 Todos los datos que contendrá una carta*/

//Decimos a Unity que permita crear este objeto a través del asset menu
//[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Minion")] Para distintos tipos de cartas
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardScript : ScriptableObject {

    //Valores que queremos que guarde este objeto
    public string nameCard;
    public string description;

    //Sprite de la carta
    public Sprite artwork;

    //Gameplay stuff
    public int manaCost;
    public int attackValue;
    public int health;
	
}
