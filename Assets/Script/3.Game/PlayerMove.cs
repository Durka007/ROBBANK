﻿
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : ProfilePlayer
{
    private TimeBar _time;
    private GameObject cell;

    private float cell_start = 1;

    [SerializeField] private Button _button=null;


    private void Awake()
    {
        _time = GameObject.Find("TimeBar").GetComponent<TimeBar>();
    }

    public void SetInteractebal(bool Interactebal)
    {
        _button.interactable = Interactebal;
    }
    public void Move()
    {
        if (cell_start == 1)
             cell = CellNext();
        transform.position = new Vector3(transform.position.x + (cell.transform.position.x - transform.position.x - 0.1f), transform.position.y, transform.position.z);
         cell = CellNext();
        _time.SetStep(true);
    }

    private GameObject CellNext()
    {
        cell_start = cell_start + 1 * GetPlayerSpeed;
        string NameCellNext = "Cell_" + cell_start;
        return GameObject.Find(NameCellNext);
    }


}
