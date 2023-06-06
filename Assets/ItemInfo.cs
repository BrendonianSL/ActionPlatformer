using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public GameObject itemDisplay;

    public string itemName;
    [SerializeField] ItemReceiver itemReceiver;
    // Start is called before the first frame update
    void Awake()
    {
        
        itemDisplay = GameObject.Find("IE");
        Debug.Log(itemDisplay);
        itemDisplay.SetActive(false);
        itemName = "Cannon";
    }

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            itemDisplay.SetActive(true);
            itemReceiver = GameObject.Find("IE").GetComponent<ItemReceiver>();
            itemReceiver.ItemInfoInsert(itemName);
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        itemDisplay.SetActive(false);
    }
}
