

using System.Collections.Generic;

namespace QFramework.Example
{
    class OperaModle : AbstractModel
    {
        public enum OperaStateID
        {
            //空的状态
            NullState = 0,
            //模种
            MoZhong,
            //脱模剂
            TuoMoJi,
            //泥巴
            NiBa,
            //木刀
            MuDao,
            //水
            Water,
            //石膏粉
            ShiGaoFen,
            //刮刀
            GuaDao,
            //木刀1
            MuDao1,
            //注浆口
            ZhuJiangKou,
            //强逼
            QiangBi,
            //备制石膏
            BeiZhiShiGao,
            //亚克力板
            YaKeLIBang,
            //固定金属
            GuDingJingShu,
            //木锤
            MuChui,
            //弹力带
            TangLiDai,
            //泥浆
            NiJiang,
            //金属刀
            JingShuDao,
            //软板
            RuanBang,
            //绳子
            ShengZi,
            //倒入另一侧石膏
            OtherShiGao,
            //刮刀1
            GuaDao1,
            //裁线
            Line,
        }
        public OperaStateID operaNum;
        public bool isSecond { get; set; }

        public Dictionary<string, float> grades = new Dictionary<string, float>();

        public float grade  { get; set; }
        public bool isClick { get; set; }

        public bool isUITrigger { get; set; }

        public bool isModelClick { get; set; }

        public bool isModelClickTwo { get; set; }

        public bool isModelClickThree { get; set; }

        public bool isModelClickFour { get; set; }
        public bool isModelClickFive { get; set; }
        public bool isModelClickSix { get; set; }
        public bool isModelClickSeven { get; set; }

        /// <summary>
        /// 实验类型
        /// </summary>
        public enum ExperimentType
        {
            /// <summary>
            /// 默认实验类型
            /// </summary>
            None,

            /// <summary>
            /// 对称型(单模)
            /// </summary>
            One,

            /// <summary>
            /// 异型模(多模)
            /// </summary>
            Two,

        }

        /// <summary>
        /// 考核训练
        /// </summary>
        public enum ExperimentState
        {
            /// <summary>
            /// 默认实验类型
            /// </summary>
            None,

            /// <summary>
            /// 考核
            /// </summary>
            Examine,

            /// <summary>
            /// 练习
            /// </summary>
            Practise,

        }


        public ExperimentType experimentType;
        public ExperimentState experimentState;
        protected override void OnInit()
        {
            experimentType = ExperimentType.None;
            experimentState = ExperimentState.None;
            grade = 0;
            isSecond = true;
            isClick = false;
            isUITrigger = false;
            isModelClick = false;
            isModelClickTwo = false;
            isModelClickThree = false;
            isModelClickFour = false;
            isModelClickFive = false;
            isModelClickSix = false;
            isModelClickSeven = true;
        }
    }
}
