using GraphQL.Language.AST;
using GraphQL.Validation;
using System;

namespace MutationArgFieldMatchExample
{
    class ValidationRuleA : IValidationRule
    {
        public INodeVisitor Validate(ValidationContext context)
        {
            return new EnterLeaveListener(_ =>
            {
                _.Match<Field>(f =>
                {
                    Console.WriteLine($"ValidationRuleA matched {f.Name}");
                });
            });
        }
    }
}
