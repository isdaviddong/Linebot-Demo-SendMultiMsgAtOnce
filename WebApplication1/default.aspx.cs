using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _default : System.Web.UI.Page
    {
        const string channelAccessToken = "!!!換成你自己的channelAccessToken!!!";
        const string AdminUserId= "!!!換成你自己的Admin User Id!!!";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(channelAccessToken);
            //建立buttonsTemplate
            var button = new isRock.LineBot.ButtonsTemplate()
            {
                altText = "altText",
                text = "text",
                title = "title",
                thumbnailImageUrl = new Uri("https://i.imgur.com/pAiJpHg.png")
            };
            //actions
            button.actions.Add(new isRock.LineBot.MessageAction()
            {
                label = "美式漢堡",
                text = "美式漢堡"
            });
            button.actions.Add(new isRock.LineBot.MessageAction()
            {
                label = "台灣漢堡",
                text = "台灣漢堡"
            });
            button.actions.Add(new isRock.LineBot.MessageAction()
            {
                label = "熱狗堡",
                text = "熱狗堡"
            });

            //建立訊息集合(一次發送多則訊息)
            var msgs = new List<isRock.LineBot.MessageBase>();
            //add messages to 
            msgs.Add(new isRock.LineBot.TextMessage("請選擇您喜歡的餐點:"));
            var ButtonsTmp = new isRock.LineBot.TemplateMessage(button);
            //quickReply
            ButtonsTmp.quickReply.items.Add(
                new isRock.LineBot.QuickReplyDatetimePickerAction(
                    "期望送達時間", "期望送達時間", isRock.LineBot.DatetimePickerModes.time));
            //將ButtonsTmp加入msgs
            msgs.Add(ButtonsTmp);
            //發送
            bot.PushMessage(AdminUserId, msgs);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            //發送貼圖
            bot.PushMessage(AdminUserId, 1,2);
        }
    }
}