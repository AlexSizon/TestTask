using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastlesPosGenerator : MonoBehaviour
{
    public Transform CastlePrefab;
    public Transform PlayerCastlePrefab;
    public Transform Cam;
    private void Start()
    {
        Invoke("CastlesPlacement", 0.5f);
    }
    private void CastlesPlacement()
    {
        var fieldCellsList = GameObject.FindGameObjectsWithTag("FieldCell");
        int[] castlesPos = GetCastlesPos();
        string tempCellName = "";
        Transform tempTransformCell;
        for (int i = 0; i < castlesPos.Length-1; i++)
        {
            tempCellName = fieldCellsList[castlesPos[i] - 1].name;
            tempTransformCell = fieldCellsList[castlesPos[i] - 1].transform;
            Destroy(fieldCellsList[castlesPos[i] - 1]);
            if (i==0)
            {
                Transform playercastle = Instantiate(PlayerCastlePrefab) as Transform;
                playercastle.transform.position = tempTransformCell.position;
                Cam.SetPositionAndRotation(new Vector3(tempTransformCell.position.x, tempTransformCell.position.y,-10),new Quaternion());
                playercastle.name = tempCellName;
                playercastle.parent = this.transform;
            }
            else
            {
                Transform castle = Instantiate(CastlePrefab) as Transform;
                castle.transform.position = tempTransformCell.position;
                castle.name = tempCellName;
                castle.parent = this.transform;
            }
        }
    }
    private int[] GetCastlesPos()
    {
        var rand = new System.Random();
        int[] castlesPos = new int[rand.Next(4, 6)];
        bool Unique;
        for (int i = 0; i < castlesPos.Length; i++)
        {
            do
            {
                castlesPos[i] = rand.Next(0, GridGenerator.gridHeight * GridGenerator.gridWidth);
                Unique = true;
                for (int j = 0; j < i; j++)
                {
                    if (castlesPos[i] == castlesPos[j])
                    {
                        Unique = false;
                        break;
                    }
                }
            } while (!Unique);
        }
        return castlesPos;
    }
}