using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;

namespace neeko
{
    internal class UiElement
    {
        public string Name { get; }
        public GameObject GameObject { get; }
        public RectTransform RectTransform { get; }
        public Vector3 Position
        {
            get
            {
                return this.RectTransform.localPosition;
            }
            set
            {
                this.RectTransform.localPosition = value;
            }
        }
        public bool Active
        {
            get
            {
                return this.GameObject.activeSelf;
            }
            set
            {
                this.GameObject.SetActive(value);
            }
        }
        public UiElement(Transform transform)
        {
            this.RectTransform = transform.GetComponent<RectTransform>();
            if (this.RectTransform == null)
            {
                throw new ArgumentException("Transform has to be a RectTransform.", "transform");
            }
            this.GameObject = transform.gameObject;
            this.Name = this.GameObject.name;
        }
        public UiElement(GameObject original, Transform parent, Vector3 pos, string name, bool defaultState = true) : this(original, parent, name, defaultState)
        {
            this.GameObject.transform.localPosition = pos;
        }
        public UiElement(GameObject original, Transform parent, string name, bool defaultState = true)
        {
            this.GameObject = UnityEngine.Object.Instantiate<GameObject>(original, parent);
            this.GameObject.name = UiElement.GetCleanName(name);
            this.Name = this.GameObject.name;
            this.GameObject.SetActive(defaultState);
            this.RectTransform = this.GameObject.GetComponent<RectTransform>();
        }
        public virtual void Destroy()
        {
            UnityEngine.Object.Destroy(this.GameObject);
        }
        public static string GetCleanName(string name)
        {
            return Regex.Replace(Regex.Replace(name, "<.*?>", string.Empty), "[^0-9a-zA-Z_]+", string.Empty);
        }
    }
}
