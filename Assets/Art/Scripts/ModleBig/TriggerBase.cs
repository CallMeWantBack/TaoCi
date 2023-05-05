using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using QFramework.Example;
using TMPro;

public class TriggerBase : MonoBehaviour
{
    [Header("多模的模型UI")]
    public List<GameObject> operaBigUI;

    [Header("多模的触发模型物体")]
    public List<GameObject> operaBigModle;

    [Header("提示步骤信息")]
    public List<string> infoTuzi;
    private bool IsOneModleincrease;
    private bool IsOneUIincrease;
    private void Awake()
    {
        IsOneModleincrease = false;
        IsOneUIincrease = false;
    }
  
    public void ShowHideUiORModle()
    {
        for (int i = 0; i < TriggerOther.GetInstance().operaBigModles.Count; i++)
        {
            
            if (this.name == TriggerOther.GetInstance().operaBigModles[i].name + "(Clone)")
            {
                if (IsOneModleincrease == false)
                {
                    operaBigModle.Add(TriggerOther.GetInstance().operaBigModles[i]);
                    IsOneModleincrease = true;
                }

                TriggerOther.GetInstance().operaBigModles[i].SetActive(true);
            }
           

        }
        for (int i = 0; i < TriggerData.GetInstance().operaBigUI.Count; i++)
        {
           
            if (this.name == TriggerData.GetInstance().operaBigUI[i].GetComponent<DragUI>().prefabName + "(Clone)")
            {
                if (IsOneUIincrease == false)
                {
                    operaBigUI.Add(TriggerData.GetInstance().operaBigUI[i]);
                }
                IsOneUIincrease = true;

                TriggerData.GetInstance().operaBigUI[i].SetActive(false);
                TriggerData.GetInstance().operaBigUI[i].GetComponent<DragUI>().dragObj.SetActive(false);

            }
        }
    }
    public void HideModlePar(string infor, List<GameObject> uigameobjects, List<GameObject> modlegameobjects)
    {
        for (int i = 0; i < TriggerData.GetInstance().operaBigUI.Count; i++)
        {

            TriggerData.GetInstance().operaBigUI[i].SetActive(false);
            for (int y = 0; y < uigameobjects.Count; y++)
            {
               
                if (operaBigUI[y].name == uigameobjects[y].name)
                {
                    uigameobjects[y].SetActive(true);
                    uigameobjects[y].AsFirstSibling();
                }
            }
        }
        UIKit.GetPanel<ExpriMainPanel>().RemindImage.transform.GetChild(0).GetComponent<TMP_Text>().text = infor;
        TriggerOther.GetInstance().SetView();
      
    }
    public void HideModleExper( List<GameObject> uigameobjects, List<GameObject> modlegameobjects)
    {
        for (int i = 0; i < TriggerData.GetInstance().operaBigUI.Count; i++)
        {

            TriggerData.GetInstance().operaBigUI[i].SetActive(false);
            for (int y = 0; y < uigameobjects.Count; y++)
            {
                print(string.Format("<color=red>{0}</color>", operaBigUI[y].name + "-----------------" + uigameobjects[y].name));
                if (operaBigUI[y].name == uigameobjects[y].name)
                {
                    uigameobjects[y].SetActive(true);
                    uigameobjects[y].AsFirstSibling();
                }
            }
        }

    }
}
