using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player  {

    //Constantes
    public const int MaxDeck = 30;
    public const int MaxHand = 10;
    public const int MaxBattlefield = 10;
    public const int NumBattlefields = 3;
    //Secretos

    //Atributos
    public int index;
    //Tipo de player
    public Gold gold;
    //fatiga


    //Listas de cartas
    public List<Card> forts;
    public List<Card> deck;
    public List<Card> hand;
    public List<List<Card>> battlefields;
    public List<Card> graveyard;
    //Lista de secretos, armas


    //Getter de las listas
    public List<Card> GetZoneCards(Zones z)
    {
        switch (z)
        {
            case Zones.Fort:
                return forts;

            case Zones.Deck:
                return deck;
            case Zones.Hand:
                return hand;

            case Zones.LeftBattlefield:
                return battlefields[0];

            case Zones.CenterBattlefield:
                return battlefields[1];

            case Zones.RightBattlefield:
                return battlefields[2];
            case Zones.Graveyard:
                return graveyard;

            default:
                return null;

        }

    }

    public Player(int ind)
    {
        index = ind;

        gold = new Gold();

        //Creación de las listas
        forts = new List<Card>(NumBattlefields);
        deck = new List<Card>(MaxDeck);
        hand = new List<Card>(MaxHand);
        graveyard = new List<Card>(MaxDeck);
        battlefields = new List<List<Card>>(NumBattlefields);

        for (int i = 0; i < NumBattlefields; i++)
        {
            battlefields[i] = new List<Card>(MaxBattlefield);

        }
    }

}
