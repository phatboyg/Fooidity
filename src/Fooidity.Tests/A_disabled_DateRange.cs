namespace Fooidity.Tests
{
    using System;
    using NUnit.Framework;
    using Shouldly;

    public class A_disabled_DateRange
    {
        [Test]
        public void Enabled_and_correct_dates()
        {
            var start = new DateTime(2014, 1, 1);
            var end = new DateTime(2014, 2, 1);
            Func<DateTime> current = ()=> new DateTime(2014,1,15);
            var x = new DateRangeCodeSwitch<SpecialDiscount>(true, start, end, current);

            x.Enabled.ShouldBe(true);
        }

        [Test]
        public void Disabled_even_if_date_is_right()
        {
            var start = new DateTime(2014, 1, 1);
            var end = new DateTime(2014, 2, 1);
            Func<DateTime> current = () => new DateTime(2014, 1, 15);
            var x = new DateRangeCodeSwitch<SpecialDiscount>(false, start, end, current);

            x.Enabled.ShouldBe(false);
        }

        [Test]
        public void Disabled_if_date_is_incorrect()
        {
            var start = new DateTime(2014, 1, 1);
            var end = new DateTime(2014, 2, 1);
            Func<DateTime> current = () => new DateTime(2014, 3, 15);
            var x = new DateRangeCodeSwitch<SpecialDiscount>(true, start, end, current);

            x.Enabled.ShouldBe(false);
        }

        struct SpecialDiscount : CodeFeature
        {
            
        }
    }
}