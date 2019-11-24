using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WindowWinGame : MonoBehaviour
{
    private List<PanelPlayer> panelPlayers = new List<PanelPlayer>();

    public PanelPlayer prefabsPanelPlayer;
    public Transform containerPanels;
    public GameObject ui;
    public Transform tr;
    public Text description;

    public void Init(int timeWin)
    {
        SetDescription(timeWin);
        InitLeaderboards(InitMainPlayer(timeWin));
        StartCoroutine(OpenWindowAnimation());
    }

    private void SetDescription(int timeWin)
    {
        description.text = string.Concat("Вы справились за ", timeWin, " c., но сможете ли еще лучше?");
    }

    private void ClearLeaderboards()
    {
        for (int i = 0; i < panelPlayers.Count; i++)
        {
            Destroy(panelPlayers[i].gameObject);
        }

        panelPlayers.Clear();
    }

    private void InitLeaderboards(Player mainPlayer)
    {
        List<Player> players = Network.instance.playersInfo.players;
        players.Add(mainPlayer);
        players = players.OrderBy(x => x.best_time).ToList();
        ClearLeaderboards();

        for (int i = 0; i < players.Count; i++)
        {
            PanelPlayer player = Instantiate(prefabsPanelPlayer, containerPanels);
            player.Init(players[i]);
            panelPlayers.Add(player);
        }

        ui.SetActive(true);
    }

    private Player InitMainPlayer(int timeWin)
    {
        Player mainPlayer = new Player();
        mainPlayer.name = "Вы";
        mainPlayer.best_time = GameController.instance.SaveRecord(timeWin);

        return mainPlayer;
    }

    private IEnumerator OpenWindowAnimation()
    {
        ui.SetActive(true);
        float process = 0;

        while (process < 0.95f)
        {
            process += Time.deltaTime  * (4 - process);
            tr.localScale = new Vector2(process, process);
            yield return null;
        }

        tr.localScale = new Vector2(1, 1);
    }
}
