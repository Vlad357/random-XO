using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    public GameObject CellPrefab;
    public Text DescitionText;
    
    private List<GameObject> _cells;

    public void GenerationAnswer()
    {
        for(int Iteration = 0; Iteration != transform.childCount; Iteration++)
        {
            if (Random.value > 0.5)
            {
                _cells[Iteration].GetComponent<Cell>().ApllyToAnswer(Resources.Load<Sprite>("�������"));
            }
            else
            {
                _cells[Iteration].GetComponent<Cell>().ApllyToAnswer(Resources.Load<Sprite>("�����"));
            }
        }
    }

    public void Decision()
    {
        //������ ���������� ����� ������������ list
        bool CrossWin = false;
        bool ZeroWin = false;
        //������ �� �����������
        for(int Cell = 1; Cell != 7; Cell += 3)
        {
            if((_cells[Cell - 1].GetComponent<Cell>().Answer.sprite == _cells[Cell].GetComponent<Cell>().Answer.sprite) && (_cells[Cell + 1].GetComponent<Cell>().Answer.sprite == _cells[Cell].GetComponent<Cell>().Answer.sprite))
            {
                if(_cells[Cell].GetComponent<Cell>().Answer.sprite.name == "�������") CrossWin = true;
                else ZeroWin = true;
            }
        }
        //������ �� ���������
        for(int Cell = 3; Cell != 5; Cell ++)
        {
            if((_cells[Cell - 3].GetComponent<Cell>().Answer.sprite == _cells[Cell].GetComponent<Cell>().Answer.sprite) && (_cells[Cell + 3].GetComponent<Cell>().Answer.sprite == _cells[Cell].GetComponent<Cell>().Answer.sprite))
            {
                if (_cells[Cell].GetComponent<Cell>().Answer.sprite.name == "�������") CrossWin = true;
                else ZeroWin = true;
            }
        }
        //������ �� ���������
        if (_cells[4])
        {
            if ((_cells[4 - 4].GetComponent<Cell>().Answer.sprite == _cells[4].GetComponent<Cell>().Answer.sprite) && (_cells[4 + 4].GetComponent<Cell>().Answer.sprite == _cells[4].GetComponent<Cell>().Answer.sprite))
            {
                if (_cells[4].GetComponent<Cell>().Answer.sprite.name == "�������") CrossWin = true;
                else ZeroWin = true;
            }
            if ((_cells[4 - 2].GetComponent<Cell>().Answer.sprite == _cells[4].GetComponent<Cell>().Answer.sprite) && (_cells[4 + 2].GetComponent<Cell>().Answer.sprite == _cells[4].GetComponent<Cell>().Answer.sprite))
            {
                if (_cells[4].GetComponent<Cell>().Answer.sprite.name == "�������") CrossWin = true;
                else ZeroWin = true;
            }
        }
        if(ZeroWin  && CrossWin) DescitionText.text = "�����";
        if(!ZeroWin  && !CrossWin) DescitionText.text = "�����";
        if (CrossWin)DescitionText.text = "�������� ��������";
        else DescitionText.text = "�������� ������";
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for(int Iteration = 0; Iteration != 9; Iteration++)
        {
            GameObject CellObj = Instantiate(CellPrefab);
            CellObj.transform.SetParent(transform, false);
            _cells.Add(CellObj);
        }
    }
}
