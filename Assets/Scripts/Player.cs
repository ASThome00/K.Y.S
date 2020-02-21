using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player
{
    Tile darkTile;
    Tile lightTile;
    Tilemap myScreen;

    Vector3Int playerLoc; 
    ArrayList vertBuffer = new ArrayList();
    int playerState; //0 - standing, 1 - crouching, 2 - jumping, 3 - dying
    int jumpPower;
    bool isPlaying; 

    public Player()
    {
        this.playerLoc = new Vector3Int(24, 34, 0); //sets the initial location of the player
        playerState = 0; //0 - standing, 1 - crouching, 2 - jumping, 3 - dying
        jumpPower = 0;
        isPlaying = false;
    }

    public void setDarkTile(Tile yeet)
    {
        darkTile = yeet;
    }
    public void setLightTile(Tile yeet)
    {
        lightTile = yeet;
    }

    public void setTilemap(Tilemap yeet)
    {
        myScreen = yeet;
    }

    public void setJumpPower(int power)
    {
        if (power < 41)
        {
            this.jumpPower = power;
        }
        else
        {
            this.jumpPower = 40;
        }
    }

    public int getJumpPower()
    {
        return jumpPower;
    }

    public void setPlayerState(int state)
    {
        this.playerState = state;
    }

    public int getPlayerState()
    {
        return playerState;
    }

    public void setLocX(int x)
    {
        if (x > 43)
        {
            playerLoc.x = 43;
        }
        else if(x < 0)
        {
            playerLoc.x = 0;
        }
        else
        {
            playerLoc.x = x;
        }
    }

    public int getLocX()
    {
        return playerLoc.x;
    }

    public void setLocY(int y)
    {
        if(y > 83)
        {
            playerLoc.y = 83;
        }
        else if(y < 0)
        {
            playerLoc.y = 0;
        }
    }

    public int getLocY()
    {
        return playerLoc.y;
    }

    public void setIsPlaying(bool p)
    {
        isPlaying = p;
    }

    public bool getIsPlaying()
    {
        return isPlaying;
    }

    void fillPixel(int x, int y, int type) {
        Vector3Int pos = new Vector3Int(x, y, 0);
        if (type == 1)
        {
            myScreen.SetTile(pos, darkTile);
        }
        else
        {
            myScreen.SetTile(pos, lightTile);
        }
    }

    public void FillPlayer()
    {
        switch (playerState)
        {
            case 0: //player is standing
                fillPixel(playerLoc.x - 2, playerLoc.y + 3, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y + 3, 1);
                fillPixel(playerLoc.x, playerLoc.y + 3, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y + 3, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y + 3, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y + 2, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y + 2, 0);
                fillPixel(playerLoc.x, playerLoc.y + 2, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y + 2, 0);
                fillPixel(playerLoc.x + 2, playerLoc.y + 2, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y + 1, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y + 1, 1);
                fillPixel(playerLoc.x, playerLoc.y + 1, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y + 1, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y + 1, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y, 1);
                fillPixel(playerLoc.x, playerLoc.y, 0);
                fillPixel(playerLoc.x + 1, playerLoc.y, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y - 1, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y - 1, 1);
                fillPixel(playerLoc.x, playerLoc.y - 1, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y - 1, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y - 1, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y - 2, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y - 2, 1);
                fillPixel(playerLoc.x, playerLoc.y - 2, 0);
                fillPixel(playerLoc.x + 1, playerLoc.y - 2, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y - 2, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y - 3, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y - 3, 1);
                fillPixel(playerLoc.x, playerLoc.y - 3, 0);
                fillPixel(playerLoc.x + 1, playerLoc.y - 3, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y - 3, 0);
                break;
            case 1: //player is crouching to jump
                fillPixel(playerLoc.x - 2, playerLoc.y + 3, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y + 3, 1);
                fillPixel(playerLoc.x, playerLoc.y + 3, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y + 3, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y + 3, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y + 2, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y + 2, 0);
                fillPixel(playerLoc.x, playerLoc.y + 2, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y + 2, 0);
                fillPixel(playerLoc.x + 2, playerLoc.y + 2, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y + 1, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y + 1, 1);
                fillPixel(playerLoc.x, playerLoc.y + 1, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y + 1, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y + 1, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y, 1);
                fillPixel(playerLoc.x, playerLoc.y, 0);
                fillPixel(playerLoc.x + 1, playerLoc.y, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y - 1, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y - 1, 1);
                fillPixel(playerLoc.x, playerLoc.y - 1, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y - 1, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y - 1, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y - 2, 1);
                fillPixel(playerLoc.x - 1, playerLoc.y - 2, 0);
                fillPixel(playerLoc.x, playerLoc.y - 2, 0);
                fillPixel(playerLoc.x + 1, playerLoc.y - 2, 0);
                fillPixel(playerLoc.x + 2, playerLoc.y - 2, 1);

                fillPixel(playerLoc.x - 2, playerLoc.y - 3, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y - 3, 1);
                fillPixel(playerLoc.x, playerLoc.y - 3, 0);
                fillPixel(playerLoc.x + 1, playerLoc.y - 3, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y - 3, 0);
                break;
            case 2: //player is jumping
                fillPixel(playerLoc.x - 2, playerLoc.y + 3, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y + 3, 0);
                fillPixel(playerLoc.x, playerLoc.y + 3, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y + 3, 0);
                fillPixel(playerLoc.x + 2, playerLoc.y + 3, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y + 2, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y + 2, 1);
                fillPixel(playerLoc.x, playerLoc.y + 2, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y + 2, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y + 2, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y + 1, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y + 1, 1);
                fillPixel(playerLoc.x, playerLoc.y + 1, 0);
                fillPixel(playerLoc.x + 1, playerLoc.y + 1, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y + 1, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y, 1);
                fillPixel(playerLoc.x, playerLoc.y, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y - 1, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y - 1, 1);
                fillPixel(playerLoc.x, playerLoc.y - 1, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y - 1, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y - 1, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y - 2, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y - 2, 1);
                fillPixel(playerLoc.x, playerLoc.y - 2, 0);
                fillPixel(playerLoc.x + 1, playerLoc.y - 2, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y - 2, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y - 3, 1);
                fillPixel(playerLoc.x - 1, playerLoc.y - 3, 0);
                fillPixel(playerLoc.x, playerLoc.y - 3, 0);
                fillPixel(playerLoc.x + 1, playerLoc.y - 3, 0);
                fillPixel(playerLoc.x + 2, playerLoc.y - 3, 1);
                break;
            case 3: //player is dying
                fillPixel(playerLoc.x - 2, playerLoc.y + 3, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y + 3, 1);
                fillPixel(playerLoc.x, playerLoc.y + 3, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y + 3, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y + 3, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y + 2, 1);
                fillPixel(playerLoc.x - 1, playerLoc.y + 2, 0);
                fillPixel(playerLoc.x, playerLoc.y + 2, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y + 2, 0);
                fillPixel(playerLoc.x + 2, playerLoc.y + 2, 1);

                fillPixel(playerLoc.x - 2, playerLoc.y + 1, 1);
                fillPixel(playerLoc.x - 1, playerLoc.y + 1, 1);
                fillPixel(playerLoc.x, playerLoc.y + 1, 0);
                fillPixel(playerLoc.x + 1, playerLoc.y + 1, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y + 1, 1);

                fillPixel(playerLoc.x - 2, playerLoc.y, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y, 1);
                fillPixel(playerLoc.x, playerLoc.y, 1);
                fillPixel(playerLoc.x + 1, playerLoc.y, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y - 1, 1);
                fillPixel(playerLoc.x - 1, playerLoc.y - 1, 1);
                fillPixel(playerLoc.x, playerLoc.y - 1, 0);
                fillPixel(playerLoc.x + 1, playerLoc.y - 1, 1);
                fillPixel(playerLoc.x + 2, playerLoc.y - 1, 1);

                fillPixel(playerLoc.x - 2, playerLoc.y - 2, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y - 2, 0);
                fillPixel(playerLoc.x, playerLoc.y - 2, 0);
                fillPixel(playerLoc.x + 1, playerLoc.y - 2, 0);
                fillPixel(playerLoc.x + 2, playerLoc.y - 2, 0);

                fillPixel(playerLoc.x - 2, playerLoc.y - 3, 0);
                fillPixel(playerLoc.x - 1, playerLoc.y - 3, 0);
                fillPixel(playerLoc.x, playerLoc.y - 3, 0);
                fillPixel(playerLoc.x + 1, playerLoc.y - 3, 0);
                fillPixel(playerLoc.x + 2, playerLoc.y - 3, 0);
                break;
            default:
                break;
        }
    }
}
