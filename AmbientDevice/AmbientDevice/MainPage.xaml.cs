using System;
using System.Net.Mqtt;
using System.Text;
using Xamarin.Forms;

namespace AmbientDevice
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            InitializeControls();
        }

        public void InitializeControls()
        {
            RSS.Clicked += (s, e) =>
            {
                new Mqtt().MqttPublish("{\"option\":\"1\"}");
            };

            Time.Clicked += (s, e) =>
            {
                new Mqtt().MqttPublish("{\"option\":\"2\"}");
            };

            Messages.Clicked += (s, e) =>
            {
                new Mqtt().MqttPublish("{\"option\":\"4\"}");
            };

            Gmail.Clicked += (s, e) =>
            {
                new Mqtt().MqttPublish("{\"option\":\"3\"}");
                //if (string.IsNullOrEmpty(User.Text) || string.IsNullOrEmpty(Password.Text)) {
                //    DisplayAlert("Alerta", "Para acceder a la opción de Gmail, entre los datos de usuario y contraseña.", "OK");
                //} else {
                //    new Mqtt().MqttPublish("{\"option\":\"3\",\"user\":\"" + RijndaelAlg.encryptString(User.Text) + "\",\"password\":\"" + RijndaelAlg.encryptString(Password.Text) + "\"}");
                //}
            };
        }


    }
}
