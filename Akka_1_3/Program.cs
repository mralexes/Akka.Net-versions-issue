using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Bootstrap.Docker;

namespace Akka_1_3
{
    class Program
    {
        private static readonly string Config = @"
        {
            ""akka"": {
              ""loglevel"": ""Warning"",    
              ""actor"": {
                ""provider"": ""cluster""
              }
            }
          }
        ";


        static async Task Main(string[] args)
        {
            var bootstrapFromDocker = DockerBootstrap.BootstrapFromDocker(Config);

            using (var actorSystem = ActorSystem.Create(Environment.GetEnvironmentVariable("ACTOR_SYSTEM"), bootstrapFromDocker))
            {
                await actorSystem.WhenTerminated;
            }
        }
    }
}