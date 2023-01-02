using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabManager : MonoBehaviour
{
    // Serialize this shit
    List<Button> tabs = new List<Button>();
    [SerializeField] Button tabPrefab;
    string[] tabNames = { "UI Elements", "Obstacles", "???", "Experimental" };

    private void Start()
    {
        int i = 0;
        foreach (var tabName in tabNames)
        {
            Button tab = Instantiate<Button>(tabPrefab, this.transform, false);
            tab.name = tabName;
            tab.GetComponentInChildren<TextMeshProUGUI>().text = tabName;

            float width = tab.GetComponent<RectTransform>().sizeDelta.x;
            tab.transform.localPosition = new Vector3(width*i + 13*i, 0, 0);

            tabs.Add(tab);

            i++;
        }

        SelectTab(tabs[0].name);
    }

    // Currently this invokes only the tab collector. You should assign every tab a script and have them do whatever instead
    public void SelectTab(Button selectedTab) {
        DeselectAllTabs();
        HighlightTab(selectedTab);
    }
    public void SelectTab(string tabName)
    {
        DeselectAllTabs();

        Button currentTab = GameObject.Find(tabName).GetComponent<Button>();
        HighlightTab(currentTab);
    }

    void HighlightTab(Button tab)
    {
        GameObject obj = tab.gameObject;
        Image image = obj.GetComponent<Image>();
        image.color = new Color(0.29f, 0.62f, 1);
    }

    void DeselectAllTabs()
    {
        foreach (Button tab in tabs)
        {
            Image image = tab.GetComponent<Image>();
            image.color = Color.white;
        }
    }

    //void ShowTabContents()
    //{
    //    FindObjectOfType
    //}

    // Gameplay tab
    // Mostly things that contribute to the main flow of the game like
    // more obstacles, multipliers, glowing squares, etc.
    //
    // Grants score boosting for that one run.

    // Features tab
    // Things that contribute to the game itself. Example: skybox, skins,
    // mats, extra functionality, narration, etc.
    //
    // Grants score multiplication / percentage boost 

    // ?? tab
    // Weird ARG shit that grants a permanent % boost/multiplier
    // Requires massive brain thinking to unlock.
    //
    // Opens up new gamemodes/challenges to further boost permanent stacks (invisible wall challenge/solving main puzzle using shadows challenge/etc.)
    // Also unlocks spooky things ingame
}
