using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SettingObject : MonoBehaviour
{
    private List<Object> _inventory;
    private Field _field;
    private void Start()
    {
        _inventory = Storage.Inventory;
        _field = new Field();
    }
    void Update()
    {
        if (_inventory.Count>0)
        {
            var obj = _inventory[0];
            _field.AddElementToCell(obj.x, obj.y,obj.ObjPrefab,null,1);
            _inventory.Clear();
        }
    }
}
