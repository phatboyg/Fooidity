namespace Fooidity.Tests
{
    using System;
    using CodeSwitches;
    using NUnit.Framework;
    using Shouldly;


    public class A_disabled_DateRange
    {
        DateTime end = new DateTime(2014, 2, 1);
        DateTime start = new DateTime(2014, 1, 1);

        [Test]
        public void Enabled_and_correct_dates()
        {
            var x = new DateRangeCodeSwitch<SpecialDiscount>(true, start, end, () => new DateTime(2014, 1, 15));

            x.Enabled.ShouldBe(true);
        }

        [Test]
        public void Disabled_even_if_date_is_right()
        {
            var x = new DateRangeCodeSwitch<SpecialDiscount>(false, start, end, () => new DateTime(2014, 1, 15));

            x.Enabled.ShouldBe(false);
        }

        [Test]
        public void Disabled_if_date_is_incorrect()
        {
            var x = new DateRangeCodeSwitch<SpecialDiscount>(true, start, end, () => new DateTime(2014, 3, 15));

            x.Enabled.ShouldBe(false);
        }


        struct SpecialDiscount : 
            CodeFeature
        {
        }
    }
}