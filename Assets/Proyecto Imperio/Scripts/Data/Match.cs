using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Una colección de 2 jugadores luchando por turnos
public class Match {

    //Número de jugadores en la partida
    public const int NumPlayers = 2;

    //Guarda el jugador actual
    public int currentPlayerIndex;

    public List<Player> players;


    //Devuelve el jugador actual
    public Player GetCurrentPlayer()
    {
        return players[currentPlayerIndex];
    }

    //Devuelve el jugador oponente
    public Player GetOpponentPlayer()
    {
        return players[1- currentPlayerIndex];
    }

    public Match()
    {
        //Creamos a los jugadores
        players = new List<Player>(NumPlayers);
        for (int i = 0; i < players.Count; i++)
            players[i] = new Player(i);
    }


}
