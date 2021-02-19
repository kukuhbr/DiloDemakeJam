using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace NFS.Car.Movements
{
    [CreateAssetMenu(fileName = "GearShiftCategory", menuName = "ScriptableObjects/Cars/GearShiftCategory", order = 1)]
    public class GearShiftCategory : ScriptableObject
    {
        public List<string> categories;
        public List<float> minPercents;
        public List<float> maxPercents;
        public List<float> categoryValues;
        public float missValue;

        public bool IsGearShiftInCategory(string category, float val, float maxVal)
        {
            float percentage = val / maxVal;
            if (categories.Contains(category))
            {
                int index = categories.IndexOf(category);
                float min = minPercents[index];
                float max = maxPercents[index];
                return ((percentage >= min) && (percentage < max));
            }
            else
            {
                return false;
            }            
        }

        public string GetCategory(float val, float maxVal)
        {
            float percentage = val / maxVal;
            int i = 0;
            string checkCategory = "";
            while (
                (i < categories.Count) 
                && (!IsGearShiftInCategory(checkCategory, val, maxVal))
                )
            {
                checkCategory = categories[i];
                i = i + 1;
            }
            return checkCategory;
        }

        public bool IsInAnyCategory(float val, float maxVal)
        {
            string category = GetCategory(val, maxVal);
            return (category == "");
        }

        public float GetCategoryValue(float val, float maxVal)
        {
            if (IsInAnyCategory(val, maxVal))
            {
                string category = GetCategory(val, maxVal);
                int index = categories.IndexOf(category);
                return categoryValues[index];
            }
            else
            {
                return missValue;
            }
        }
    }
}
