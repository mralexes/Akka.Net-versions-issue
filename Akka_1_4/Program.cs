using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Bootstrap.Docker;

namespace Akka_1_4
{
    class Program
    {
        private static readonly string Config = @"
        {
            ""akka"": {
              ""loglevel"": ""Warning"",
              ""actor"": {
                ""provider"": ""cluster"",
              },
              ""remote.dot-netty.tcp.batching.enabled"":""false""
              cluster{
                seeds = [""akka.tcp://1_3@seed_1_3_1:2200,akka.tcp://1_3@seed_1_3_2:2201,akka.tcp://1_3@seed_1_3_3:2202""]
              }
            }
          }
        ";


        static async Task Main(string[] args)
        {
            var bootstrapFromDocker = DockerBootstrap.BootstrapFromDocker(Config);

            using (var actorSystem = ActorSystem.Create("1_3", Config))
            {
                await actorSystem.WhenTerminated;
            }
        }
    }
}
