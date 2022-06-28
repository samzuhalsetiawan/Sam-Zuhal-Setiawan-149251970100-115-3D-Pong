using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class WallManager : MonoBehaviour
{
    public float riseWallHeight;
    public float riseWallSpeed;

    public void RiseWallPlayer(Player player)
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        GameObject wall = walls.Where(wall => wall.GetComponent<WallController>().player == player).ToList()[0];
        wall.GetComponent<WallController>().StartRiseWall();
    }
}
