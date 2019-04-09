using System;
using System.Collections.Generic;
using System.Net.Mqtt;
using System.Text;

namespace AmbientDevice
{
    public class Mqtt
    {
        public async void MqttPublish(string parameter)
        {
            var configuration = new MqttConfiguration
            {
                BufferSize = 128 * 1024,
                Port = 1883,
                KeepAliveSecs = 10,
                WaitTimeoutSecs = 2,
                MaximumQualityOfService = MqttQualityOfService.AtMostOnce,
                AllowWildcardsInTopicFilters = true
            };
            var client = await MqttClient.CreateAsync("192.168.0.5", configuration);

            var sessionState = await client.ConnectAsync(new MqttClientCredentials(clientId: Guid.NewGuid().ToString("N")));

            var message1 = new MqttApplicationMessage("ambientdevice/option", Encoding.UTF8.GetBytes(parameter));

            await client.PublishAsync(message1, MqttQualityOfService.AtMostOnce); //QoS0

            await client.DisconnectAsync();
        }
    }
}