﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;                      //needed for EletementAT


namespace Triangle.ItemSystem
{
    public class ISQualityDatabase : ScriptableObjectDatabase<ISQuality>
    {
/*        [SerializeField]
        List<ISQuality> database = new List<ISQuality>();

        public void Add(ISQuality item)
        {
            database.Add(item);
            EditorUtility.SetDirty(this);
        }

        public void Insert( int index, ISQuality item)
        {
            database.Insert(index, item);
            EditorUtility.SetDirty(this);
        }

        public void Remove(ISQuality item)
        {
            database.Remove(item);
            EditorUtility.SetDirty(this);
        }

        public void Remove(int index)
        {
            database.RemoveAt(index);
            EditorUtility.SetDirty(this);
        }

        public int Count
        {
            get { return database.Count; }
        }

        public ISQuality Get(int index)
        {
            return database.ElementAt(index);
        }

        public void Replace(int index, ISQuality item)
        {
            database[index] = item;
            EditorUtility.SetDirty(this);
        }*/

    }
}
