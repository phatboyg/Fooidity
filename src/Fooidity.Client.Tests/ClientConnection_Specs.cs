namespace Fooidity.Client.Tests
{
    using System.Threading;
    using System.Threading.Tasks;
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
            CodeSwitch<Feature_Sample> enabledSwitch;
            using (var client = new FooidityClient("sturjs8z35kkpngz8dnphkd9ia7piuzcgcioi1n37uzoce4se15o"))
            {
                await client.Connect("http://localhost:1196/");

                enabledSwitch = CodeSwitch.Factory.Enabled<Feature_Sample>();

                enabledSwitch.Subscribe(client);

                Assert.IsTrue(enabledSwitch.Enabled);

                await Task.Delay(5000);
            }



        }
    }


    struct Feature_Sample :
        CodeFeature
    {
    }
}