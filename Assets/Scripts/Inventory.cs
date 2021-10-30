using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public inventory invent;

    public void SetUp()
    {
        //ilk açılışta hepsi false, itemları topladıkça true'ya çekilecek.
        invent.attickey = false;
        invent.masterkey = false;
        invent.rope = false;
        invent.match = false;



    }
    public struct inventory
    {
        public bool attickey;
        public bool masterkey;
        public bool match;
        public bool rope;

    }
}