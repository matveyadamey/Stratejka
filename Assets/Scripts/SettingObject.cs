using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SettingObject : MonoBehaviour
{
    List<Object> inventory;
    Field field;
    private void Start()
    {
        inventory = Storage.Inventory;
        field = new Field();
    }
    void Update()
    {
        if (inventory.Count>0)
        {
            var obj = inventory[0];
            field.addElementToCell(obj.x, obj.y,obj.objPrefab,null,1);
            inventory.Clear();
        }
    }
}
