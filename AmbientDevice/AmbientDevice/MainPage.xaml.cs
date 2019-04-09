using System;
using System.Net.Mqtt;
using System.Text;
using Xamarin.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace AmbientDevice
{
    public partial class MainPage : ContentPage
    {
        // create client instance 
        uPLibrary.Networking.M2Mqtt.MqttClient client = new uPLibrary.Networking.M2Mqtt.MqttClient("192.168.0.5");

        public MainPage()
        {
            InitializeComponent();
            InitializeControls();

            // register to message received 
            //client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            // subscribe to the topic "/home/temperature" with QoS 2 
            client.Subscribe(new string[] { "ambientdevice/options" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
        }

        public void InitializeControls()
        {
            RSS.Clicked += (s, e) =>
            {
                client.Publish("ambientdevice/option", Encoding.UTF8.GetBytes("{\"option\":\"1\"}"));
            };

            Time.Clicked += (s, e) =>
            {
                client.Publish("ambientdevice/option", Encoding.UTF8.GetBytes("{\"option\":\"2\"}"));
            };

            Messages.Clicked += (s, e) =>
            {
                client.Publish("ambientdevice/option", Encoding.UTF8.GetBytes("{\"option\":\"4\"}"));
            };

            Gmail.Clicked += (s, e) =>
            {
                client.Publish("ambientdevice/option", Encoding.UTF8.GetBytes("{\"option\":\"3\"}"));
            };
        }
        //void ChangeColor(Button button, bool activated = true)
        //{
        //    var color = activated ? Color.FromRgb(76, 175, 80) : Color.DarkCyan;
        //    button.SetValue(BackgroundColorProperty, color);
        //    button.BackgroundColor = color;
        //}

        //void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        //{
        //    var temp = Encoding.UTF8.GetString(e.Message);
        //    temp = temp.Trim();
        //    temp = temp.Replace("[", "");
        //    temp = temp.Replace("]", "");
        //    var o = temp.Split(","[0]);
        //    if (o[0].Trim().Equals("1"))
        //    {
        //        ChangeColor(RSS, true);              
        //    }
        //    else
        //    {
        //        ChangeColor(RSS, false);
        //    }
        //    if (o[1].Trim().Equals("1"))
        //    {
        //        ChangeColor(Time);
        //    }
        //    else
        //    {
        //        ChangeColor(Time, false);
        //    }
        //    if (o[2].Trim().Equals("1"))
        //    {
        //        ChangeColor(Gmail);
        //    }
        //    else
        //    {
        //        ChangeColor(Gmail, false);
        //    }
        //    if (o[3].Trim().Equals("1"))
        //    {
        //        ChangeColor(Messages);
        //    }
        //    else
        //    {
        //        ChangeColor(Messages, false);
        //    }

        //}
    }
}
