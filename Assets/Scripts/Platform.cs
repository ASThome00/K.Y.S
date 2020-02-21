using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Platform
{
    Vector3Int platformLoc;

    Tile darkTile;
    Tile lightTile;
    Tilemap myScreen;
    
    public Platform(int x, int y) {
        platformLoc = new Vector3Int(x, y, 2);
    }

    public void draw() {
        for(int hor = 0; hor<6; hor++) {
            for(int ver =0; ver < 2; ver++) {
                fillPixel(platformLoc.x + hor, platformLoc.y + ver, true);
            }
        }
      
    }

    void fillPixel(int x, int y, bool type) {
        Vector3Int pos = new Vector3Int(x, y, 0);
        if (type) {
            myScreen.SetTile(pos, darkTile);
        } else {
            myScreen.SetTile(pos, lightTile);
        }
    }

    public void setDarkTile(Tile yeet) {
        darkTile = yeet;
    }
    public void setLightTile(Tile yeet) {
        lightTile = yeet;
    }

    public void setTilemap(Tilemap yeet) {
        myScreen = yeet;
    }

    public int getPlatformX() {
        return platformLoc.x;
    }

    public int getPlatformY() {
        return platformLoc.y;
    }

}
