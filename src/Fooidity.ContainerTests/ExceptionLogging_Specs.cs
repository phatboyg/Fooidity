namespace Fooidity.ContainerTests
{
    namespace ExceptionLogging_Specs
    {
        using System;
        using System.Linq;
        using Autofac;
        using Events;
        using Features;
        using NUnit.Framework;


        interface ILogger
        {
            void LogError(Exception exception);
        }


        class Logger :
            ILogger
        {
            readonly ICodeSwitchesEvaluated _evaluated;

            public Logger(ICodeSwitchesEvaluated evaluated)
            {
                _evaluated = evaluated;
            }

            public void LogError(Exception exception)
            {
                CodeSwitchEvaluated[] switches = _evaluated.ToArray();

                Console.WriteLine("{0}\n{1}", exception.Message, string.Join(Environment.NewLine, switches.Select(x => x.Id)));
            }
        }


        class TestClass
        {
            readonly ILogger _logger;
            readonly CodeSwitch<UseNewCodePath> _useNewCodePath;

            public TestClass(ILogger logger, CodeSwitch<UseNewCodePath> useNewCodePath)
            {
                _logger = logger;
                _useNewCodePath = useNewCodePath;
            }

            public void MakeHappy()
            {
                try
                {
                    if(!_useNewCodePath.Enabled)
                        throw new InvalidOperationException("Code path not enabled!");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex);
                }
            }
        }


        [TestFixture]
        public class When_an_exception_occurs_within_a_switched_code_path
        {
            [Test]
            public void Should_capture_the_switch_states()
            {
                using (var scope = _container.BeginLifetimeScope())
                {
                    var testClass = _container.Resolve<TestClass>();

                    testClass.MakeHappy();
                }
            }

            IContainer _container;

            [TestFixtureTearDown]
            public void Teardown()
            {
                _container.Dispose();
            }

            [TestFixtureSetUp]
            public void Setup()
            {
                var builder = new ContainerBuilder();

                builder.RegisterToggle<UseNewCodePath>();
                builder.EnableCodeSwitchTracking();

                builder.RegisterType<Logger>()
                    .As<ILogger>();

                builder.RegisterType<TestClass>();

                _container = builder.Build();
            }
        }
    }
}