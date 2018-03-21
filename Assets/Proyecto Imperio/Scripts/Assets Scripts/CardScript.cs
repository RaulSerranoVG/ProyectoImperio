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
    [Header("General info")]
    public string cardName;

    [TextArea(2, 3)]//Permite que la descripción sea más larga
    public string description;

    public Sprite cardImage; //Sprite de la carta
    public int manaCost; //Coste de mana

    //Atributos de Minions
    [Header("Creature Info")]
    public int attack;
    public int health; // Si es == 0, es un hechizo

    //Atributos de Spells
    //[Header("Spell Info")]
}
