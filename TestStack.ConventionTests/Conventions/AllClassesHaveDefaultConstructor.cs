﻿namespace TestStack.ConventionTests.Conventions
{
    using System.Collections.Generic;
    using System.Linq;
    using TestStack.ConventionTests.ConventionData;
    using TestStack.ConventionTests.Internal;

    public class AllClassesHaveDefaultConstructor : Convention<Types>
    {
        public override string ConventionTitle
        {
            get { return "Types must have a default constructor"; }
        }

        protected override IEnumerable<object> Execute(Types data)
        {
            return data.TypesToVerify.Where(t => t.HasDefaultConstructor() == false);
        }
    }
}