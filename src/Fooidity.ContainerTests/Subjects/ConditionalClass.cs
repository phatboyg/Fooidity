namespace Fooidity.ContainerTests.Subjects
{
    public class ConditionalClass
    {
        readonly FooId<UseNewMethod> _useNewMethod;

        public ConditionalClass(FooId<UseNewMethod> useNewMethod)
        {
            _useNewMethod = useNewMethod;
        }

        public void MethodCall(int value, string text)
        {
            _useNewMethod.If(MethodCallV2, MethodCallOld, value, text);
        }

        void MethodCallOld(int value, string text)
        {
        }

        void MethodCallV2(int value, string text)
        {
        }

        public string FunctionCall(int value, string text)
        {
            return _useNewMethod.Iff(FunctionCallV2, FunctionCallOld, value, text);
        }

        string FunctionCallOld(int value, string text)
        {
            return string.Format("Old: {0}, {1}", value, text);
        }

        string FunctionCallV2(int value, string text)
        {
            return string.Format("V2: {0}, {1}", value, text);
        }
    }


    public struct UseNewMethod :
        FooId
    {
    }
}