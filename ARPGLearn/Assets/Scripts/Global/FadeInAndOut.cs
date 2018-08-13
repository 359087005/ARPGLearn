using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace Global
{
    /// <summary>
    /// 公共层：场景淡入淡出
    /// </summary>
    /// 
    public class FadeInAndOut : MonoBehaviour
    {
        public static FadeInAndOut _Instance;
        public GameObject _RawObj;
        public float _ColorChangeSpeed = 1f;

        private RawImage _RawImage;
        private bool _BoolScenesToClear = true;
        private bool _BoolScenesToAppear = false;
        void Awake()
        {
            _Instance = this;
        }

        void Start()
        {
            if (_RawObj)
            {
                _RawImage = _RawObj.GetComponent<RawImage>();
            }
        }

        void Update()
        {
            if (_BoolScenesToClear)
            {
                SceneToClear();
            }
            else if (_BoolScenesToAppear)
            {
                SceneToAppear();
            }
        }
        /// <summary>
        /// 对外接口   设置场景淡入
        /// </summary>
        public void SetScreenToClear()
        {
            _BoolScenesToAppear = false;
            _BoolScenesToClear = true;
        }
        /// <summary>
        /// 对外接口   设置场景淡出
        /// </summary>
        public void SetScreenToAppear()
        {
            _BoolScenesToAppear = true;
            _BoolScenesToClear = false;
        }

        private void FadeToClear()
        {
            _RawImage.color = Color.Lerp(_RawImage.color, Color.clear, _ColorChangeSpeed * Time.deltaTime);
        }

        private void FadeToAppear()
        {
            _RawImage.color = Color.Lerp(_RawImage.color, Color.black, _ColorChangeSpeed * Time.deltaTime);
        }

        private void SceneToClear()
        {
            FadeToClear();

            if (_RawImage.color.a <= 0.05f)
            {
                _RawImage.color = Color.clear;
                _RawImage.enabled = false;
                _BoolScenesToClear = false;
            }
        }

        private void SceneToAppear()
        {
            _RawImage.enabled = true;
            FadeToAppear();
            if (_RawImage.color.a >= 0.95f)
            {
                _RawImage.color = Color.black;
                _BoolScenesToAppear = false;
            }
        }
    }
}


