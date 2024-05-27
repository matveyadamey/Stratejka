using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Highlighter : MonoBehaviour
{
    public static void HighlightOn(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }
    public static void HighlightOff(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
    public static void CanMoveChipOn(Point pos)
    {
        for(int x = pos.x - 1; x <= pos.x+1; x++)
        {
            for (int y = pos.y - 1; y <= pos.y + 1; y++)
            {
                Point posMove = new Point(x, y);
                Player player = PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber];
                if (MapObject.CheckCoord(posMove) && player.CanMoveChip(pos, posMove))
                {
                    //GameObject obj = Field.GetGameObjectCall(posMove);
                    Field.SetCellMaterial(posMove, StartGame.CanMoveMaterial);
                }
            }
        }
    }

    public static void CanMoveChipOff(Point pos)
    {
        for (int x = pos.x - 1; x <= pos.x + 1; x++)
        {
            for (int y = pos.y - 1; y <= pos.y + 1; y++)
            {
                Point p = new Point(x, y);
                if (!MapObject.CheckCoord(p))
                {
                    continue;
                }
                //GameObject obj = Field.GetGameObjectCall(p);
                Field.SetCellMaterial(p, StartGame.Materials[Field.GetCellLayer(p)]);
            }
        }
    }
}
