using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Level : MonoBehaviour
{
    public Tile darkTile;
    public Tile lightTile;
    public Tilemap myScreen;

    int[,] viewPane = new int[48,84];
    List<List<int>> gameWorld = new List<List<int>>();

    List<Platform> platformList = new List<Platform>();

    private Platform p1 = new Platform(12,12);
    private Player player = new Player();

    public void fillPixel(int x, int y, bool fill) {
        Vector3Int pos = new Vector3Int(x, y, 2);
        if (fill) myScreen.SetTile(pos, darkTile);
        else myScreen.SetTile(pos, lightTile);
    }

    public void drawViewPane() {
        for(int row =0; row<48; row++){
            for(int column = 0; column <84; column++) {
               fillPixel(row, column, false);
            }
        }
    }

    // Start is called before the first frame update
    void Start() {
        Application.targetFrameRate = 35;
        for (int x = 0; x < 48; x++) {
            viewPane[x, 30] = 1;
        }
        p1.setDarkTile(darkTile);
        p1.setLightTile(lightTile);
        p1.setTilemap(myScreen);

        p1.draw();

        player.setDarkTile(darkTile);
        player.setLightTile(lightTile);
        player.setTilemap(myScreen);

        player.FillPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        drawViewPane();

        if (Input.GetKey("a"))
        {
            player.setLocX(player.getLocX() - 1);
        }
        if (Input.GetKey("d"))
        {
            player.setLocX(player.getLocX() + 1);
        }
        if (Input.GetKey("space"))
        {
            player.setPlayerState(1);
            if (player.getJumpPower() < 40) player.setJumpPower(player.getJumpPower() + 1);
        }
        else if (Input.GetKeyUp("space"))
        {
            player.setPlayerState(0);
        }

        if (player.getJumpPower() > 0 && !(player.getPlayerState() == 1))
        {
            player.setPlayerState(2);
            player.setLocY(player.getLocY() + 1);
            player.setJumpPower(player.getJumpPower() - 1);
            player.setIsPlaying(true);
        }
        else if (player.getJumpPower() == 0 && player.getIsPlaying())
        {
            player.setPlayerState(0);
            player.setLocY(player.getLocY() - 1);
        }
        player.FillPlayer();
    }
}
