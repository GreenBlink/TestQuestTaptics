using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Player
{
    public int id;
    public string name;
    public double best_time;
}

[Serializable]
public class PlayersInfo
{
    public List<Player> players;
}
