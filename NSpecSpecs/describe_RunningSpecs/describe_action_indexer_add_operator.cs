﻿using System.Linq;
using NUnit.Framework;
using NSpec;
using NSpec.Domain;
using System.Collections.Generic;

namespace NSpecSpecs.WhenRunningSpecs
{
    [TestFixture]
    [Category("RunningSpecs")]
    public class describe_action_indexer_add_operator : when_running_specs
    {
        private class SpecClass : nspec
        {
            void method_level_context()
            {
                specify = () => "Hello".should_be("Hello");
            }
        }

        [SetUp]
        public void setup()
        {
            Init(typeof(SpecClass));

            Run();
        }

        [Test]
        public void should_contain_pending_test()
        {
            TheExamples().Count().should_be(1);
        }

        [Test]
        public void spec_name_should_reflect_name_specified_in_ActionRegister()
        {
            TheExamples().First().should_cast_to<Example>().Spec.should_be("Hello should be Hello");
        }

        private IEnumerable<object> TheExamples()
        {
            return classContext.Contexts.First().AllExamples();
        }
    }
}
