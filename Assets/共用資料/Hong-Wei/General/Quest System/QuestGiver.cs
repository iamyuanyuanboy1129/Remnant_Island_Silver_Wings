using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public Player player;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI guideTitleText;
    public TextMeshProUGUI guideDescriptionText;
    
    private void Update()
    {
        ChangeGuidanceState();
    }
    public void OpenQuestWindow()
    {
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        goldText.text = quest.goldReward.ToString();
    }

    public void AcceptQuest()
    {
        quest.isActive = true;
        player.quest = quest;
        guideTitleText.text=quest.title;
        ChangeGuidanceState();
    }
    public void ChangeGuidanceState()
    {
        guideDescriptionText.text = Convert.ToString($"Kill enemy:{quest.goal.currentAmount}/{quest.goal.requiredAmount}");
    }
}
