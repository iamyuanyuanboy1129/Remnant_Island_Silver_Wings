using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public QuestGoal goal;

    public Player player;

    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI goldText;
    public GameObject guidanceWindow;
    public TextMeshProUGUI guideTitleText;
    public TextMeshProUGUI guideDescriptionText;
    
    private void Start()
    {
        
    }
    private void Update()
    {
        ChangeGuidanceState();
    }
    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        goldText.text = quest.goldReward.ToString();
    }

    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        player.quest = quest;
        guidanceWindow.SetActive(true);
        guideTitleText.text=quest.title;
        ChangeGuidanceState();
    }
    public void ChangeGuidanceState()
    {
        guideDescriptionText.text = Convert.ToString($"Kill enemy:{goal.currentAmount}/{goal.requiredAmount}");
    }
}
