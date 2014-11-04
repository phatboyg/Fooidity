namespace Fooidity.Client.Tests
{
    using System;
    using System.Threading.Tasks;
    using CodeSwitches;
    using NUnit.Framework;


    [TestFixture, Explicit]
    public class Connecting_to_the_application_hub
    {
        [Test]
        public async void Should_succeed()
        {
            var client = new FooidityClient("sturjs8z35kkpngz8dnphkd9ia7piuzcgcioi1n37uzoce4se15o");

            await client.Connect("http://localhost:1196/");
        }

        [Test]
        public async void Should_succeed_to_report_switch_states()
        {
            using (var client = new FooidityClient("sturjs8z35kkpngz8dnphkd9ia7piuzcgcioi1n37uzoce4se15o"))
            {
                await client.Connect("http://localhost:1196/");

                Console.WriteLine("Connected");

                ICodeSwitch<Feature_Sample> enabledSwitch = new CodeFeatureStateCodeSwitch<Feature_Sample>(client);

                enabledSwitch.Subscribe(client);

                Assert.IsTrue(enabledSwitch.Enabled);

                Console.WriteLine("Waiting");

                await Task.Delay(5000);
            }
        }

        [Test]
        public async void Should_run_and_wait_for_a_while()
        {
            using (var client = new FooidityClient("sturjs8z35kkpngz8dnphkd9ia7piuzcgcioi1n37uzoce4se15o"))
            {
                await client.Connect("http://localhost:1196/");

                Console.WriteLine("Connected");

                ICodeSwitch<Feature_Sample> enabledSwitch = new CodeFeatureStateCodeSwitch<Feature_Sample>(client);

                enabledSwitch.Subscribe(client);

                Assert.IsTrue(enabledSwitch.Enabled);

                ICodeSwitch<Feature_NewUpdateScreen> nextSwitch = new CodeFeatureStateCodeSwitch<Feature_NewUpdateScreen>(client);

                nextSwitch.Subscribe(client);

                bool enabled = nextSwitch.Enabled;

                Console.WriteLine("Waiting");

                await Task.Delay(5000);
            }
        }
    }


    struct Feature_Sample :
        ICodeFeature
    {
    }


    struct Feature_NewUpdateScreen :
        ICodeFeature
    {
    }
}