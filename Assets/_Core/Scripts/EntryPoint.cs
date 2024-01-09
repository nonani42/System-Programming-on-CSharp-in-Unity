using System.Threading;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject prefabPopup;

    private void TryBuyItem()
    {
        GameObject newPopup = Instantiate(prefabPopup);
        SomePopup popupScript = newPopup.GetComponentInChildren<SomePopup>();
        popupScript.OnClose += CompletePurhase;
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken ct = cts.Token;
        popupScript.ActivatePopup(ct);
    }

    private void CompletePurhase(bool completed)
    {
        if (completed) Debug.Log("Покупка совершена!");
        else Debug.Log("Покупка отменена!");
    }

    void Start()
    {
        TryBuyItem();
    }

    void Update()
    {
        
    }
}
