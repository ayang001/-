using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winfromJD
{
    public class JSon
    {
        public class SignConfigVoListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string signDayStage { get; set; }
            /// <summary>
            /// 抽中红包
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string pictureUrl { get; set; }
            /// <summary>
            /// 明天继续抽红包哦
            /// </summary>
            public string copy1 { get; set; }
            /// <summary>
            /// 点击拿奖励
            /// </summary>
            public string desc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string signStatus { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string redPacketId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string advertGroupId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ynHit { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string hitTime { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string hitRate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ynRedPacket { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string exchangeNum { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string exchangeNumGrouped { get; set; }
        }

        public class LuckyDrawData
        {
            /// <summary>
            /// 
            /// </summary>
            public string checkWinOrNot { get; set; }
            /// <summary>
            /// 限购 [必品阁旗舰店] 店铺部分商品
            /// </summary>
            public string prizeName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string prizeImage { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string quota { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string discount { get; set; }
            /// <summary>
            /// 满199元使用
            /// </summary>
            public string quotaDesc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string discountDesc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string leftUseNum { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string batchId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string actId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string highPrice { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string useJumpUrl { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string couponStyle { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string couponKind { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string isCalculateSuc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string extend { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string goodCoupon { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string couponType { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string redPacketId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string redEnvelopesType { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string exchangeNum { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string brokerInfo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string mcInfo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string biClk { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string couponId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<SignConfigVoListItem> signConfigVoList { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string signBrokerInfo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string modelFlag { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string tertiaryCategory { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string skuName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string skuJumpUrl { get; set; }
            /// <summary>
            /// 限购 [必品阁旗舰店] 店铺部分商品
            /// </summary>
            public string limitStr { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string beginTimeStr { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string endTimeStr { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string couponSource { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string angleMarkUrl { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string angleMarkType { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string stockCoupon { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string backUpCoupon { get; set; }
        }

        public class Result
        {
            /// <summary>
            /// 
            /// </summary>
            public LuckyDrawData luckyDrawData { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public string code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string success { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string busiCode { get; set; }
            /// <summary>
            /// 成功
            /// </summary>
            public string message { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string currentTime { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Result result { get; set; }
        }

    }
}
