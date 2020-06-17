using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Bootstrap.Docker;

namespace Akka_1_4
{
    class Program
    {
        private static readonly string Config = @"
        
         akka.actor.provider = cluster
         akka.remote.dot-netty.tcp.batching.enabled = false
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
