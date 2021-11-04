using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //itemleri boyle de tutabiliriz sturct genisletmekten daha kolay olabilir
    public List<Item> items;

    public inventory invent;

    public void SetUp()
    {
        items = new List<Item>();
        //TODO:  burada da acilista dosyadan okuyacak

        //ilk açılışta hepsi false, itemları topladıkça true'ya çekilecek.
        invent.attickey = false;
        invent.masterkey = false;
        invent.rope = false;
        invent.match = false;

    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public struct inventory
    {
        public bool attickey;
        public bool masterkey;
        public bool match;
        public bool rope;

    }
}