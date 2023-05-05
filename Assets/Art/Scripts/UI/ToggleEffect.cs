using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PicklePro
{
    /// <summary>
    /// ImageEffect
    /// </summary>
    public class ToggleEffect : UIBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField]
        public Sprite normalSprite;
        [SerializeField]
        private Sprite highlightSprite;
        [SerializeField]
        public Sprite isOnSprite;
        [SerializeField]
        private Color textNormalColor;
        [SerializeField]
        private Color textHighlightColor;
        [SerializeField]
        private Color textOnColor;

        private Image currentImage;
        private TMP_Text currentText;
        [SerializeField]
        private bool m_IsOn = false;
        [SerializeField]
        private ToggleEffectGroup m_Group;

        /// <summary>
        /// Group the toggle belongs to.
        /// </summary>
        public ToggleEffectGroup group
        {
            get { return m_Group; }
            set
            {
                SetToggleGroup(value, true);
                PlayEffect(true);
            }
        }
        public bool isOn
        {
            get { return m_IsOn; }

            set
            {
                Set(value);
                PlayEffect(isOn);
            }
        }
        [Serializable]
        /// <summary>
        /// UnityEvent callback for when a toggle is toggled.
        /// </summary>
        public class ToggleEvent : UnityEvent<bool>
        { }
        public ToggleEvent onValueChanged = new ToggleEvent();
        private void Awake()
        {
            currentImage = this.GetComponent<Image>();
            currentText = this.transform.GetComponentInChildren<TMP_Text>();
            currentText.color = textNormalColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (isOn)
                return;
            currentImage.sprite = highlightSprite;
            currentText.color = textHighlightColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (isOn)
                return;
            currentImage.sprite = isOn ? isOnSprite : normalSprite;
            currentText.color = textNormalColor;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            isOn = !isOn;
            currentImage.sprite = isOn ? isOnSprite : normalSprite;
            currentText.color = isOn ? textOnColor : textNormalColor;
        }

        private void PlayEffect(bool instant)
        {
            if (currentImage == null || currentText == null)
                return;

#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                currentImage.sprite = m_IsOn ? isOnSprite : normalSprite;
                currentText.color = isOn ? textOnColor : textNormalColor;
            }
            else
#endif
            {
                currentImage.sprite = isOn ? isOnSprite : normalSprite;
                currentText.color = isOn ? textOnColor : textNormalColor;
            }
        }

        private void SetToggleGroup(ToggleEffectGroup newGroup, bool setMemberValue)
        {
            // Sometimes IsActive returns false in OnDisable so don't check for it.
            // Rather remove the toggle too often than too little.
            if (m_Group != null)
                m_Group.UnregisterToggle(this);

            // At runtime the group variable should be set but not when calling this method from OnEnable or OnDisable.
            // That's why we use the setMemberValue parameter.
            if (setMemberValue)
                m_Group = newGroup;

            // Only register to the new group if this Toggle is active.
            if (newGroup != null && IsActive())
                newGroup.RegisterToggle(this);

            // If we are in a new group, and this toggle is on, notify group.
            // Note: Don't refer to m_Group here as it's not guaranteed to have been set.
            if (newGroup != null && isOn && IsActive())
                newGroup.NotifyToggleOn(this);
        }
        public void SetIsOnWithoutNotify(bool value)
        {
            Set(value, false);
        }
        void Set(bool value, bool sendCallback = true)
        {
            if (m_IsOn == value)
                return;

            // if we are in a group and set to true, do group logic
            m_IsOn = value;
            if (m_Group != null && IsActive())
            {
                if (m_IsOn || (!m_Group.AnyTogglesOn() && !m_Group.allowSwitchOff))
                {
                    m_IsOn = true;
                    m_Group.NotifyToggleOn(this, sendCallback);
                }
            }

            if (sendCallback)
            {
                onValueChanged.Invoke(m_IsOn);
            }
        }

        protected override void OnDestroy()
        {
            if (m_Group != null)
                m_Group.EnsureValidState();
            base.OnDestroy();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            SetToggleGroup(m_Group, false);
            PlayEffect(true);
        }

        protected override void OnDisable()
        {
            SetToggleGroup(null, false);
            base.OnDisable();
        }
    }
}