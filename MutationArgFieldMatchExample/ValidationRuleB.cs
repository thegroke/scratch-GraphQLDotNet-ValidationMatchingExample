using GraphQL.Language.AST;
using GraphQL.Types;
using GraphQL.Validation;
using System;

namespace MutationArgFieldMatchExample
{
    class ValidationRuleB : IValidationRule
    {
        public INodeVisitor Validate(ValidationContext context)
        {
            return new EnterLeaveListener(_ =>
            {
                _.Match<Argument>(f =>
                {
                    var it = context.TypeInfo.GetInputType();

                    if (it != null)
                    {
                        // Unwrap NonNullGraphTypes
                        while (it is NonNullGraphType)
                        {
                            it = ((NonNullGraphType)it).ResolvedType;
                        }

                        if (it is IComplexGraphType complex)
                        {
                            foreach (var field in complex.Fields)
                            {
                                Console.WriteLine($"ValidationRuleB matched field {field.Name}");
                            }
                        }
                    }
                });
            });
        }
    }
}
