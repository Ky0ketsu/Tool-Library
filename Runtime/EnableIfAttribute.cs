using UnityEngine;

namespace Ky0ketsu
{
    public class EnableIfAttribute : PropertyAttribute
    {
        public string fieldName {  get; set; } = string.Empty;

        public EnableIfAttribute(string fieldName)
        {
            this.fieldName = fieldName;
        }
    }
}
