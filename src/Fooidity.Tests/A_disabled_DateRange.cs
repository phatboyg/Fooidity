namespace Fooidity.Tests
{
    using System;
    using NUnit.Framework;
    using Shouldly;

    public class A_disabled_DateRange
    {
        DateTime start = new DateTime(2014, 1, 1);
        DateTime end = new DateTime(2014, 2, 1);

        [Test]
        public void Enabled_and_correct_dates()
        {
            Func<DateTime> current = ()=> new DateTime(2014,1,15);
            var x = new DateRangeCodeSwitch<SpecialDiscount>(true, start, end, current);

            x.Enabled.ShouldBe(true);
        }

        [Test]
        public void Disabled_even_if_date_is_right()
        {
            Func<DateTime> current = () => new DateTime(2014, 1, 15);
            var x = new DateRangeCodeSwitch<SpecialDiscount>(false, start, end, current);

            x.Enabled.ShouldBe(false);
        }

        [Test]
        public void Disabled_if_date_is_incorrect()
        {
            Func<DateTime> current = () => new DateTime(2014, 3, 15);
            var x = new DateRangeCodeSwitch<SpecialDiscount>(true, start, end, current);

            x.Enabled.ShouldBe(false);
        }

        struct SpecialDiscount : CodeFeature
        {
            
        }
    }
}