using Scripts.Events;
using SuperMaxim.Messaging;
using System.Collections.Generic;
using UnityEngine;

public class LivesView : MonoBehaviour
{
    [SerializeField] private GameObject LifeIconPrefab;
    [SerializeField] private Transform LivesParent;
    [SerializeField] private GameRules gameRules;

    private List<GameObject> livesIcon = new List<GameObject>();

    private void Awake()
    {
        Messenger.Default.Subscribe<PlayerDieEvent>(OnPlayerDieEvent);

        for (int i = 0; i < gameRules.lives; i++)
        {
            livesIcon.Add(Instantiate(LifeIconPrefab, LivesParent));
        }
    }

    private void OnPlayerDieEvent(PlayerDieEvent playerDieEvent)
    {
        if (livesIcon != null && livesIcon.Count > 0)
        {
            Destroy(livesIcon[0]);
            livesIcon.RemoveAt(0);
        }
    }


    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<PlayerDieEvent>(OnPlayerDieEvent);
    }
}