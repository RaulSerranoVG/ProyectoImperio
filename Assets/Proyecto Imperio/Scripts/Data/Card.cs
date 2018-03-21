using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Guardamos los atributos comunes de todos los tipos de cartas
public class Card {

    //Valores que queremos que guarde este objeto
    public string id; //Unico de cada carta
    public string nameCard;
    public string description;

    //Gameplay stuff
    public int goldCost;
    public int ownerIndex; //Facilita encontrar cartas en listas
   // public int orderOfPlay = int.MaxValue; Resuelve eventos

    //Siempre empieza perteneciendo al mazo
    public Zones zone = Zones.Deck;
}


//Interfaces de cartas
public interface IDestructable
{
    int hitPoints { get; set; }
    int maxHitPoints { get; set; }
}

public class Fort : Card, IDestructable
{
    // IDesructable
    public int hitPoints { get; set; }
    public int maxHitPoints { get; set; }
}

public class Minion : Card, IDestructable
{
    public int attack { get; set; }
    public int remainingAttacks { get; set; }
    public int allowedAttacks { get; set; }
    // IDestructable
    public int hitPoints { get; set; }
    public int maxHitPoints { get; set; }
}

public class Spell : Card
{
}